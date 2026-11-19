using System.Reflection;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameScenesManager : MonoBehaviour
{
    [RuntimeInitializeOnLoadMethod]
    static void OnGameStart()
    {
        GameObject instance = new GameObject();
        instance.name = MethodBase.GetCurrentMethod().DeclaringType.ToString();
        instance.AddComponent<GameScenesManager>();
        DontDestroyOnLoad(instance);
        ServiceLocator.AddService(instance.GetComponent<GameScenesManager>());
    }

    private GameScenesObj gameScenes;

    private void Start()
    {
        gameScenes = UnityEngine.Resources.Load<GameScenesObj>("GameScenes"); // SCREW U UNITYYYYYYYYYYYYY
    }

    public enum GameScreens
    {
        MainMenu,
        LevelSelect,
        Intermission,
        Level,
        Credits,
    }
    //private GameScreens _currentScene;

    public void ChangeScene(GameScreens newScene, int level = 0)
    {
        if (!gameScenes)
        {
            Debug.LogError("NO GAME SCENES VAR RAHHHH");
            return;
        }
        switch (newScene) {
            case GameScreens.MainMenu:
                SceneManager.LoadScene(gameScenes.MainMenu);
                break;
            case GameScreens.Credits:
                SceneManager.LoadScene(gameScenes.Credits);
                break;
            case GameScreens.Intermission:
                SceneManager.LoadScene(gameScenes.Intermission);
                break;
            //case GameScreens.LevelSelect:
            //    SceneManager.LoadScene(gameScenes.LevelSelect);
            //    break;
            case GameScreens.Level:
                SceneManager.LoadScene(gameScenes.Levels[level]);
                break;
            default:
                Debug.LogError("Not a valid scnee selected");
                break;
        }
    }
}
