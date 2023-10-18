using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject mobSpawn;
    [SerializeField] private GameObject cameraAR;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnMobs());
    }

    IEnumerator SpawnMobs()
    {
        yield return new WaitForSeconds(Random.Range(1f, 3f));

        Vector3 pos = cameraAR.transform.position + cameraAR.transform.forward * Random.Range(2f, 4f);
        pos.y += Random.Range(-2f, 2f);
        pos.x += Random.Range(-2f, 2f);

        Instantiate(mobSpawn, pos, Quaternion.identity);

        StartCoroutine(SpawnMobs());
    }

    void OnDisable()
    {
        StopAllCoroutines();    
    }
}
