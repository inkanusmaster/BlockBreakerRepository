using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameStatus : MonoBehaviour
{
    [Range(0.1f, 5f)] [SerializeField] float gameSpeed = 1f;
    [SerializeField] int pointsPerBlockDestroyed = 2;
    [SerializeField] int currentScore = 0;
    [SerializeField] TextMeshProUGUI scoreText;

    private void Awake()
    {
        int gameStatusCount = FindObjectsOfType<GameStatus>().Length;

        if (gameStatusCount > 1)
        {
            //pamiętamy żeby przed zniszczeniem w Singleton zrobić SetActive(false).
            //Chodzi o to, ze Destroy dzieje się na końcu frame - nawiązując do lifecycle
            //To oznacza, że inny obiekt ciągle może znaleźć GameStatus używając FindObjectOfType i mamy bug.
            //Zorbienie obiektu inactive dzieje się natychmiastowo więc jest bezpiecznie żeby to zrobić przed usunięciem na końcu framea.
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Start()
    {
        scoreText.text = currentScore.ToString();
    }

    void Update()
    {
        Time.timeScale = gameSpeed;
    }

    public void AddToScore()
    {
        currentScore += pointsPerBlockDestroyed;
        scoreText.text = currentScore.ToString();
    }


}
