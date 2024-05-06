using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// custom event handler singleton
public class EventManager : MonoBehaviour
{
    public static EventManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    // events that can happen in the game
    public event Action BaitLanded;
    public event Action<float> BaitLaunched;
    public event Action FishCaught;

    public void OnBaitLanded()
    {
        BaitLanded?.Invoke();
    }

    public void OnBaitLaunched(float force)
    {
       BaitLaunched?.Invoke(force);
    }

    public void OnFishCaught()
    {
        FishCaught?.Invoke();
    }
}
