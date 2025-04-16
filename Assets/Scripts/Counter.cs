using System;
using System.Collections;
using UnityEngine;

public class Counter : MonoBehaviour
{
    [SerializeField] private CounterToggler _inputHandler;

    private float _delay = 0.5f;
    private Coroutine _coroutine = null;
    private int _counterNumber = 0;

    public event Action<int> Changed;

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

        while (enabled)
        {
            _counterNumber++;

            Changed.Invoke(_counterNumber);

            yield return wait;
        }
    }
}
