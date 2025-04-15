using System;
using Unity.VisualScripting;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    public event Action Activated;
    public event Action Deactivated;

    public bool IsActivated {  get; private set; } = false;

    private void Update()
    {
        Activate();
    }

    private void Activate()
    {
        if (Input.GetMouseButtonDown((int)MouseButton.Left))
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
