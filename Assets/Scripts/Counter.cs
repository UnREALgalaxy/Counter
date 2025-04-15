using System.Collections;
using UnityEngine;

public class Counter : MonoBehaviour
{
    [SerializeField] private InputHandler _inputHandler;

    private float _delay = 0.5f;
    private int _counter = 0;
    private Coroutine _coroutine = null;

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
            Debug.Log(_counter);
            _counter++;

            yield return wait;
        }
    }
}
