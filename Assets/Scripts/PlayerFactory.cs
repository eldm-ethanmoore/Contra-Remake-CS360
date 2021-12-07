using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFactory : AbstractFactory
{

    // Declares Player, Sprite gameobjects, and EnemyFactory wallCannon.

    public GameObject Player;
    public EnemyFactory wallCannon;
    public GameObject MidAirLanceBean;

    void Start()
    {

        // Initializes Gameobjects

        GameObject Player = GameObject.Find("Player");
        this.Player = Player;
        GameObject MidAirLanceBean = GameObject.Find("MidAirLanceBean");
        this.MidAirLanceBean= MidAirLanceBean;
        createPlayer();

    }

    void Update()
    {
        notify();    
    }

    // Getter for player.
    // Instantiates Player Gameobject.

    public GameObject GetPlayer(string player)
    {
        return Player;
    }

    public void createPlayer()
    {
        this.Player = Instantiate(this.Player, new Vector3(-1.772f, 1.053f, 0), Quaternion.identity);
    }
    public GameObject getPlayer(string player)
    {
        return this.Player;
    }
    public void notify()
    {

    }
}
