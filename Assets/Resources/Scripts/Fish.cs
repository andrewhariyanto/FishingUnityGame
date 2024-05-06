using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish : MonoBehaviour
{
    private Rigidbody rb;
    private Vector2 _velocity;
    private float _gravity = -9.8f;

    private void Awake()
    {
        rb = this.GetComponent<Rigidbody>();
    }

    private void Start()
    {
        EventManager.instance.BaitLaunched += LaunchBait;
        rb.isKinematic = true;
        this.gameObject.SetActive(false);
    }

    private void LaunchBait(float velocity)
    {
        this.gameObject.SetActive(true);
        this.transform.position = new Vector3(-3.34f, 4.99f, -0.76f);
        _velocity = new Vector2(velocity, velocity);
    }

    private void FixedUpdate()
    {
        float x = _velocity.x * Time.deltaTime;
        float y = _velocity.y * Time.deltaTime + _gravity / 2 * Mathf.Pow(Time.deltaTime, 2);
        _velocity.y += _gravity / 2 * Time.deltaTime;
        rb.MovePosition(this.transform.position + new Vector3(x, y, 0));
    }

    private void OnCollisionEnter(Collision info)
    {
        if (info.gameObject.CompareTag("Water"))
        {
            EventManager.instance.OnBaitLanded();
            StartCoroutine(StartTimer());
            
        }
    }

    private void OnDestroy()
    {
        EventManager.instance.BaitLaunched -= LaunchBait;
    }

    private IEnumerator StartTimer()
    {
        yield return new WaitForSeconds(3);
        EventManager.instance.OnFishCaught();
        this.gameObject.SetActive(false);
    }
}
