using UnityEngine;

public class TestUserA : MonoBehaviour
{
    private TestServiceA sv;
    void Start()
    {
        if (ServiceLocator.GetService(out TestServiceA v))
        {
            sv = v;
            sv.DoSomething();
        }
        else
        {
            Debug.LogError("FAILED TO GET TST SERVICE RAAGGGGGG");
        }
    }
}
