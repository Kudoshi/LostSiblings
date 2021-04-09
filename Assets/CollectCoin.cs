using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectCoin : MonoBehaviour
{
    public AudioClip clip;
    public void TriggerCollectCoin()
    {
        AudioSource.PlayClipAtPoint(clip, transform.position, 1.0f);

        Destroy(gameObject);
    }
}
