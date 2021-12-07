using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFactory : AbstractFactory
{

    // Declares all of the cannons in the level 1 scene.

    public GameObject bullet;
    public GameObject wallCannon;
    public GameObject wallCannon1;

    public GameObject wallCannon2;
    public GameObject wallCannon3;
    public GameObject wallCannon4;
    public GameObject wallCannon5;
    public GameObject wallCannon6;
    public GameObject wallCannon7;

    // Initializes one wallCannon

    void Start()
    {
        GameObject wallCannon = GameObject.Find("wallCannonEdited");
        this.wallCannon = wallCannon;
        createWallCannon();
    }

    // NOT OPERATIONAL
    // Print out all the created cannon gameobjects

    public GameObject[] GetEnemy(string enemy)
    {
        GameObject[] enemyArray = new GameObject[7];
        enemyArray[0] = this.wallCannon1;
        enemyArray[1] = this.wallCannon2;
        enemyArray[2] = this.wallCannon3;
        enemyArray[3] = this.wallCannon4;
        enemyArray[4] = this.wallCannon5;
        enemyArray[5] = this.wallCannon6;
        enemyArray[6] = this.wallCannon7;
        return enemyArray;
    }

    // Instantiates all of the cannon's in level 1 at specific spots.

    public void createWallCannon()
    {
        this.wallCannon1 = Instantiate(wallCannon, new Vector3(4f, 0.25f, 0), Quaternion.identity);
        this.wallCannon2 = Instantiate(wallCannon, new Vector3(10f, 0.25f, 0), Quaternion.identity);
        this.wallCannon3 = Instantiate(wallCannon, new Vector3(15f, 0.69f, 0), Quaternion.identity);
        this.wallCannon4 = Instantiate(wallCannon, new Vector3(22.5f, -0.45f, 0), Quaternion.identity);
        this.wallCannon5 = Instantiate(wallCannon, new Vector3(24.1f, 0.65f, 0), Quaternion.identity);
        this.wallCannon6 = Instantiate(wallCannon, new Vector3(31.01f, -0.1f, 0), Quaternion.identity);
        this.wallCannon7 = Instantiate(wallCannon, new Vector3(20f, 0.69f, 0), Quaternion.identity);
    }


}
