using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageStart : MonoBehaviour
{
    void Start()
    {
        AudioManager.PlaySound(gameObject, "StageStart");
        int randomNumber = Random.Range(1, 3);
        if (randomNumber == 1)
            AudioManager.PlaySound(gameObject, "Abyss");
        else if (randomNumber == 2)
            AudioManager.PlaySound(gameObject, "SpaceStage");
    }

    
}
