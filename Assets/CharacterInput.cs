using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterInput : MonoBehaviour
{
    public bool CharacterUp;
    private CharacterMovement characMovement;

    private string Horizontal;
    private string Vertical;
    void Awake()
    {
        characMovement = GetComponent<CharacterMovement>();
        if (characMovement == null)
        {
            Debug.LogWarning("CharacterMovement Script not found in same object");
        }
        SwitchCharacInput();
    }

    // Update is called once per frame
    void Update()
    {
        RegisterMovementInput();
        
    }
    private void RegisterMovementInput()
    {
        //Horizontal Movement
        float horizontalInput = Input.GetAxis(Horizontal);
        characMovement.MoveCharacter(horizontalInput);

        //Jump movement
        if (Input.GetButtonDown(Vertical))
        {
            characMovement.RegisterJump(true);
        }
    }    
    private void SwitchCharacInput()
    {
        if (CharacterUp)
        {
            Horizontal = "UpHorizontal";
            Vertical = "UpVertical";
        } 
        else
        {
            Horizontal = "DownHorizontal";
            Vertical = "DownVertical";
        }
    }
}
