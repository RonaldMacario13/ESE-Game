using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingController : MonoBehaviour
{
    public Text loadingText;
    [SerializeField] private int _sceneNumber = 2;

    readonly List<string> loadingPhrases = new()
    {
        "Mantenha caixas d'água, tonéis e barris bem tampados para evitar a proliferação do mosquito da dengue.",
        "Troque a água dos vasos de plantas por areia para evitar o acúmulo de água parada.",
        "Limpe calhas e telhados regularmente para impedir a formação de criadouros do mosquito da dengue.",
        "Coloque telas nas janelas e portas para evitar a entrada de mosquitos dentro de casa.",
        "Não deixe água acumulada em pneus velhos, garrafas e outros recipientes no quintal.",
        "Faça vistorias semanais no seu quintal para eliminar possíveis focos de água parada.",
        "Use repelente para se proteger das picadas do mosquito da dengue.",
        "Lave semanalmente recipientes que acumulam água, como bebedouros de animais.",
        "Descarte corretamente lixo e materiais recicláveis para evitar a acumulação de água.",
        "Participe de campanhas de conscientização sobre a dengue na sua comunidade."
    };

    void Start() {
        int rand = Random.Range(0, loadingPhrases.Count-1);

        loadingText.text = loadingPhrases[rand];
            
        Invoke(nameof(ChangeScene), 8f);
    }

    void ChangeScene() {
        SceneManager.LoadSceneAsync(_sceneNumber);
    }
}
