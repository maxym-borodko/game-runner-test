using UnityEngine;
using UnityEngine.UI;

public class StatsUpdate : MonoBehaviour
{
    //
    [SerializeField] Text coinsText;
    [SerializeField] Text levelText;
    [SerializeField] Canvas menuCanvas;

    //
    GameManager gameManager;

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    void Update()
    {
        coinsText.text = gameManager.GetCoins().ToString();
        levelText.text = "Level " + gameManager.GetLevel().ToString();
    }

    public void ShowMenu()
    {
        menuCanvas.gameObject.SetActive(true);
        gameManager.PauseGame();
    }

    public void Restart()
    {
        menuCanvas.gameObject.SetActive(false);
        gameManager.ResumeGame();
        gameManager.StartGame();
    }

    public void Resume()
    {
        menuCanvas.gameObject.SetActive(false);
        gameManager.ResumeGame();
    }

    public void QuitGame()
    {
        menuCanvas.gameObject.SetActive(false);
        gameManager.QuitGame();
    }
}
