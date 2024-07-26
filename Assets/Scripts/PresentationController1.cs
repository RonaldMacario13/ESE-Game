using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PresentationController1 : MonoBehaviour
{
    public Text title;
    public Text text;

    private string title1 = "Bem vindo ao bairro do Magano";
    private string title2 = "Objetivos do jogo";
    private string text1 = "O bairro do Magano, na cidade de Garanhuns, está enfrentando uma grave ameaça: a proliferação do mosquito da dengue. Você, como um estudante consciente, tem a missão de proteger sua comunidade. Sua jornada começa agora, e você terá que eliminar os focos de dengue para salvar seu bairro.";
    private string text2 = "Seu objetivo é combater os focos de dengue no bairro do Magano. Encontre e elimine as áreas de água parada onde os mosquitos podem se reproduzir. Converse com os moradores para obter dicas e use armas para combater o mosquito. Lembre-se: a prevenção é a chave para proteger sua comunidade.";

    void Start() {
        title.text = title1;
        text.text = text1;
            
        Invoke(nameof(ChangeText), 25f);
    }

    void ChangeText() {
        title.text = title2;
        text.text = text2;

        Invoke(nameof(ChangeScene), 25f);
    }

    void ChangeScene() {
        SceneManager.LoadSceneAsync(4);
    }

}
