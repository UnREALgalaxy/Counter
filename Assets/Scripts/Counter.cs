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
        _inputHandler.Activated += Activate;
        _inputHandler.Deactivated += Deactivate;
    }

    private void OnDisable()
    {
        _inputHandler.Activated -= Activate;
        _inputHandler.Deactivated -= Deactivate;
    }

    private void Deactivate()
    {
        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
            _coroutine = null;
        }
    }

    private void Activate()
    {
        _coroutine = StartCoroutine(StartCount());
    }

    private IEnumerator StartCount()
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
