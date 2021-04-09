using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
public class AudioManager : MonoBehaviour
{
    public static Action<GameObject, string> onPlaySound;
    
    public static void PlaySound(GameObject gameObj, string soundName)
    {
        onPlaySound?.Invoke(gameObj,soundName);
    }

    public static Action<GameObject, string> onPlayOneShotSound;

    public static void PlayOneShotSound(GameObject gameObj, string soundName)
    {
        onPlayOneShotSound?.Invoke(gameObj, soundName);
    }

    public static Action<GameObject, string> onStopSound;

    public static void StopSound(GameObject gameObj, string soundName)
    {
        onStopSound?.Invoke(gameObj, soundName);
    }
}
