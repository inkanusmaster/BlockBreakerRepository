using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    //Configuration parameters
    [SerializeField] AudioClip breakSound;
    [SerializeField] GameObject blockSparklesVFX;
    [SerializeField] Sprite[] hitSprites;
    int maxHits;

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
        maxHits = hitSprites.Length + 1; //Zmieniamy tutaj statyczny wpis ilości maxHits. Wiemy, że jest on o 1 większy niż ilość spritów w tablicy.
        if (timesHit >= maxHits)
        {
            DestroyBlock();
        }
        else
        {
            ShowNextHitSprite();
        }
    }

    private void ShowNextHitSprite()
    {
        int spriteIndex = timesHit - 1;
        if (hitSprites[spriteIndex] != null)  //Sprawdzamy czy element do którego chcemy się odwołać jest w ogóle...
        {
            GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
        }
        else
        {
            Debug.LogError("Missing sprite from array!" + gameObject.name); //Logujemy co się stanie jak będziemy chcieli odwołać się do spritea którego nie ma w tablicy. Nazwę GameObjectu podajemy.
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