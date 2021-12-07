using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollision : MonoBehaviour
{
   
  // Declares Cannon and bullet gameobjects

  GameObject Cannon; 
  public GameObject bullet;
void Start()
{

  // Checks if player gameobject is in range.
  // Initializes Cannon decleration

  this.Cannon = GameObject.Find("wallCannonEdited");
  isShoot();
}

void update()
{

  // Checks if player gameobject is in range.

  isShoot();
}

  // NOT OPERATIONAL
  // isShoot trys to make the cannon fire a bullet when the player enters range
  public void isShoot()
  {
    GameObject Player = GameObject.Find("Player");
    Player PlayerScript = Player.GetComponent<Player>();
    if(PlayerScript.getX() >= transform.position.x-0.5f)
    {
      print("in range");
      Instantiate(bullet, new Vector3(transform.position.x-0.1f, transform.position.y, 0), Quaternion.identity);
    }
  }

  // When a bullet collides with the cannon then the cannon is destroyed

   void OnCollisionEnter2D(Collision2D coll)
   {
       if (coll.gameObject.name == "Bullet(Clone)")
       {
             Destroy(this.gameObject);
       }
   }
}
