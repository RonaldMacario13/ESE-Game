using System.Collections.Generic;
using UnityEngine;

public class MosquitoSpawner : MonoBehaviour
{
    public GameObject mosquitoPrefab; // Prefab do mosquito
    public int maxMosquitos = 5; // Quantidade máxima de mosquitos
    private List<GameObject> mosquitos = new List<GameObject>();

    public void SpawnMosquitos()
    {
        int currentMosquitos = mosquitos.Count;

        for (int i = currentMosquitos; i < maxMosquitos; i++)
        {
            GameObject mosquito = Instantiate(mosquitoPrefab, transform.position, Quaternion.identity);
            mosquitos.Add(mosquito);
        }
    }

    public void RemoveMosquitos()
    {
        foreach (GameObject mosquito in mosquitos)
        {
            Destroy(mosquito);
        }
        mosquitos.Clear();
    }

    public int GetMosquitoCount()
    {
        return mosquitos.Count;
    }
}
