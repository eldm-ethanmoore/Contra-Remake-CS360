using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    Player PlayerScript;
    Renderer renderer;
    public string bulletDirection;
    // Start is called before the first frame update
    void Start()
    {
        // Initializes the PlayerScript, renderer, and bulletDirection 

        GameObject PlayerScript = GameObject.Find("Player");
        this.PlayerScript = PlayerScript.GetComponent<Player>();
        this.bulletDirection = this.PlayerScript.getBulletDirection();
    }

    // Update is called once per frame
    void Update()
    {
        /*
            While the bullet is visible from the cameras point of view then
            the bullet gameobject is alive. Otherwise the bullet gameobject
            is destroyed. Depending on the direction that the bulletDirection
            is set to the corresponding X or Y position is changed.
        */

        this.renderer = GetComponent<Renderer>();
        if(this.renderer.isVisible)
        {
            if(this.bulletDirection == "right")
            {
                setX(getX()+.1f);
            }
            else if(this.bulletDirection == "left")
            {
                setX(getX()-.1f);
            }
            else if(this.bulletDirection == "up")
            {
                setY(getY()+.1f);
            }
            else if(this.bulletDirection == "down")
            {
                setY(getY()-.1f);
            }
        } else {
            Destroy(gameObject);
        }
    }

    // Getters and setters for the individual bullets
    public float getY()
    {
        return transform.position.y;
    }
    public float getX()
    {
        return transform.position.x;
    }
    public void setX(float xPos)
    {
        transform.position = new Vector2(xPos, getY());
    }
    public void setY(float yPos)
    {
        transform.position = new Vector2(getX(), yPos);
    }
}
