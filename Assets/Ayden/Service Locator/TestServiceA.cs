using UnityEngine;

public class TestServiceA : MonoBehaviour
{
    [RuntimeInitializeOnLoadMethod]
    static void OnGameStart()
    {
        GameObject instance = new GameObject();
        instance.name = "Test boi";
        instance.AddComponent<TestServiceA>();
        DontDestroyOnLoad(instance);
        ServiceLocator.AddService(instance);
    }

    public void DoSomething()
    {
        Debug.Log("I did something!");
    }
}
