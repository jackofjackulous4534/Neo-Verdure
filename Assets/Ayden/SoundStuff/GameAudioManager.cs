using System.Reflection;
using UnityEngine;

public class GameAudioManager : MonoBehaviour
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

    //private void Awake()
    //{
    //    if (this != _instance)
    //    {
    //        Debug.Log("DIE WITH FIRE");
    //    }
    //}
}
