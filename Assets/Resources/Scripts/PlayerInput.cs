using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// class is responsible for getting player input
public class PlayerInput : MonoBehaviour
{
    public bool buttonPressed = false;
    public bool buttonHeld = false;
    public bool buttonReleased = false;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            buttonPressed = true;
        } else if (Input.GetMouseButton(0))
        {
            buttonHeld = true;
        } else if (Input.GetMouseButtonUp(0))
        {
            buttonReleased = true;
        }
        else
        {
            buttonPressed = false;
            buttonHeld = false;
            buttonReleased = false;
        }
    }
}
