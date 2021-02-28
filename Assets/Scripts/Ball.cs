using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] Paddle paddle;
    Vector2 paddleToBallVector;
    bool hasStarted;

    [SerializeField] float xVelocity = 2f;
    [SerializeField] float yVelocity = 15f;

    [SerializeField] AudioClip[] ballSounds;

    AudioSource myAudioSource;


    void Start()
    {
        paddleToBallVector = transform.position - paddle.transform.position;
        hasStarted = false;
        myAudioSource = GetComponent<AudioSource>();

    }

    void Update()
    {
        if (!hasStarted)
        {
            LockBallToBaddle();
            LaunchOnClick();
        }
    }

    private void LockBallToBaddle()
    {
        Vector2 paddlePosition = new Vector2(paddle.transform.position.x, paddle.transform.position.y);
        transform.position = paddlePosition + paddleToBallVector;
    }

    private void LaunchOnClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(xVelocity, yVelocity);
            hasStarted = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (hasStarted)
        {
            AudioClip clip = ballSounds[UnityEngine.Random.Range(0, ballSounds.Length)];
            myAudioSource.PlayOneShot(clip);
        }
    }

}
