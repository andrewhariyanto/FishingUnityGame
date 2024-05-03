using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    public PlayerStateMachine(PlayerController player)
    {
        // Create instance for each state and pass in player controller
        idleState = new IdleState(player);
        chargingState = new ChargingState(player);
        castingState = new CastingState(player);
        waitingState = new WaitingState(player);
    }

    public void Initialize(IState state)
    {
        CurrentState = state;
        state.Enter();

        stateChanged?.Invoke(state);
    }
    
    public void TransitionTo(IState nextState)
    {
        CurrentState.Exit();
        CurrentState = nextState;
        nextState.Enter();

        stateChanged?.Invoke(nextState);
    }

    public void Update()
    {
        if (CurrentState != null)
        {
            CurrentState.Update();
        }
    }
}