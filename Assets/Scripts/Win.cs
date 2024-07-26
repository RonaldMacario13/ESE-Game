using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Win : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI textMeshPro;

    private void Start()
    {
        textMeshPro.gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player"))
        {
            textMeshPro.gameObject.SetActive(true);
        }
    }
}
