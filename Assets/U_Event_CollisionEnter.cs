using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class U_Event_CollisionEnter : MonoBehaviour
{
    public string compareTag;
    public string secondCompareTag;
    public bool ignoreCompareTag = false;
    public UnityEvent onCollisionEnterEvents;
    public UnityEvent onTriggerEnterEvents;
    public UnityEvent onTriggerExitEvents;
    public UnityEvent onCollisionExitEvents;
    private bool canBeTriggered = true;

    private void OnCollisionEnter(Collision collision)
    {
        onCollisionEnterEvents?.Invoke();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(compareTag) || other.CompareTag(secondCompareTag) || ignoreCompareTag)
        {
            //Set trigger to false when triggered once
            if (canBeTriggered)
            {
                onTriggerEnterEvents?.Invoke();
                canBeTriggered = false;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(compareTag) || other.CompareTag(secondCompareTag) || ignoreCompareTag)
        {
            //Set trigger to false when triggered once
            if (!canBeTriggered)
            {
                onTriggerExitEvents?.Invoke();
                canBeTriggered = true;
            }
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.CompareTag(compareTag) || collision.collider.CompareTag(secondCompareTag) || ignoreCompareTag)
        {
            //Set trigger to false when triggered once
            if (!canBeTriggered)
            {
                onCollisionExitEvents?.Invoke();
                canBeTriggered = true;
            }
        }
    }
}
