using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Listener_PlaySound : MonoBehaviour
{
    public SoundStructure[] soundList;

    private void Awake()
    {
        foreach (SoundStructure sound in soundList)
        {
            sound.source = gameObject.AddComponent<AudioSource>();
            sound.source.clip = sound.clip;
            sound.source.volume = sound.volume;
            sound.source.spatialBlend = sound.spatialBlend;
            sound.source.pitch = sound.pitch;
            sound.source.playOnAwake = sound.playOnAwake;
            sound.source.loop = sound.loop;
        }
    }

    private void OnEnable()
    {
        AudioManager.onPlaySound += PlaySound;
        AudioManager.onPlayOneShotSound += PlayOneShotSound;
        AudioManager.onStopSound += StopSound;

    }

    private void StopSound(GameObject gameObj, string soundName)
    {
        if (gameObj != gameObject)
        {
            return;
        }
        SoundStructure audio = Array.Find(soundList, sound => sound.name == soundName);

        if (audio == null || audio.source == null)
        {
            Debug.LogWarning("Sound : " + soundName + " not found!");
            return;
        }

        audio.source.Stop();
    }

    private void PlayOneShotSound(GameObject gameObj, string soundName)
    {
        if (gameObj != gameObject)
        {
            return;
        }

        SoundStructure audio = Array.Find(soundList, sound => sound.name == soundName);

        if (audio == null || audio.source == null)
        {
            Debug.LogWarning("Sound : " + soundName + " not found!");
            return;
        }

        audio.source.volume = audio.volume;
        audio.source.pitch = audio.pitch;
        audio.source.loop = audio.loop;
        audio.source.spatialBlend = audio.spatialBlend;

        audio.source.PlayOneShot(audio.source.clip);
    }

    private void OnDisable()
    {
        AudioManager.onPlaySound -= PlaySound;
        AudioManager.onPlayOneShotSound -= PlayOneShotSound;
        AudioManager.onStopSound -= StopSound;
    }
    private void PlaySound(GameObject gameObj, string soundName)
    {
        if (gameObj != gameObject)
        {
            return;
        }
                                        //return element if-- element.name == givenName
        SoundStructure audio = Array.Find(soundList, sound => sound.name == soundName);

        if (audio == null || audio.source == null)
        {
            Debug.LogWarning("Sound : " + soundName + " not found!");
            return;
        }

        audio.source.volume = audio.volume;
        audio.source.pitch = audio.pitch;
        audio.source.loop = audio.loop;
        audio.source.spatialBlend = audio.spatialBlend;

        audio.source.Play();
    }
}
