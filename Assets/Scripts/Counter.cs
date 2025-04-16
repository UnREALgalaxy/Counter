using System;
using System.Collections;
using UnityEngine;

public class Counter : MonoBehaviour
{
    [SerializeField] private InputHandler _inputHandler;

    public event Action ShowCounter;
    private float _delay = 0.5f;
    private Coroutine _coroutine = null;

    public int CounterNumber { get; private set; } = 0;

    private void OnEnable()
    {
        _inputHandler.Activated += ActivateCounter;
        _inputHandler.Deactivated += DeactivateCounter;
    }

    private void OnDisable()
    {
        _inputHandler.Activated -= ActivateCounter;
        _inputHandler.Deactivated -= DeactivateCounter;
    }

    private void DeactivateCounter()
    {
        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
            _coroutine = null;
        }
    }

    private void ActivateCounter()
    {
        _coroutine = StartCoroutine(StartCounter());
    }

    private IEnumerator StartCounter()
    {
        var wait = new WaitForSecondsRealtime(_delay);

        while (true)
        {
            CounterNumber++;

            ShowCounter.Invoke();

            yield return wait;
        }
    }
}
