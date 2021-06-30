using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereSpawner : MonoBehaviour {
    // Update is called once per frame
    void Update() {
        if (Random.Range(0, 100) < 15)
            ProceduralSphere.GetSphere(transform.position);
    }
}
