using UnityEngine;
using UnityEngine.SceneManagement;

public class NextSceneOnRightClick : MonoBehaviour
{
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            LoadNextScene();
        }
    }

    void LoadNextScene()
    {
        SceneManager.LoadScene(4);
    }
}