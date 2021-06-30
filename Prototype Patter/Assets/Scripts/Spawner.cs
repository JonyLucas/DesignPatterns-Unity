using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    public GameObject cubePrefab, spherePrefab;
    
    // Start is called before the first frame update
    void Start() {
        InvokeRepeating("CreateInstance", 0.5f, 1);
    }

    private void CreateInstance() {
        if (Random.Range(0, 100) < 50)
            Instantiate(cubePrefab, transform.position, Quaternion.identity);
        else
            Instantiate(spherePrefab, transform.position, Quaternion.identity);
    }


}
