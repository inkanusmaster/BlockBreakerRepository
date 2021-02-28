using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    //Serializujemy dla celów debugowych
    [SerializeField] int breakableBlocks = 0;

    //Metoda zliczająca bloki na planszy
    //Za każdym razem gdy ta metoda będzie wykonana, dodajemy 1 blok do breakableBlocks
    public void CountBreakableBlocks()
    {
        breakableBlocks++;
    }

}
