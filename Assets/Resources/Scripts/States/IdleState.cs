using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : IState
{
    private PlayerController _player;

    public IdleState(PlayerController player)
    {
        _player = player;
    }

    public void Enter()
    {
        Debug.Log("Entering idle state");
    }

    public void Exit()
    {
        Debug.Log("Exiting idle state");
    }

    public void Update()
    {
        if (_player.charging)
        {
            _player.StateMachine.TransitionTo(_player.StateMachine.chargingState);
        }
    }
}
