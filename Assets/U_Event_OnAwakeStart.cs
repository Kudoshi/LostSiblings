using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class U_Event_OnAwakeStart : MonoBehaviour
{
    public UnityEvent onAwakeEvents;
    public UnityEvent onStartEvents;
    private void Awake()
    {
        onAwakeEvents?.Invoke();
    }
    void Start()
    {
        onStartEvents?.Invoke();   
    }

}
