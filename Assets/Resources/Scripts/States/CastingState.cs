using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastingState : IState
{
    private PlayerController _player;

    public CastingState(PlayerController player)
    {
        _player = player;
    }

    public void Enter()
    {
        Debug.Log("Entering casting state");
    }

    public void Exit()
    {
        Debug.Log("Exiting casting state");
    }

    public void Update()
    {
        if (_player.released)
        {

        }
    }
}
