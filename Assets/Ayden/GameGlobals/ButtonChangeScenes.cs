using UnityEngine;
using static GameScenesManager;

public class ButtonChangeScenes : MonoBehaviour
{
    private GameScenesManager _sceneManager;
    private void Start()
    {
        if (ServiceLocator.GetService(out GameScenesManager GSM))
        {
            _sceneManager = GSM;
        }
        else
        {
            Debug.LogError("No Scenes manager found");
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="scene">
    /// MainMenu:0,
    /// Credits:1,
    /// Intermission:2,
    /// LevelSelect:3
    /// Level</param>
    public void SwapToStaticScene(int scene)
    {
        switch (scene)
        {
            case 0:
                _sceneManager.ChangeScene(GameScreens.MainMenu);
                break;
            case 1:
                _sceneManager.ChangeScene(GameScreens.Credits);
                break;
            case 2:
                _sceneManager.ChangeScene(GameScreens.Intermission);
                break;
            //case GameScreens.LevelSelect:
            //    SceneManager.LoadScene(gameScenes.LevelSelect);
            //    break;
            default:
                Debug.LogError("Not a valid scnee selected");
                break;
        }
    }
    public void SwapToLevel(int levelNum)
    {
        _sceneManager.ChangeScene(GameScreens.Level, levelNum);
    }
}
