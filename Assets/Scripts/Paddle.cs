using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    //Config params
    [SerializeField] float screenWidthInUnits = 16f;
    [SerializeField] float minX = 1.5f;
    [SerializeField] float maxX = 14.5f;

    //Cached references
    //Refaktoryzacja.
    //Nie chcemy robić FindObjectOfType za każdym updatem frame.
    //Więc wcześniej te zmienne deklarujemy i inicjalizujemy.
    GameStatus gameStatus;
    Ball ball;

    //Inicjalizacja ww zmiennych
    private void Start()
    {
        gameStatus = FindObjectOfType<GameStatus>();
        ball = FindObjectOfType<Ball>();
    }

    void Update()
    {
        Vector2 paddlePosition = new Vector2(transform.position.x, transform.position.y);

        //To przypisanie mówi nam, że pozycja paddla - x jest taka jak pozycja myszy.
        //Jeśli chcemy aby pozycja paddla była taka jak piłka, musimy zmienić mousePositionInUnits na aktualną pozycję piłki.
        //To do autotestu oczywiście.
        //Więc dajemy GetXPos(). Metoda zwraca pozycję x - float. Tylko zależy czy to położenie myszy, czy piłki,
        //Czyli czy autoplay jest włączony czy nie.
        paddlePosition.x = Mathf.Clamp(GetXPos(), minX, maxX);

        transform.position = paddlePosition;
    }

    //Metoda będzie nam zwracać pozycję x paddla.
    //W zależności czy jest autoplay - śledzi piłkę, czy nie jest autoplay i śledzi mysz.
    private float GetXPos()
    {
        if (gameStatus.IsAutoPlayEnabled())
        {
            //Zwraca pozycję x obiektu Ball.
            return ball.transform.position.x;
        }
        else
        {
            //Pozycja myszy. Było to wcześniej w metodzie Update().
            return Input.mousePosition.x / Screen.width * screenWidthInUnits;
        }
    }
    //DO PRZEMYŚLENIA TO POŁĄCZENIE GETXPOS I UPDATE.
}
