using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public float speed;
    public float maxSpeed;
    public float jumpForce;
    public float gravityForce;

    private Rigidbody rb;
    private bool isFacingRight = true;
    private bool wasFacingRight = true;
    private bool isJumping = false;
    private bool shouldMoveForward;
    private float inputMoveSpeed;
    public int jumpCount = 0;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        if (inputMoveSpeed == 0)
        {
            Vector3 targetVelocity = new Vector3(0, rb.velocity.y, 0);
            rb.velocity = Vector3.SmoothDamp(rb.velocity, targetVelocity, ref refVelocity, 0.1f);
        }
        if (inputMoveSpeed != 0 && shouldMoveForward)
            MoveCharacterForward();
        

        Jump();
        ApplyJumpGravity();
        

    }

    private bool playingMoveFx;
    #region Horizontal Movement
    //Receives movement Input and set boolean
    public void MoveCharacter(float movement)
    {
        //Horizontal
        if (movement >= 0.01f)
        {
            isFacingRight = true;
            FlipCharacter();
            inputMoveSpeed = movement;
            shouldMoveForward = true;
            //StartCoroutine(playMoveFx());

        }
        else if (movement <= -0.01f)
        {
            isFacingRight = false;
            FlipCharacter();
            inputMoveSpeed = movement;
            shouldMoveForward = true;
            //StartCoroutine(playMoveFx());
        }
        else
        {
            shouldMoveForward = false;
            inputMoveSpeed = 0;
        }
    }
    private IEnumerator playMoveFx()
    {
        if (playingMoveFx)
            yield break;

        playingMoveFx = true;
        yield return new WaitForSeconds(0.25f);
        AudioManager.PlayOneShotSound(gameObject, "MoveFx");
        playingMoveFx = false;
    }
    //Apply a front force to gameobject (FixedUpdate)
    private Vector3 refVelocity = Vector3.zero;
    private void MoveCharacterForward()
    {
        Vector3 targetVelocity = new Vector3(inputMoveSpeed * speed, rb.velocity.y, 0);
        rb.velocity = Vector3.SmoothDamp(rb.velocity, targetVelocity, ref refVelocity, 0.1f);
        inputMoveSpeed = 0;
    }
    //Flip character according to movement force
    private void FlipCharacter()
    {
        //Character looking right
        if (isFacingRight)
        {
            if (!wasFacingRight)
            {
                wasFacingRight = true;
                // transform.Rotate(0, 0, 0, Space.World);
                transform.localRotation = Quaternion.Euler(0, 0, 0);
              //  rb.velocity = Vector3.zero;
            }
        }
        //Character looking left
        else if (!isFacingRight)
        {
            if (wasFacingRight)
            {
                wasFacingRight = false;
                //transform.Rotate(0, 180, 0, Space.World);
                transform.localRotation = Quaternion.Euler(0, 180, 0);
               // rb.velocity = Vector3.zero;
            }
        }
    }
    #endregion

    #region Jump Movement
    /// <summary>
    /// RegisterJump sets isJumping to true -> In Update, Call Jump function
    /// In Jump(), if isJumping is true then you jump. Add a jumpcount and set isJumping to false
    /// Reset jump resets jumpcount to prevent double jumping.
    /// The only time Jump() will jump is when isJumping is set to true by RegisterJump
    /// </summary>
    //Register jump bool
    public void RegisterJump(bool jumping)
    {
        
        isJumping = jumping;
    }

    private void Jump()
    {
        if (isJumping && jumpCount < 2)
        {

            jumpCount++;
            rb.velocity = new Vector3(rb.velocity.x, 0, rb.velocity.z);
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            AudioManager.PlaySound(gameObject,"Jump");
            isJumping = false;
        }
        else if (jumpCount >= 2)
        {
            isJumping = false;
        }
        else
            isJumping = false;
    }
    
    //Called via event
    public void ResetJump()
    {
        jumpCount = 0;
    }

    private void ApplyJumpGravity()
    {
        //Falling
        if (rb.velocity.y < 0)
        {
            rb.velocity += Vector3.up * Physics.gravity.y * (gravityForce - 1);
        }
       
    }
    #endregion

    #region Prevent Stick To Wall

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("StageWall"))
        {
            Debug.Log("Stop wall");

        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.CompareTag("StageWall"))
        {
            Debug.Log("Exit wall");

        }
    }


    #endregion
}
