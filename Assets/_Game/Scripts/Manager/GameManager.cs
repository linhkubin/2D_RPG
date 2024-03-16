using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState
{
    MainMenu = 0,
    GamePlay = 1,
    GamePause = 2,
    Finish = 3,
}

public class GameManager : Singleton<GameManager>
{
    private static GameState gameState;

    private void Awake()
    {
        Application.targetFrameRate = 60;
        //Input.multiTouchEnabled = false;

        ChangeState(GameState.MainMenu);
    }

    public static void ChangeState(GameState state)
    {
        gameState = state;  
    }

    public static bool IsState(GameState state)
    {
        return gameState == state;
    }
}
