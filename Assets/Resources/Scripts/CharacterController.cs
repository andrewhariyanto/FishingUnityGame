using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public enum States {
        Idle,
        Casting,
        Release,
        Waiting,
        Reeling
    }

    [SerializeField]
    Animator _anim;

    private bool _buttonDown;
    private float _power;
    private States _state;
    private bool _baitCast;
    private bool _fishCaught;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        switch (_state)
        {
            case States.Idle:
                // Press to trigger casting state
                bool buttonDown = Input.GetMouseButtonDown(0);
                if (buttonDown)
                {
                    _anim.SetTrigger("StartWindup");
                    _state = States.Casting;
                }
                break;
            case States.Casting:
                bool buttonHeld = Input.GetMouseButton(0);
                bool buttonReleased = Input.GetMouseButtonUp(0);
                if (buttonReleased)
                {
                    _state = States.Release;
                }
                else if (buttonHeld)
                {
                    _power += 1 * Time.deltaTime;
                }
                break;
            case States.Release:
                _anim.SetTrigger("StartRelease");
                _state = States.Waiting;
                break;
            case States.Waiting:
                if (!_baitCast)
                {
                    _baitCast = !_baitCast;
                    StartCoroutine(FishBite());
                }                   
                break;
            case States.Reeling:
                bool buttonClicked = Input.GetMouseButtonDown(0);
                if (buttonClicked)
                {
                    _anim.SetBool("FishCaught", true);
                }

                if (_anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && _anim.GetCurrentAnimatorStateInfo(0).IsName("Reel"))
                {
                    _anim.SetTrigger("BackToIdle");
                    _state = States.Idle;
                }
                break;
            default:
                break;
        }
        if (Input.GetMouseButton(0))
        {

        }
        // Controls: hold down to charge fishing rod
        if (!_buttonDown)
        {

        }
    }

    private IEnumerator FishBite()
    {
        yield return new WaitForSeconds(3f);
        _state = States.Reeling;
        _baitCast = !_baitCast;
        _fishCaught = true;
    }
}
