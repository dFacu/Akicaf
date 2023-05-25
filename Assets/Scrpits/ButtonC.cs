using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ButtonC : MonoBehaviour
{
    public  UnityEvent OnButtonPressed;
    public bool n_isPressed = false;

    void PressedButton()
    {
        if (n_isPressed)
            return;
        n_isPressed = true;

        OnButtonPressed?.Invoke();
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PressedButton();
        }
    }
}
