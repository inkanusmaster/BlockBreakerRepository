using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStatus : MonoBehaviour
{
    //Zmienna z prędkością. Będziemy mogli w inspektorze Unity suwakiem przesuwać.
    //Ten suwak trzeba oczywiście zrobić z odpowiednimi wartościami min i max.
    //Robimy go Range(min,max) przed deklaracją serializowanego pola.
    [Range(0.1f, 5f)] [SerializeField] float gameSpeed = 1f;

    void Start()
    {

    }

    //Prędkość gry to coś co sprawdzamy every frame.
    //Dlatego będzie w Update.
    //Wartości są zmiennoprzecinkowe, więc robimy float.
    //1 oznacza normalną prędkość.
    void Update()
    {
        Time.timeScale = gameSpeed;
    }
}
