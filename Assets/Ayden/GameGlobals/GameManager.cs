using System.Reflection;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    static GameManager _instance;
    public static GameManager Instance { get { return _instance; } }

    [RuntimeInitializeOnLoadMethod]
    static void OnGameStart()
    {
        new GameObject(MethodBase.GetCurrentMethod().DeclaringType.ToString(), typeof(GameManager));
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

    public bool gameRunning = true;
    public float gameSpeed = 1f;

    public int currentLevel = 1;
    public int maxLevelUnlocked = 1;
}
