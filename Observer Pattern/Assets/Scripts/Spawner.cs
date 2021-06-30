using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    [SerializeField]
    private GameObject[] objectPrefabs;

    [SerializeField]
    private Terrain terrain;

    private TerrainData terrainData;


    // Start is called before the first frame update
    void Start() {

        terrainData = terrain.terrainData;
        InvokeRepeating("SpawnObject", 1f, 0.5f);

    }

    private void SpawnObject() {

        float x = Random.Range(0, terrainData.size.x);
        float z = Random.Range(0, terrainData.size.z);

        int index = Random.Range(0, objectPrefabs.Length);

        Vector3 position = new Vector3(x, 0, z);
        position.y = terrain.SampleHeight(position) + 10;

        Instantiate(objectPrefabs[index], position, Quaternion.identity);
    }
}
