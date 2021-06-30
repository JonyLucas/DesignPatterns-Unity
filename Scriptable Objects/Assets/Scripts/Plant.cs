using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Plant : MonoBehaviour {

    [SerializeField]
    private PlantData info;

    SetPlantInfo plantInfo;

    private void Start() {
        plantInfo = GameObject.FindWithTag("PlantInfo").GetComponent<SetPlantInfo>();
    }


    void OnMouseDown() {

        plantInfo.OpenPlantPanel();
        plantInfo.plantName.text = info.Name;
        plantInfo.threatLevel.text = info.Threat.ToString();
        plantInfo.plantIcon.GetComponent<RawImage>().texture = info.Icon;
        

    }

    private void OnCollisionEnter(Collision other) {
        if(other.transform.tag == "Player" && info.Threat == PlantData.THREAT.High) {
            PlayerController.dead = true;
        }
    }

}
