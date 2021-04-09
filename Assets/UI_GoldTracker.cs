using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class UI_GoldTracker : MonoBehaviour
{
    private TextMeshProUGUI GoldUI;
    public SO_PlayerResource playerResource;
    private void Awake()
    {
        GoldUI = GetComponent<TextMeshProUGUI>();
    }
    // Update is called once per frame
    void Update()
    {
        GoldUI.text = "GOLD: " + playerResource.Gold;
    }
}
