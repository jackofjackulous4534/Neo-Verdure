using System.Reflection;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [RuntimeInitializeOnLoadMethod]
    static void OnGameStart()
    {
        GameObject instance = new GameObject();
        instance.name = MethodBase.GetCurrentMethod().DeclaringType.ToString();
        instance.AddComponent<GameManager>();
        DontDestroyOnLoad(instance);
        ServiceLocator.AddService(instance.GetComponent<GameManager>());
    }

    public bool gameRunning = true;
    public float gameSpeed = 1f;

    public int currentLevel = 1;
    public int maxLevelUnlocked = 1;
}
