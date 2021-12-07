using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FactoryProducer : MonoBehaviour
{

    // Declares AbstractFactory.

    AbstractFactory AbstractFactoryScript;

    void Start()
    {

        // Initializes AbstractFactory and calls the GetFactory method.

        GameObject AbstractFactoryScript = GameObject.Find("AbstractFactory");
        this.AbstractFactoryScript = AbstractFactoryScript.GetComponent<AbstractFactory>();
        this.AbstractFactoryScript.GetFactory("Lance Bean", "Wall Cannon");
    }

}
