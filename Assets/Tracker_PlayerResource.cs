using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tracker_PlayerResource : MonoBehaviour
{
    public SO_PlayerResource playerResource;
    void Start()
    {
        ResetPlayerResource();
        FindTotalGoldInLevel();
    }

    private void FindTotalGoldInLevel()
    {
        GameObject[] coins = GameObject.FindGameObjectsWithTag("Coins");
        int coinCount = 0;
        foreach (var coin in coins)
            coinCount++;

        playerResource.setTotalGoldInLevel(coinCount);
    }

    private void ResetPlayerResource()
    {
        playerResource.Gold = 0;
    }

    
}
