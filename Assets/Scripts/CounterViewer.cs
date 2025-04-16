using UnityEngine;

public class CounterViewer : MonoBehaviour
{

    [SerializeField] Counter _counter;

    private void OnEnable()
    {
        _counter.ShowCounter += ShowCounter;
    }

    private void OnDisable()
    {
        _counter.ShowCounter -= ShowCounter;
    }

    private void ShowCounter()
    {
        Debug.Log(_counter.CounterNumber);
    }
}
