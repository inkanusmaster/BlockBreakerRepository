using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStatus : MonoBehaviour
{
    [Range(0.1f, 5f)] [SerializeField] float gameSpeed = 1f;

    //Wybieramy ile punktów za zniszczony blok.
    [SerializeField] int pointsPerBlockDestroyed = 2;

    //Inicjalizujemy obecny score jako 0. 
    //Robimy to po to żeby po resecie zawsze wynosił zero.
    [SerializeField] int currentScore = 0;

    void Update()
    {
        Time.timeScale = gameSpeed;
    }

    //Dodawanie punktów. Chyba oczywiste.
    //Będziemy to robić po zbiciu klocka.
    public void AddToScore()
    {
        currentScore += pointsPerBlockDestroyed;
    }


}
