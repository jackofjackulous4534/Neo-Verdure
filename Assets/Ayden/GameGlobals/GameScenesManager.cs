using System.Reflection;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameScenesManager : MonoBehaviour
{
    static GameScenesManager _instance;
    public static GameScenesManager Instance { get { return _instance; } }

    [RuntimeInitializeOnLoadMethod]
    static void OnGameStart()
    {
        new GameObject(MethodBase.GetCurrentMethod().DeclaringType.ToString(), typeof(GameScenesManager));
    }
    private void Awake()
    {
        if (!_instance)
        {
            _instance = this;
            DontDestroyOnLoad(_instance);
        }
        else
        {
            Destroy(this);
        }
    }

    private GameScenesObj _gameScenes;

    private void Start()
    {
        _gameScenes = UnityEngine.Resources.Load<GameScenesObj>("GameScenes"); // SCREW U UNITYYYYYYYYYYYYY
        if (!_gameScenes) Debug.LogError("FAILED TO GET GameScenes");
    }

    public enum GameScreens
    {
        MainMenu,
        Credits,
        Intermission,
        LevelSelect,
        Level,
    }
    //private GameScreens _currentScene;

    public void ChangeScene(GameScreens newScene, int level = 1)
    {
        if (!_gameScenes)
        {
            Debug.LogError("NO GAME SCENES VAR RAHHHH");
            return;
        }
        switch (newScene) {
            case GameScreens.MainMenu:
                SceneManager.LoadScene(_gameScenes.MainMenu);
                break;
            case GameScreens.Credits:
                SceneManager.LoadScene(_gameScenes.Credits);
                break;
            case GameScreens.Intermission:
                SceneManager.LoadScene(_gameScenes.Intermission);
                break;
            //case GameScreens.LevelSelect:
            //    SceneManager.LoadScene(gameScenes.LevelSelect);
            //    break;
            case GameScreens.Level:
                SceneManager.LoadScene(_gameScenes.Levels[level - 1]);
                break;
            default:
                Debug.LogError("Not a valid scnee selected");
                break;
        }
    }
}
