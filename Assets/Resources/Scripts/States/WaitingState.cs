using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// state where character is waiting for fish to bite
public class WaitingState : IState
{
    private PlayerController _player;
    private PlayerInput _input;
    private bool _fishCaught;
    private Animator _anim;

    public WaitingState(PlayerController player, Animator anim, PlayerInput input)
    {
        _player = player;
        _anim = anim;
        _input = input;
    }

    public void Enter()
    {
        Debug.Log("Entering waiting state");
        EventManager.instance.FishCaught += OnFishCaught;
        _fishCaught = false;
        _anim.SetBool("Waiting", true);
    }

    public void Exit()
    {
        Debug.Log("Exiting waiting state");
        EventManager.instance.FishCaught -= OnFishCaught;
        _anim.SetBool("Waiting", false);
    }

    public void Update()
    {
        if (_input.buttonPressed)
        {
            // if fish is caught, give point to character, otherwise don't give point
            if (_fishCaught)
            {
                _player.GivePoint();
                UIManager.instance.HideIcon();
            }
            
            _player.StateMachine.TransitionTo(_player.StateMachine.reelingState);
        }
    }

    public void AnimationTrigger()
    {

    }

    // show icon that fish has been caught
    private void OnFishCaught()
    {
        _fishCaught = true;
        UIManager.instance.ShowIcon();
    }
}
