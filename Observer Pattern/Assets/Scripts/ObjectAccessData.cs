using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectAccessData : MonoBehaviour {

    public ObjectData data;

    [SerializeField]
    private Event spawnEvent, pickupEvent;

    private void Start() {
        spawnEvent.Occurred(transform.gameObject);
    }

    private void OnCollisionEnter(Collision collision) {
        if(collision.gameObject.tag == "Player") {
            pickupEvent.Occurred(transform.gameObject);
            Destroy(this.gameObject, 0.1f);
        }
    }

}
