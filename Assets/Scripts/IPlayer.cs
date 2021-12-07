using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPlayer
{

    // Interface for the Player script to specify available methods.
    
    void createPlayer();
    void notify();
    GameObject getPlayer(string player);
}

