using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class TrocarFase : MonoBehaviour
{
        private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player"))
        {
            CarregarNovaFase();
        }
    }

    private void CarregarNovaFase()
    {
        StartCoroutine(WaitAndChangeScene("LoadingBetweenLevels", 0.2f));
    }
    
    private IEnumerator WaitAndChangeScene(string scene, float delay) {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(scene);
    }
}
