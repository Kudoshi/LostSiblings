using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerResource", menuName = "ScriptableObject/PlayerResource")]
public class SO_PlayerResource : ScriptableObject
{
    public int Gold;
    public int totalGoldInLevel;
    public void AddGold()
    {
        Gold++;
    }
    public void setTotalGoldInLevel(int goldCount)
    {
        totalGoldInLevel = goldCount;
    }
}
