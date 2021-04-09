using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CharacterDeath : MonoBehaviour
{
    public ParticleSystem deathFx;
    public ParticleSystem linkBreakFx;

    private Vector3 respawnPoint;
    private CharacterInput characInput;
    private void Awake()
    {
        SetRespawnPoint();
        characInput = GetComponent<CharacterInput>();
    }
    public void SetRespawnPoint()
    {
        respawnPoint = transform.position;
    }
    private void OnEnable()
    {
        Events.onPlayerKilled += KillCharacter;
        Events.onLinkBreak += LinkBreak;
    }
    private void OnDisable()
    {
        Events.onPlayerKilled -= KillCharacter;
        Events.onLinkBreak -= LinkBreak;

    }

    public void KillCharacter(GameObject player)
    {

        if (player == gameObject)
        {
            characInput.enabled = false;
            AudioManager.PlaySound(gameObject, "DeathFx");
            deathFx.Play();
        }
        
        Invoke("RespawnsPlayer", 1.2f);
    }
    private void RespawnsPlayer()
    {
        characInput.enabled = true;
        transform.position = respawnPoint;
    }
    private void LinkBreak()
    {
        characInput.enabled = false;
        linkBreakFx.Play();
        Invoke("RespawnsPlayer", 1.2f);

    }
}
