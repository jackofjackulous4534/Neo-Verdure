using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransfer : MonoBehaviour
{
    public void LoadScene(string SceneName)
    {
        SceneManager.LoadScene("SceneName");
    }
}
