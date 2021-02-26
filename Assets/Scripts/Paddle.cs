using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    [SerializeField] float screenWidthInUnits = 16f;

    //Pola minX i maxX, które będą ograniczały ruch paddla.
    //Robimy je serialized bo chcemy w inspektorze.
    //przesuń sobie paddla i zobacz jakie wartości ustawić
    [SerializeField] float minX = 1.5f;
    [SerializeField] float maxX = 14.5f;

    void Start()
    {
    }
    void Update()
    {
        float mousePositionInUnits = Input.mousePosition.x / Screen.width * screenWidthInUnits;

        //troszkę zmieniamy. Teraz x i y to jest to co wyciągnięte z Transform -> Position 
        Vector2 paddlePosition = new Vector2(transform.position.x, transform.position.y);

        //będzie zmieniana nasza wartość mousePositionInUnits ale może być pomiędzy min i max
        //tutaj ustawiamy x więc ta linijka wyżej, parametr transform.position.x będzie brany z tego co tu poniżej ustawimy
        paddlePosition.x = Mathf.Clamp(mousePositionInUnits, minX, maxX);

        //zapisujemy paddlePosition do transform.position
        transform.position = paddlePosition;

    }
}
