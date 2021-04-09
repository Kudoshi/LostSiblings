using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlassCubeBreak : MonoBehaviour
{
    public ParticleSystem breakFx;

    private bool GlassBroke = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    public void BreakGlass()
    {
        if (!GlassBroke)
        {
            AudioManager.PlaySound(gameObject, "GlassBlockBreak");
            breakFx.Play();
            GetComponent<MeshRenderer>().enabled = false;
            GetComponent<MeshCollider>().enabled = false;
            GlassBroke = true;
        }
        
    }

}
