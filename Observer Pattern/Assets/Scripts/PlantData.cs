using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="plant data", menuName = "Plant Data", order = 51)]
public class PlantData : ScriptableObject {

    public enum THREAT { None, Low, Moderate, High };

    [SerializeField]
    private string name;

    [SerializeField]
    private THREAT levelOfThreat;

    [SerializeField]
    private Texture plantIcon;


    public string Name { get { return name; } }
    public THREAT Threat { get { return levelOfThreat; } }
    public Texture Icon { get { return plantIcon; } }


}
