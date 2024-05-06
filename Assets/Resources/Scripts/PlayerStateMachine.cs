using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// State machine class
public class PlayerStateMachine { 
    public IState CurrentState { get; private set; }

    // references to state objects
    public IdleState idleState;
    public ChargingState chargingState;
    public CastingState castingState;
    public WaitingState waitingState;
    public ReelingState reelingState;

    // event to notify other objects of the state change
    public event Action<IState> stateChanged;

    public PlayerStateMachine(PlayerController player, Animator anim, PlayerInput input)
    {
        // Create instance for each state and pass in player controller
        idleState = new IdleState(player, anim, input);
        chargingState = new ChargingState(player, anim, input);
        castingState = new CastingState(player, anim, input);
        waitingState = new WaitingState(player, anim, input);
        reelingState = new ReelingState(player, anim, input);
    }

    // Initializes state to default state
    public void Initialize(IState state)
    {
        CurrentState = state;
        state.Enter();

        stateChanged?.Invoke(state);
    }
    
    // Handles transitions to next state
    public void TransitionTo(IState nextState)
    {
        CurrentState.Exit();
        CurrentState = nextState;
        nextState.Enter();

        stateChanged?.Invoke(nextState);
    }

    // Runs the update loop by delegating it to the current state
    public void Update()
    {
        if (CurrentState != null)
        {
            CurrentState.Update();
        }
    }

    // Triggers any end of animation events
    public void AnimationTrigger()
    {
        CurrentState.AnimationTrigger();
    }
}