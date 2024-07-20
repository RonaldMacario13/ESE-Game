using UnityEngine;
using UnityEngine.UI;

public class LifeBar : MonoBehaviour
{
    private Slider slider;

    void LifeController(float life)
    {
        slider.value = life;
    }
}
