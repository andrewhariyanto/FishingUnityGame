using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// state that handles reeling fish in
public class ReelingState : IState
{
    private PlayerController _player;
    private bool _isAnimationDone = false;
    private Animator _anim;
    private PlayerInput _input;

    public ReelingState(PlayerController player, Animator anim, PlayerInput input)
    {
        _player = player;
        _anim = anim;
        _input = input;
    }

    public void Enter()
    {
        Debug.Log("Entering reeling state");
        _isAnimationDone = false;
        _anim.SetBool("Reel", true);
    }

    public void Exit()
    {
        Debug.Log("Exiting reeling state");
        _anim.SetBool("Reel", false);
    }

    public void Update()
    {
        // only transition when animation is done
        if (_isAnimationDone)
        {
            _player.IncreasePoint();
            _player.StateMachine.TransitionTo(_player.StateMachine.idleState);
        }
    }

    public void AnimationTrigger()
    {
        _isAnimationDone = true;
    }
}
