using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObject : MonoBehaviour
{
    public GameObject[] objects;

    public void destroyObjects()
    {
        foreach (GameObject element in objects)
            Destroy(element);
    }
}
