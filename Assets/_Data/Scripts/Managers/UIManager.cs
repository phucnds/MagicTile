using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour, IGameStateListener
{
    [SerializeField] private GameObject menuPanel;
    [SerializeField] private GameObject gamePanel;
    [SerializeField] private GameObject popupGameOver;
    [SerializeField] private GameObject popupCompleted;

    [SerializeField] private Button btnStart;
    [SerializeField] private Button btnRetry;
    [SerializeField] private Button btnBack;

    private List<GameObject> panels = new List<GameObject>();

    private void Awake()
    {
        panels.AddRange(new GameObject[] {
            menuPanel,
            gamePanel,
        });

        SetupButton();

    }

    public void GameStateChangeCallback(GameState gameState)
    {
        switch (gameState)
        {
            case GameState.MENU:
                ShowPanel(menuPanel);
                break;
            case GameState.GAMEPLAY:
                ShowPanel(gamePanel);
                break;

            case GameState.GAMEOVER:
                ShowPopupGameOver();
                break;

            case GameState.STAGECOMPLETE:
                ShowPopupCompleted();
                break;
        }
    }

    private void ShowPanel(GameObject panel)
    {
        foreach (GameObject item in panels)
        {
            item.SetActive(item == panel);
        }
    }

    private void SetupButton()
    {
        btnStart.onClick.AddListener(() =>
        {
            GameManager.Instance.SetGameState(GameState.GAMEPLAY);
        });

        btnRetry.onClick.AddListener(() =>
        {
            GameManager.Instance.SetGameState(GameState.MENU);
            HidePopupGameOver();
            ScoreManager.Instance.ResetScore();
        });

        btnBack.onClick.AddListener(() =>
       {
           GameManager.Instance.SetGameState(GameState.MENU);
           HidePopupCompleted();
           ScoreManager.Instance.ResetScore();
       });
    }

    private void ShowPopupGameOver() => popupGameOver.SetActive(true);
    private void HidePopupGameOver() => popupGameOver.SetActive(false);

    private void ShowPopupCompleted() => popupCompleted.SetActive(true);
    private void HidePopupCompleted() => popupCompleted.SetActive(false);
}
