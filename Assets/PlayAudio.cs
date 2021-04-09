using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAudio : MonoBehaviour
{
    public string audioName;

    public void playAudio()
    {
        AudioManager.PlaySound(gameObject, audioName);
    }
}
