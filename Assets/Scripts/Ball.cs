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

    //Tablica dźwięków którą będziemy w Unity wypełniać
    [SerializeField] AudioClip[] ballSounds;

    //Robimy sobie referencję do komponentu AudioSource tutaj.
    //Nie chcemy za każdym razem przy kolizji robić deklaracji i inicjalizacji.
    AudioSource myAudioSource;


    void Start()
    {
        paddleToBallVector = transform.position - paddle.transform.position;
        hasStarted = false;

        //Inicjalizujemy sobie zmienną myAudioSource;
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
            //Robimy losowy klip z tablicy ballSounds.
            //Uwaga na typ random. Robimy UnityEngine.Random.
            //Nie robimy length-1 bo Range jak pamiętamy z poprzednich tematów nie robi do Max tylko Max-1 (jest exclusive).
            AudioClip clip = ballSounds[UnityEngine.Random.Range(0, ballSounds.Length)];

            //Użyjemy PlayOneShot. Pozwala dźwiękowi dobrzmieć do końca gdy zmieni się nagle Audio Source na inne.
            //Zmienną sobie na początku zadeklarowaliśmy i w starcie zainicjalizowaliśmy.
            myAudioSource.PlayOneShot(clip);
        }
    }

}
