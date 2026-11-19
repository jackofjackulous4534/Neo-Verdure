using System.Reflection;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    static GameManager _instance;
    public static GameManager Instance { get { return _instance; } }

    [RuntimeInitializeOnLoadMethod]
    static void OnGameStart()
    {
        GameObject instance = new GameObject();
        instance.name = MethodBase.GetCurrentMethod().DeclaringType.ToString();
        instance.AddComponent<GameManager>();
        DontDestroyOnLoad(instance);
        _instance = instance.GetComponent<GameManager>();
    }

    public bool gameRunning = true;
    public float gameSpeed = 1f;

    public int currentLevel = 1;
    public int maxLevelUnlocked = 1;
}
