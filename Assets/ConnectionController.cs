using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[ExecuteInEditMode()]
public class ConnectionController : MonoBehaviour
{
    public Transform start;
    public Transform end;
    public LineRenderer lr;
    public float maxDistance;
    public SO_Levels Data_Levels;
    [Header("Near Color")]
    public Color nearStartColor;
    public Color nearEndColor;

    [Header("Far Color")]
    public Color farStartColor;
    public Color farEndColor;

    private void Start()
    {
        AudioManager.PlaySound(lr.gameObject, "Link");
    }
    private void Update()
    {
        if (lr == null)
            return;
        lr.SetPosition(0, start.position);
        lr.SetPosition(1, end.position);

        CheckLinkDistance();
    }

    private void CheckLinkDistance()
    {
        if (lr.enabled == false)
        {
            Debug.Log("hilo");
            return;
        }
        float distance = Vector3.Distance(start.position, end.position);
        
        if (distance > maxDistance)
        {
            //Destroy(lr);
            Events.triggerOnLinkBreak();
            AudioManager.PlaySound(lr.gameObject, "LinkBreak");
            AudioManager.StopSound(lr.gameObject, "Link");
            lr.enabled = false;

            Invoke("ReconnectLink", 1.2f);
            // Invoke("ConnectionBroken", 4.5f);
        }

        
        float colorValue = distance / maxDistance;

        //Start Point Color
        Color startColor = Color.Lerp(nearStartColor, farStartColor, colorValue);
        lr.startColor = startColor;

        //End Point Color
        Color endColor = Color.Lerp(nearEndColor, farEndColor, colorValue);
        lr.endColor = endColor;
        
    }
    private void ConnectionBroken()
    {
        Data_Levels.ResetScene();
    }
    private void ReconnectLink()
    {
        lr.enabled = true;
    }
}
