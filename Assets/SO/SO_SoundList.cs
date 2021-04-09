using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data_SoundList", menuName = "ScriptableObject/Data_SoundList")]
public class SO_SoundList : ScriptableObject
{
    public SoundStructure[] soundList;
}
