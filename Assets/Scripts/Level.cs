using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    [SerializeField] int breakableBlocks = 0;

    //Będziemy ładować kolejny level jak klocków będzie zero.
    //Więc po to deklarujemy sceneloader.
    SceneLoader sceneLoader;

    //na starcie musimy zainicjalizować sceneloader.
    private void Start()
    {
        sceneLoader = FindObjectOfType<SceneLoader>();
    }

    public void CountBreakableBlocks()
    {
        breakableBlocks++;
    }

    //Na początku kodem u góry liczymy ile jest bloków.
    //Bo przy Start w Block.cs zliczamy.
    //Poniższa metoda jest przeciwieństwem.
    //Będziemy zmniejszać ilość bloków przy rozbiciu aż dojdzie do zera.
    //Jeśli dojdzie do zera to trzeba kolejny level załadować.

    public void BlockDestroyed()
    {
        breakableBlocks--;
        if (breakableBlocks <= 0)
        {
            sceneLoader.LoadNextScene();
        }
    }

}
