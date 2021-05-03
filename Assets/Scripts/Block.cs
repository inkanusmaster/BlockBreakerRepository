using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    //Configuration parameters
    [SerializeField] AudioClip breakSound;
    [SerializeField] GameObject blockSparklesVFX;
    [SerializeField] int maxHits;

    //Robimy tablicę Spritów. Będziemy do niej wczytywać sprity zawierające poziomy zniszczeń bloku.
    //Normalna rzecz. SerializedField poniewać inicjalizujemy to elegancko w inspektorze.
    [SerializeField] Sprite[] hitSprites;

    //Cached references
    Level level;

    //State variables
    int timesHit;

    private void Start()
    {
        timesHit = 0;
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

    private void HandleHit()
    {
        timesHit++;
        if (timesHit >= maxHits)
        {
            DestroyBlock();
        }
        else
        {
            //Będziemy pokazywać kolejny sprite po uderzeniu. Refaktoryzacja!
            ShowNextHitSprite();
        }
    }

    //Trzeba będzie zmieniać sprite po uderzeniu!
    private void ShowNextHitSprite()
    {
        //Indexujemy od zera, więc jak trafimy w blok to elementy tablicy spritów iterujemy od zera.
        int spriteIndex = timesHit - 1;

        //Jesteśmy w prefabie blok. Ustawiamy w jego zakładce Sprite Renderer jako aktualny sprite ten nadany z tablicy spritów.
        //Proste
        GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
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