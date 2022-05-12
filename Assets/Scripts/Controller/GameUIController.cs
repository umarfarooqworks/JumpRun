using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static GameEnums;

public class GameUIController : MonoBehaviour
{
    [Header("GameController")]
    public GameController GameController;

    [Header("UI Panels")]
    public List<PanelInfo> GamePanels;

    [Space(20)]
    [Header("Buttons")]
    public Button GameCompleteRestartButton;
    public Button GameFailRestartButton;
    // Start is called before the first frame update
    void Start()
    {
        GameController.instance.onGameStateChanged += onStateChanged;
        GameCompleteRestartButton.onClick.AddListener(OnClickRestartLevel);
        GameFailRestartButton.onClick.AddListener(OnClickRestartLevel);
    }
    private void OnDisable()
    {
        GameController.instance.onGameStateChanged -= onStateChanged;
        GameCompleteRestartButton.onClick.RemoveListener(OnClickRestartLevel);
        GameFailRestartButton.onClick.RemoveListener(OnClickRestartLevel);
    }

    void onStateChanged(GameStates state)
    {
        SetPanel(state);

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

    void SetPanel(GameStates state)
    {
        foreach(PanelInfo x in GamePanels)
        {
            if (x.PanelType == state)
            {
                x.gameObject.SetActive(true);
            }
            else 
                x.gameObject.SetActive(false);
        }
    }

    public void OnClickRestartLevel()
    {
        GameController.RestartScene();
    }

}
