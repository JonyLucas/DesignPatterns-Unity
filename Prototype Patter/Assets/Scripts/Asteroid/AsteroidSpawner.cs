using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour {

    public GameObject asteroidObject;
    public Material material;

    public void CreateAsteroid() {
        asteroidObject = ProcAsteroid.Clone(transform.position);
        asteroidObject.GetComponent<MeshRenderer>().sharedMaterial = material;
    }

}
