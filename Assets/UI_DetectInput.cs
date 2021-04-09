using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class UI_DetectInput : MonoBehaviour
{
    public UnityEvent onAnyKeyEvent;

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown)
        {
            onAnyKeyEvent?.Invoke();
        }
    }
}
