using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] AudioClip breakSound;

    //Referencja do Level
    Level level;

    private void Start()
    {
        //Szukamy obiektu typu Level i przypisujemy go pod zmienną level.
        //Zwraca pierwszy aktywny załadowany obiekt danego typu.
        //Ten typ nie zwraca assetów, ani nieaktywnych obiektów, tylko aktywne GameObjecty.
        //Ale po co? Ta funkcja działa wolno. Chyba jako ciekawostka to?
        //Musi to być. Bez tego nie zlicza.
        //Wydaje mi się, że wyszukuje ten pierwszy aktywny obiekt, tutaj Level
        //i każdy blok odnosi się właśnie to tego samego Levelu
        //i każdy blok przy tworzeniu robi dzięki temu inkrementację w tym samym Levelu
        level = FindObjectOfType<Level>();

        //Zliczamy. Przy tworzeniu każdego klocka wykonuje się metoda Start() i level.CountBreakableBlocks().
        level.CountBreakableBlocks();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position);
        Destroy(gameObject);
    }

}