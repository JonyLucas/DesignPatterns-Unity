using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class implements the singleton pattern, to make a single instance of an object of this class 
/// that will hold information about the elements of the environment.
/// </summary>
public sealed class GameEnvironment {

    private static GameEnvironment instance;
    private List<GameObject> obstacles = new List<GameObject>();
    private List<GameObject> goalLocations = new List<GameObject>(GameObject.FindGameObjectsWithTag("goal"));

    public List<GameObject> Obstacles { get { return obstacles; } }
    public List<GameObject> Goals { get { return goalLocations; } }

    public static GameEnvironment Singleton {

        get {
            if (instance == null) {
                instance = new GameEnvironment();
            }                

            return instance;
        }
        
    }

    public void AddObstacle(GameObject obstacle) {
        obstacles.Add(obstacle);
    }

    public void RemoveObstacle(GameObject obstacle) {
        int index = obstacles.IndexOf(obstacle);
        obstacles.RemoveAt(index);
        GameObject.Destroy(obstacle);
    }

    public GameObject GetRandomGoal() {
        return goalLocations[Random.Range(0, goalLocations.Count)];
    }

}
