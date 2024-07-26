using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TireController3 : MonoBehaviour
{
    [SerializeField] private GameObject mosquitoPrefab; // Referência ao prefab do mosquito
    [SerializeField] private int mosquitoesToSpawn = 5; // Quantidade de mosquitos a serem spawnados
    [SerializeField] private float spawnRadius = 2f; // Raio ao redor do objeto para spawnar os mosquitos
    [SerializeField] private float spawnInterval = 8f; // Intervalo entre cada mosquito spawnado

    private Animator _animator;
    private bool waterDrained = false; // Variável para controlar se a água foi drenada
    private bool spawningMosquitoes = false; // Variável para controlar se os mosquitos estão sendo spawnados
    public AudioSource audioSourceWater;

    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
        StartCoroutine(SpawnMosquitoes()); // Inicia a coroutine para spawnar os mosquitos assim que a cena começa
        print("SerializeAsAttribute");
        waterDrained = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!waterDrained && Input.GetKeyDown("c"))
        {
            DrainWater();
        }
    }

    private IEnumerator SpawnMosquitoes()
    {
        spawningMosquitoes = true;
            for (int i = 0; i < mosquitoesToSpawn; i++)
            {
                Vector3 spawnPosition = GetRandomPosition();
                if (!waterDrained)
                {
                    Instantiate(mosquitoPrefab, spawnPosition, Quaternion.identity);
                }
                yield return new WaitForSeconds(spawnInterval);
            }
            spawningMosquitoes = false;
    }

    private Vector3 GetRandomPosition()
    {
        Vector2 randomPoint = Random.insideUnitCircle * spawnRadius;
        return new Vector3(transform.position.x + randomPoint.x, transform.position.y, transform.position.z + randomPoint.y);
    }

    private void DrainWater()
    {
        audioSourceWater.Play();
        _animator.SetTrigger("isPressed");
        waterDrained = true; // Marca a água como drenada
    }
}
