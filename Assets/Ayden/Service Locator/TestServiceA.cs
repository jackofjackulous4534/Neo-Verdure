using System.Reflection;
using UnityEngine;

public class TestServiceA : MonoBehaviour
{
    //[RuntimeInitializeOnLoadMethod]
    //static void OnGameStart()
    //{
    //    GameObject instance = new GameObject();
    //    instance.name = MethodBase.GetCurrentMethod().DeclaringType.ToString();
    //    instance.AddComponent<TestServiceA>();
    //    DontDestroyOnLoad(instance);
    //    ServiceLocator.AddService(instance.GetComponent<TestServiceA>());
    //}
    //public void DoSomething()
    //{
    //    Debug.Log("I did something!");
    //}
}
