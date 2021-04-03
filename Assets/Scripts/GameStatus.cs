using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Do punktacji na ekranie. Bo tam mamy TextMeshPro.
using TMPro;

public class GameStatus : MonoBehaviour
{
    [Range(0.1f, 5f)] [SerializeField] float gameSpeed = 1f;
    [SerializeField] int pointsPerBlockDestroyed = 2;
    [SerializeField] int currentScore = 0;

    //Nasza punktacja co będzie na ekranie
    [SerializeField] TextMeshProUGUI scoreText;

    //Robimy Start jednak. 
    //Będzie zawierał inicjalizację score.
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
