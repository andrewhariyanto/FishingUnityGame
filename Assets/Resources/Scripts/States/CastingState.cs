using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// state where the character launches the bait
public class CastingState : IState
{
    private PlayerController _player;
    private bool _isAnimationDone = false;
    private bool _baitLanded;
    private Animator _anim;
    private PlayerInput _input;

    public CastingState(PlayerController player, Animator anim, PlayerInput input)
    {
        _player = player;
        _anim = anim;
        _input = input;
    }

    public void Enter()
    {
        Debug.Log("Entering casting state");
        _anim.SetBool("Cast", true);
        EventManager.instance.BaitLanded += OnBaitLanded;
        _baitLanded = false;
        _isAnimationDone = false;
        
    }

    public void Exit()
    {
        Debug.Log("Exiting casting state");
        EventManager.instance.BaitLanded -= OnBaitLanded;
        _anim.SetBool("Cast", false);
    }

    public void Update()
    {
        // wait until animation finishes and bait lands in the water before transitioning
        // to waiting state
        if (_isAnimationDone && _baitLanded)
        {
            _player.StateMachine.TransitionTo(_player.StateMachine.waitingState);
        }
    }

    public void AnimationTrigger()
    {
        _isAnimationDone = true;
    }

    private void OnBaitLanded()
    {
        _baitLanded = true;
    }
}
