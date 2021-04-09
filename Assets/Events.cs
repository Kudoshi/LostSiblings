using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class Events : MonoBehaviour
{
    public static Action<GameObject> onPlayerKilled;

    public static void triggerOnPlayerKilled(GameObject player)
    {
        onPlayerKilled?.Invoke(player);
    }

    public static Action onLinkBreak;
    public static void triggerOnLinkBreak()
    {
        onLinkBreak?.Invoke();
    }
}
