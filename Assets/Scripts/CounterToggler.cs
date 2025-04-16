using System;
using UnityEngine;

public class CounterToggler : MonoBehaviour
{
    public event Action Activated;
    public event Action Deactivated;

    public bool IsActivated {  get; private set; } = false;

    private void Update()
    {
        ToggleCounter();
    }

    private void ToggleCounter()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (IsActivated)
            {
                IsActivated = false;
                Deactivated.Invoke();
            }
            else
            {
                IsActivated = true;
                Activated.Invoke();
            }
        }
    }
}
