using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    //
    [SerializeField] Text coinsLabel;

    //
    int coins = 0;

    public void AddCoin()
    {
        coins += 1;
        UpdateText();
    }

    private void UpdateText()
    {
        coinsLabel.text = coins.ToString();
    }

    public void StartGame()
    {
        coins = 0;
    }

    public void FinishGame()
    {
        coins = 0;
    }
}
