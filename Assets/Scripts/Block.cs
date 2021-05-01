using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    //Configuration parameters
    [SerializeField] AudioClip breakSound;
    [SerializeField] GameObject blockSparklesVFX;

    //ustalamy ile razy maksymalnie można walnąć w blok zanim się zniszczy całkiem.
    [SerializeField] int maxHits;

    //Cached references
    Level level;

    //State variables
    int timesHit;

    private void Start()
    {
        timesHit = 0; //Inicjalizujemy timesHit jako 0. Dla każdego bloku tak będzie.
        CountBreakableBlocks();
    }

    private void CountBreakableBlocks()
    {
        level = FindObjectOfType<Level>();
        if (tag == "Breakable")
        {
            level.CountBlocks();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position);
        if (tag == "Breakable")
        {
            HandleHit();
        }
    }

    private void HandleHit() //Refaktoryzacja. Obsługujemy uderzenie.
    {
        timesHit++; //Jak walniemy w breakable to zwiększamy timesHit o 1.
        if (timesHit >= maxHits) //Jesli blok zostanie walnięty maksymalną ilość razy, jest niszczony. Dla bezpieczeństwa lepiej dać >=
        {
            DestroyBlock();
        }
    }

    private void DestroyBlock()
    {
        FindObjectOfType<GameStatus>().AddToScore();
        Destroy(gameObject);
        level.BlockDestroyed();
        TriggerSparklesVFX();
    }

    private void TriggerSparklesVFX()
    {
        GameObject sparkles = Instantiate(blockSparklesVFX, transform.position, transform.rotation);
        Destroy(sparkles, 1f);
    }
}