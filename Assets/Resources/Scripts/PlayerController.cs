using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public PlayerStateMachine StateMachine;
    public PlayerInput playerInput;
    public Animator animator;
    public GameObject fish;
    private float power;
    private bool fishCaught;
    private int _score;
    

    private void Awake()
    {
        StateMachine = new PlayerStateMachine(this, animator, playerInput);
    }
    // Start is called before the first frame update
    void Start()
    {
        StateMachine.Initialize(StateMachine.idleState);
    }

    // Update is called once per frame
    void Update()
    {
        StateMachine.Update();
    }

    public void IncreasePower()
    {
        if(power <= 4)
        {
            power += 1 * Time.deltaTime;
            UIManager.instance.UpdateMeter(power);
        }
    }

    // signals taht a fish was caught
    public void GivePoint()
    {
        fishCaught = true;
        fish.SetActive(true);
    }

    // increases point if a fish was caught
    public void IncreasePoint()
    {
        if (fishCaught)
        {
            _score += 1;
            UIManager.instance.UpdateScore(_score);
        }
    }

    // resets variables to default values
    public void Reset()
    {
        fishCaught = false;
        fish.SetActive(false);
        power = 2;
    }

    // signals when to launch the bait according to the character animation
    public void LaunchBait()
    {
        EventManager.instance.OnBaitLaunched(power);
    }

    public void AnimationTrigger()
    {
        StateMachine.AnimationTrigger();
    }
}
