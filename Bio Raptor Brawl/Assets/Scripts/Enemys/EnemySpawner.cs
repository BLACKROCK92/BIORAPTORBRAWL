using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    [SerializeField]
    GameObject EnemyPrefab;
    GameObject[] SpawnZones;

    private void Start()
    {
        SpawnZones = GameObject.FindGameObjectsWithTag("SpawnZone");

        foreach(GameObject spawnzone in SpawnZones)
        {
            Instantiate(EnemyPrefab, spawnzone.transform.position, Quaternion.identity);
        }
    }

}
