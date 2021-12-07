using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraToPlayer : MonoBehaviour
{
    Player PlayerScript;
    bool isSnapped = false;
    // Start is called before the first frame update
    void Start()
    {

        // Initializes PlayerScript and player gameobject

        GameObject player = GameObject.Find("Player");
        this.PlayerScript = player.GetComponent<Player>();

    }

    // Update is called once per frame
    void Update()
    {
        /*
          While the camera is not snapped nothing changes.
          Otherwise the camera moves depending on the characters X position.
        */

        checkSnap();
        if(isSnapped)
        {
            snapCamera();
        }

    }

    // Checks gameobject player's position.
    public void checkSnap()
    {
        if(this.PlayerScript.getX() >= 0.5)
        {
            this.isSnapped = true;
        }
    }
    
    // Sets cameras X position to the corresponding player gameobjects X position.
    public void snapCamera()
    {
        float x = this.PlayerScript.getX();
        transform.position = new Vector3(x, gameObject.transform.position.y, -1.26f);

    }

    // Getters for X and Y

    public float getY()
    {
        return transform.position.y;
    }
    public float getX()
    {
        return transform.position.x;
    }
}
