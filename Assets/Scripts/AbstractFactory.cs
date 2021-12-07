using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbstractFactory : FactoryProducer 
{

    // Declares Scripts for the enemy and player factory

    PlayerFactory PlayerFactoryScript;
    EnemyFactory EnemyFactoryScript;
    // Start is called before the first frame update
    void Start()
    {
        // Calls Factory Method

        GetFactory("Lance Bean", "Wall Cannon");
    }
    
    // GetFactory method initilizes the script objects of type PlayerFactory and EnemyFactory

    public void GetFactory(string player, string enemy)
    {
        GameObject PlayerFactoryScript = GameObject.Find("PlayerFactory");
        this.PlayerFactoryScript = PlayerFactoryScript.GetComponent<PlayerFactory>();
        GameObject EnemyFactoryScript = GameObject.Find("EnemyFactory");
        this.EnemyFactoryScript = EnemyFactoryScript.GetComponent<EnemyFactory>();
    }
}
