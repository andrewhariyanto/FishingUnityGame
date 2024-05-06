using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// default state for player
public class IdleState : IState
{
    private PlayerController _player;
    private PlayerInput _input;
    private Animator _anim;


    public IdleState(PlayerController player, Animator anim, PlayerInput input)
    {
        _player = player;
        _anim = anim;
        _input = input;
    }

    public void Enter()
    {
        Debug.Log("Entering idle state");
        _player.Reset();
        _anim.SetBool("Idle", true);
    }

    public void Exit()
    {
        Debug.Log("Exiting idle state");
        _anim.SetBool("Idle", false);
    }

    public void Update()
    {
        // transition to charging state if button is pressed
        if (_input.buttonPressed)
        {
            _player.StateMachine.TransitionTo(_player.StateMachine.chargingState);
        }
    }

    public void AnimationTrigger()
    {
        // N/A
    }
}
