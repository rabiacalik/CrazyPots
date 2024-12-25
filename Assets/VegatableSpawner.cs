using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VegatableSpawner : MonoBehaviour
{
    public List<GameObject> Vegetables; // Oluşturulacak sebzeler listesi
    private Vector3 spawnAreaMin;        
    private Vector3 spawnAreaMax;   
    public GameObject spawnAreaMinObject; 
    public GameObject spawnAreaMaxObject;     
     public float spawnInterval = 0.5f; // Spawn aralığı

    void Start()
    {
        spawnAreaMin = spawnAreaMinObject.transform.position;
        spawnAreaMax = spawnAreaMaxObject.transform.position;

        // Coroutine başlat
        StartCoroutine(SpawnVegetablesCoroutine());
    }

    private IEnumerator SpawnVegetablesCoroutine()
    {
        while (true)
        {
            SpawnVegetables();
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    private void SpawnVegetables()
    {
        GameObject randomVegetable = Vegetables[Random.Range(0, Vegetables.Count)];

        float x = Random.Range(spawnAreaMin.x, spawnAreaMax.x);
        float y = Random.Range(spawnAreaMin.y, spawnAreaMax.y);
        float z = Random.Range(spawnAreaMin.z, spawnAreaMax.z);
        Vector3 spawnPosition = new Vector3(x, y, z);

        Instantiate(randomVegetable, spawnPosition, Quaternion.identity);
    }
}
