using UnityEngine;
using UnityEngine.SceneManagement;

public class Teleporter : MonoBehaviour
{
    public void Teleport(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
