using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Potrzebujemy tego na dole bo chcemy wczytać scenę gameover po kolizji z dołem mapy
using UnityEngine.SceneManagement;

public class LoseCollider : MonoBehaviour
{

    //Będzie obsługiwał wydarzenie przy wejściu w kolizję
    //Czyli będzie się odpalała scena z game over.
    private void OnTriggerEnter2D(Collider2D collision)
    {
        SceneManager.LoadScene("GameOver");
    }
}
