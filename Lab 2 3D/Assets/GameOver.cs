using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    [SerializeField] public GameObject gameOverCanvas;
    [SerializeField] public Button restartButton;

    void Start()
    {
        restartButton.onClick.AddListener(RestartGame);
    }

    public void ShowGameOver()
    {
        gameOverCanvas.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
    }

    public void RestartGame()
    {
        PlayerHealthDataStore.getInstance().reset();
        GameTimeStore.getInstance().resetTimer();
        Cursor.lockState = CursorLockMode.Locked;
        gameOverCanvas.SetActive(false);
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void OnTryAgainClicked()
    {
        RestartGame();
    }


}
