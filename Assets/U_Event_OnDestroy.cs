﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class U_Event_OnDestroy : MonoBehaviour
{
    public UnityEvent OnDestroyEvent;
    private void OnDestroy()
    {
        OnDestroyEvent?.Invoke();
    }
}
