using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static GameEnums;

public class GameController : MonoBehaviour
{
    public static GameController instance;
    public event Action<GameStates> onGameStateChanged = delegate { };

    public GameStates State;
    public TrackScript CurrentTrack;
    // Start is called before the first frame update

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        onGameStateChanged += OnStateChanged;
        OnGameStart();
    }
    private void OnDisable()
    {
        onGameStateChanged -= OnStateChanged;
    }

    void OnStateChanged(GameStates state)
    {
        State = state;
        switch (state)
        {
            case GameStates.Waiting:
                break;
            case GameStates.InGame:
                break;
            case GameStates.Complete:
                break;
            case GameStates.Fail:
                break;
        }
    }


    public void OnGameStart()
    {
        onGameStateChanged.Invoke(GameStates.InGame);
    }

    public void OnGameComplete()
    {
        onGameStateChanged.Invoke(GameStates.Complete);
    }

    public void OnGameFail()
    {
        onGameStateChanged.Invoke(GameStates.Fail);
    }

    public void RestartScene()
    {
        SceneManager.LoadScene(0);
    }
}
