using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] Paddle paddle;
    Vector2 paddleToBallVector;
    bool hasStarted;

    //Przy kliknięciu mamy xVelocity, czyli jak bardzo na prawo (czy lewo jak ujemne) wybije nam piłka/
    //yVelocity mówi nam jak wysoko wystrzeli piłka.
    [SerializeField] float xVelocity = 2f;
    [SerializeField] float yVelocity = 15f;


    void Start()
    {
        paddleToBallVector = transform.position - paddle.transform.position;
        hasStarted = false;

    }

    void Update()
    {
        //Trzymamy piłkę na paddlu, oraz gdy raz już klikniemy i piłka leci, to przy ponownym kliknięciu nie startuje znowu.
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
        //Czyli jeśli wciśnięto pierwszy klawisz myszy
        if (Input.GetMouseButtonDown(0))
        {
            //Musimy mieć dostęp do komponentu rigidbody piłki.
            //ustawiamy prędkość piłki. 
            //Posiada współrzędne x i y więc robimy to jako Vector2
            //ten GetComponent z parametrem Rigidbody2D dostaje się to komponentu w inspektorze. Tam jest Velocity
            GetComponent<Rigidbody2D>().velocity = new Vector2(xVelocity, yVelocity);

            //Robimy true, żeby piłka odleciała i już nie trzymała się paddla
            hasStarted = true;
        }
    }

}
