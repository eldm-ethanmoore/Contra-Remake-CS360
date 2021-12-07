using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Timers;
using System.Diagnostics;

public class Player : MonoBehaviour
{

    // Declares Bullet and HealthIndicator GameObject also declares AnimationScript.
    // Initializes speed, startJump, midJump, jumpCounter, isGrounded, and disableSKey.

    public GameObject bullet;

    StickToPlayer AnimationScript;
    GameObject HealthIndicator;
    public float speed = 0.1f;
    public bool startJump = false;
    public bool midJump = false;
    public int jumpCounter = 0;
    public bool isGrounded = false;
    public bool disableSKey = false;
    public string bulletDirection;
    // Start is called before the first frame update
    void Start()
    {

        // Sets player gameobject's default position.

        setX(-1.772f);
        setY(1.053f);       

        // Checks if player gameobject has pressed a keyboard button.

        userControls();

        // Initializes AnimationScript and HealthIndicator gameobjects
        // Initializes HealthIndicator and AnimationScript of type StickToPlayer

        GameObject AnimationScript = GameObject.Find("MidAirLanceBean");
        GameObject HealthIndicator = GameObject.Find("Health");
        this.HealthIndicator = HealthIndicator;
        this.AnimationScript = AnimationScript.GetComponent<StickToPlayer>();

        // Sets AnimationScript player position as default position.

        this.AnimationScript.setXPos(-1.772f);
        this.AnimationScript.setYPos(1.053f);
    }

    // Update is called once per frame
    void Update()
    {

        // Triggers the idle animation.

        GameObject AnimationScript = GameObject.Find("MidAirLanceBean");
        this.AnimationScript = AnimationScript.GetComponent<StickToPlayer>();
        this.AnimationScript.setIdle(true);

        // Checks if user has initiated a keypress.

        userControls();

        /*
          If a jump has been initiated then the player will move vertically until 
          the jumpCounter equals 10.
        */

        if(this.startJump)
        {
            setY(getY()+.1f);
            this.jumpCounter = this.jumpCounter + 1;
            if(this.jumpCounter == 10)
            {
                this.startJump = !this.startJump;
                this.jumpCounter = 0;
            }
        }

        // Updates AnimationScript player gameobjects X and Y position.

        this.AnimationScript.setXPos(getX());
        this.AnimationScript.setYPos(getY());       
    }

    public void userControls()
    {

        // Initializes AnimationScript GameObject and AnimationScript StickToPlayer type.

        GameObject AnimationScript = GameObject.Find("MidAirLanceBean");
        this.AnimationScript = AnimationScript.GetComponent<StickToPlayer>();

        /*
            space - Start jump animation, triggers idle to false, starts jump bool, and makes the player not grounded.
            a - Flips player sprite to the left, idle to false, running animation starts, changes player x position.
            s - Idle to false, starts jumping animation, changes players Y position.
            d - Idle to false, flips player sprite to the right, sets moving right attribute to true, starts running animation, and changes players X position.
            up arrow key - Starts timer for shooting bullets upward, sets bulletDirection attribute to up, creates bullet above player, prints time to execute.
            down arrow key - Starts timer for shooting bullets downward, sets bulletDirection attribute to down, creates bullet below player, prints time to execute. 
            left arrow key - Starts timer for shooting bullets left, sets bulletDirection attribute to left, creates bullet to the left of the player, prints time to execute. 
            right arrow key -  Starts timer for shooting bullets right, sets bulletDirection attribute to right, creates bullet to the right of the player, prints time to execute. 
            esc - Loads new scene to go back to the mainmenu or continue.
            
            Otherwise set moving right attribute to false and set animation to idle.
        */

        if (Input.GetKeyDown("space") & this.startJump == false && this.isGrounded)
        {
            this.AnimationScript.setIdle(false);
            this.AnimationScript.setJumpingAnim();
            this.startJump = true;
            this.isGrounded = false;
        }
        else if (Input.GetKey("a"))
        {
            this.AnimationScript.setIdle(false);
            this.AnimationScript.setFlipX(true);
            this.AnimationScript.setRunningAnim();
            setX(getX()-(Time.deltaTime * speed));
        }
        else if (Input.GetKey("s") && !this.disableSKey)
        {
            this.AnimationScript.setIdle(false);
            this.AnimationScript.setJumpingAnim();
            setY(getY()-(Time.deltaTime * speed));
        }
        else if (Input.GetKey("d"))
        {
            
            this.AnimationScript.setIdle(false);
            this.AnimationScript.setFlipX(false);
            this.AnimationScript.setMovingRight(true);
            this.AnimationScript.setRunningAnim();
            setX(getX()+(Time.deltaTime * speed));
            
        } 
        else if (Input.GetKey("up"))
        {
            var watch = new System.Diagnostics.Stopwatch();
            watch.Start();
            this.bulletDirection = "up";
            Instantiate(bullet, new Vector3(getX(), getY()+.1f, 0), Quaternion.identity);
            watch.Stop();
            print($"Execution Time: {watch.ElapsedTicks} ticks");
        }
        else if (Input.GetKey("down"))
        {
            var watch = new System.Diagnostics.Stopwatch();
            watch.Start();
            this.bulletDirection = "down";
            Instantiate(bullet, new Vector3(getX(), getY()-.1f, 0), Quaternion.identity);
            watch.Stop();
            print($"Execution Time: {watch.ElapsedTicks} ticks");
        }
        else if (Input.GetKey("left"))
        {
            var watch = new System.Diagnostics.Stopwatch();
            watch.Start();
            Instantiate(bullet, new Vector3(getX()-.1f, getY(), 0), Quaternion.identity);
            watch.Stop();
            print($"Execution Time: {watch.ElapsedTicks} ticks");
        }

        else if (Input.GetKey("right"))
        {
            var watch = new System.Diagnostics.Stopwatch();
            watch.Start();
            this.bulletDirection = "right";
            Instantiate(bullet, new Vector3(getX()+.1f, getY(), 0), Quaternion.identity);
            watch.Stop();
            print($"Execution Time: {watch.ElapsedTicks} ticks");
        }
        else if (Input.GetKey("escape"))
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(4);
        }
        else {
            this.AnimationScript.setMovingRight(false);
            this.AnimationScript.setIdleAnim();
        }
        
    }
    public void OnCollisionEnter2D(Collision2D coll)
    {

        // If player collides with the KillLand then he loses health, triggers hit animation, and is moved to the games default position.
        // NOT OPERATIONAL - Player doesnt get hurt from colliding with wallCannon - Potentially because wallCannon name doesn't match.

        if (coll.gameObject.name == "KillLand" || coll.gameObject.name == "wallCannonEdited")
        {
            this.AnimationScript.setHitAnim();
            Destroy(this.HealthIndicator);
            setX(-1.772f);
            setY(1.053f);   
            
        }

        // If player is on land then he can clip through the land

        if (coll.gameObject.name == "Land")
        {
            this.GetComponent<Player>().isGrounded = true;
            this.GetComponent<Player>().disableSKey = false;
            this.AnimationScript.setGrounded();
            this.AnimationScript.setIdleAnim();
        }

        // If player collides with solid land then he cant hold down the S Key to clip through the floor.

        if (coll.gameObject.name == "SolidLand")
        {
            this.GetComponent<Player>().isGrounded = true;
            this.GetComponent<Player>().disableSKey = true;
            this.AnimationScript.setGrounded();
            this.AnimationScript.setIdleAnim();
        }
    }

    // Setters and getters
    // Getter for the bulletDirection
    
    public void setX(float xPos)
    {
        gameObject.transform.position = new Vector2(xPos, getY());
    }
    public void setY(float yPos)
    {
        gameObject.transform.position = new Vector2(getX(), yPos);
    }
    public float getY()
    {
        return transform.position.y;
    }
    public float getX()
    {
        return transform.position.x;
    }

    public string getBulletDirection()
    {
        return this.bulletDirection;
    }
}
