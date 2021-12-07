using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrameRate : MonoBehaviour
{
    // Prints framerate.

    void Start()
    {
        print(1.0f / Time.deltaTime);
    }

    void Update()
    {
        print(1.0f / Time.deltaTime);
    }
}





















