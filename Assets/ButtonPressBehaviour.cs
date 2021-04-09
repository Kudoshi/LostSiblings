using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class ButtonPressBehaviour : MonoBehaviour
{
    public Transform UpperButton;
    public float pressedDownValue;
    public bool disableButtonFunc = false;
    public UnityEvent triggerEvents;

    private Vector3 pressedDownVector;
    private bool Pressed;
    private bool buttonDisabled = false;
    private void Awake()
    {
        pressedDownVector = new Vector3(0, pressedDownValue, 0);

    }
    public void PressButton()
    {

        Debug.Log("ButtonPressed");
        //If button is disabled. Don't do anything
        if (buttonDisabled)
            return;

        //Set button Press
        SetPressed();
        ButtonMovePos();
        //Press Logic
        

        //If disable Button function is enabled, disable the button
        if (disableButtonFunc)
            buttonDisabled = true;
            
    }

    private void ButtonMovePos()
    {
        if (Pressed)
            UpperButton.transform.localPosition -= pressedDownVector;
        else if (!Pressed)
            UpperButton.transform.localPosition += pressedDownVector;
    }

    private void SetPressed()
    {
        Pressed = !Pressed;
        triggerEvents?.Invoke();
    }
    public bool GetButtonPressedBool()
    {
        return Pressed;
    }
}
