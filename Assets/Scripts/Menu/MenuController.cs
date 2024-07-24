using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    [SerializeField] private string newGameScene;
    // [SerializeField] private string settingsScene;

    public void PlayNewGame() {
        StartCoroutine(WaitAndChangeScene(newGameScene, 0.7f));
    }

    public void Settings() {
        //TODO
        print("Entrando nas opções");
    }

    public void Exit() {
        Application.Quit();
    }
    
    private IEnumerator WaitAndChangeScene(string scene, float delay) {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(scene);
    }
}
