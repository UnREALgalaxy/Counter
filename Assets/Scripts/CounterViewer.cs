using UnityEngine;

public class CounterViewer : MonoBehaviour
{

    [SerializeField] Counter _counter;

    private void OnEnable()
    {
        _counter.Changed += ShowNumber;
    }

    private void OnDisable()
    {
        _counter.Changed -= ShowNumber;
    }

    private void ShowNumber(int number)
    {
        Debug.Log(number);
    }
}
