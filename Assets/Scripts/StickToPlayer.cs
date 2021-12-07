using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class StickToPlayer : MonoBehaviour
{

    // Declares PlayerAnimation var of type Animator.

    Animator PlayerAnimation;

    // Initializes state of gameobject player variables.

    public bool isGrounded = false;

    public bool isIdle = false;
    public bool currentIdleState = false;
    public bool isMovingRight = false;


    void Start()
    {

        // Initializes playerAnimation.

        Animator playerAnimation = GetComponent<Animator>();
        this.PlayerAnimation = playerAnimation;
    }

    void Update()
    {
        Animator playerAnimation = GetComponent<Animator>();
        this.PlayerAnimation = playerAnimation;
    }

    // Setters for setting position X and Y, is player grounded, is player idle, and if player is moving right.

    public void setXPos(float xPos)
    {
        transform.position = new Vector2(xPos, transform.position.y);       
    }
    public void setYPos(float yPos)
    {
        transform.position = new Vector2(transform.position.x, yPos);       
    }
    public void setGrounded()
    {
        this.isMovingRight = false;
        this.isGrounded = !this.isGrounded;
    }
    public void setIdle(bool isIdle)
    {
        this.isIdle = isIdle;
        this.currentIdleState = isIdle;
    }
    public void setMovingRight(bool isMovingRight)
    {
        this.isMovingRight = isMovingRight;
    }

    public bool getMovingRight()
    {
        return this.isMovingRight;
    }

    // Flips players sprint horizontally.

    public void setFlipX(bool isFlip)
    {
        SpriteRenderer mySpriteRenderer = GetComponent<SpriteRenderer>();
        mySpriteRenderer.flipX = isFlip;
    }

    // Triggers for running, jumping, idle, and player gameobject being hit.

    public void setRunningAnim()
    {
        this.PlayerAnimation.SetTrigger("running");
    }
    public void setJumpingAnim()
    {
        var watch = new System.Diagnostics.Stopwatch();
        watch.Start();
        this.PlayerAnimation.SetTrigger("jumping");
        watch.Stop();
        print($"Execution Time: {watch.ElapsedTicks} ticks");
    }
    public void setIdleAnim()
    {
        this.PlayerAnimation.SetTrigger("idle");
    }
    public void setHitAnim()
    {
        this.PlayerAnimation.SetTrigger("hit");
    }
}

