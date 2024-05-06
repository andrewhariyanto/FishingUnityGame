using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// state responsible for charging the cast
public class ChargingState : IState
{
    private PlayerController _player;
    private PlayerInput _input;
    private bool _alreadyHeld = false;
    private bool _isAnimationDone = false;
    private Animator _anim;

    public ChargingState(PlayerController player, Animator anim, PlayerInput input)
    {
        _player = player;
        _anim = anim;
        _input = input;
    }

    public void Enter()
    {
        Debug.Log("Entering charging state");
        _isAnimationDone = false;
        _anim.SetBool("Charging", true);
        _alreadyHeld = false;
        UIManager.instance.ShowMeter();
    }

    public void Exit()
    {
        Debug.Log("Exiting charging state");
        _anim.SetBool("Charging", false);
        UIManager.instance.HideMeter();
    }

    public void Update()
    {
        // increase force when held down but transitions to casting state otherwise
        if (_input.buttonHeld && !_alreadyHeld)
        {
            _player.IncreasePower();
        }
        else
        {
            _alreadyHeld = true;
            // only go to the cast state when animation is finished
            if (_isAnimationDone)
                _player.StateMachine.TransitionTo(_player.StateMachine.castingState);
        }
    }

    // Fires when animation finishes
    public void AnimationTrigger()
    {
        _isAnimationDone = true;
    }
}
