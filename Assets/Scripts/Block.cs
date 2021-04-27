using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] AudioClip breakSound;

    //Robimy zmienną do naszego particle effect. To typ GameObject
    [SerializeField] GameObject blockSparklesVFX;

    Level level;

    private void Start()
    {
        level = FindObjectOfType<Level>();
        level.CountBreakableBlocks();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        DestroyBlock();
    }

    private void DestroyBlock()
    {
        FindObjectOfType<GameStatus>().AddToScore();
        AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position);
        Destroy(gameObject);
        level.BlockDestroyed();
        TriggerSparklesVFX();
    }

    //Metoda, która wyzwala nasz efekt sparkle.
    private void TriggerSparklesVFX()
    {
        //Robimy instantiate naszego sparkla. Taki najprostszy, bo ma z 10 różnych opcji parametrów.
        //Czyli tak jakby sklonowaliśmy blockSparklesVFX, zrobiliśmy jego instancję.
        //Pamiętamy, ze chcemy aby sparkle był w bloku, w który przywalimy.
        //transform.position mówi nam "tu gdzie jesteśmy w tym momencie", a transform.rotation "tu gdzie jesteś rotowany w tym momencie (lol)".
        //Czyli robi instancję blockSparklesVFX, która zawiera efekt VFX nadany w inspektorze. Wywoła się to "w tym momencie w tym miejscu" przy uderzeniu bloku, bo takie mamy parametry i będziemy wywoływać tę metodę przy uderzeniu w blok...
        GameObject sparkles = Instantiate(blockSparklesVFX, transform.position, transform.rotation);

        //Niszczymy po 1 sekundzie tę instancję, bo zawali nam Hierarchy i się rozrośnie program...
        Destroy(sparkles, 1f);
    }
}