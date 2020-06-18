using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    //
    [SerializeField] Text coinsText;
    [SerializeField] Text levelText;

    //
    [SerializeField] int numberOfCoinsForNextLevel = 50;
    [SerializeField] int coinsPerLevelIncrement = 50; // absolute value

    //
    public float speed = 8f;

    [Range(0, 3)]
    [SerializeField] float speedPerLevelIncrement = 0.05f; // coeficient value

    //
    int coins = 0;
    int level = 1;


    public void AddCoin()
    {
        coins += 1;

        if (coins == numberOfCoinsForNextLevel)
        {
            IncreaseLevel();
        }

        UpdateText();
    }

    private void UpdateText()
    {
        coinsText.text = coins.ToString();
        levelText.text = "Level " + level.ToString();
    }

    public void StartGame()
    {
        ResetValues();
    }

    public void FinishGame()
    {
        ResetValues();
    }

    void IncreaseLevel()
    {
        level++;
        numberOfCoinsForNextLevel += coinsPerLevelIncrement;
        speed += speed * speedPerLevelIncrement;

        ShowNextLevel();
    }

    void ShowNextLevel()
    {

    }

    void ResetValues()
    {
        coins = 0;
        level = 1;
    }
}
