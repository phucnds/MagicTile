using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public enum GameState
{
    MENU,
    GAMEPLAY,
    GAMEOVER,
    STAGECOMPLETE
}

public class GameManager : SingleReference<GameManager>
{
    private void Start()
    {
        Initialize();
        SetGameState(GameState.MENU);
    }

    private void Initialize()
    {
        Application.targetFrameRate = 60;
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
    }

    public void SetGameState(GameState state)
    {
        IEnumerable<IGameStateListener> gameStateListeners = FindObjectsByType<MonoBehaviour>(FindObjectsSortMode.None).OfType<IGameStateListener>();

        foreach (IGameStateListener gameStateListener in gameStateListeners)
        {
            gameStateListener.GameStateChangeCallback(state);
        }
    }
}
