using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] AudioClip breakSound;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Na kolizji, zanim zniszczymy obiekt robimy PlayClipAtPoint()
        //Tworzymy chwilowo AudioSource i wywołujemy metodę
        //PlayClipAtPoint z parametrem breakSound
        //A tam w Unity już pod to pole damy nasz sound.
        //Podajemy tutaj jako drugi parametr pozycję na scenie, z której pochodzi dźwięk.

        //OK. Chcemy słyszeć dźwięk tam gdzie mamy kamerę.
        //Możnaby dać z pozycji klocka, ale jak on jest dalej to dźwięk byłby cichszy.
        //Dlatego zamiast transform x i y czyli miejsca klocka robimy Camera.main.transform bo z kamery chcemy słuchać
        //Tym właśnie odwołujemy się do pozycji kamery! Głównej kamery. Nie mamy teraz innych
        AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position);
        Destroy(gameObject);
    }

}