using UnityEngine;
using UnityEngine.SceneManagement;

public class Teleporter : MonoBehaviour
{
    void Teleport(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
