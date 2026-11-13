using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransfer : MonoBehaviour
{
    [Scene]
    [SerializeField] string SceneToLoad;
    public void LoadScene()
    {
        if (string.IsNullOrEmpty(SceneToLoad))
        {
            Debug.LogError("Missing SceneToLoad");
            return;
        }
        if (SceneUtility.GetBuildIndexByScenePath(SceneToLoad) == -1)
        {
            Debug.LogError("Not Valid Scene");
            return;
        }

        SceneManager.LoadScene(SceneToLoad);
    }
}
