using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class BothButtonPressToInvoke : MonoBehaviour
{
    public ButtonPressBehaviour button1;
    public ButtonPressBehaviour button2;


    public UnityEvent onBothButtonPressed;
    private bool button1Pressed;
    private bool button2Pressed;
    public void PressButton()
    {
        button1Pressed = button1.GetButtonPressedBool();
        button2Pressed = button2.GetButtonPressedBool();

        if (button1Pressed && button2Pressed)
            onBothButtonPressed?.Invoke();
    }
}
