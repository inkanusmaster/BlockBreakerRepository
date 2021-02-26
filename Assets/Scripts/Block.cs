using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Będziemy chcieli niszczyć nasz blok kiedy wystąpi kolizja
//Nie potrzebujemy tu Start ani Update
//Tylko wywołania czegoś gdy wystąpi kolizja.
public class Block : MonoBehaviour
{
    //Czyli mamy metodę wywołaną przy kolizji.
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //parametr z małej gameObject jest wykrywalny jako parametr
        //oznacza ten objekt. Ten do którego przypniemy ten skrypt.
        //może przyjąć drugi parametr we floacie, po jakim czasie ma być zniszczony.
        Destroy(gameObject);

        //A tutaj, jako że mamy parametr collision,
        //możemy np sobie wyświetlić informacje co się dzieje z tym collision
        //to poniżej wyświetli nam nazwę tego, co się z nami zderzyło, czyli Ball.
        Debug.Log(collision.gameObject.name);
    }

}