using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //
    [SerializeField] int numberOfCoinsForNextLevel = 50;
    [SerializeField] int coinsPerLevelIncrement = 50; // absolute value
    [SerializeField] int startMaxNumberOfCoins = 4; // TODO: implement decreasing with levels up
    [SerializeField] int startMaxNumberOfObstacles = 1; // TODO: implement increasing with levels up

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
    }

    public int GetCoins()
    {
        return coins;
    }

    public int GetLevel()
    {
        return level;
    }

    public int GetMaxNumberOfCoins()
    {
        return startMaxNumberOfCoins;
    }

    public int GetMaxNumberOfObstacles()
    {
        return startMaxNumberOfObstacles;
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
        ResetValues();
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
    }

    public void FinishGame()
    {
        SceneManager.LoadScene(2);
    }

    void IncreaseLevel()
    {
        level++;
        numberOfCoinsForNextLevel += coinsPerLevelIncrement;
        speed += speed * speedPerLevelIncrement;
    }

    void ResetValues()
    {
        coins = 0;
        level = 1;
    }
}
