using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIControl : MonoBehaviour {

    NavMeshAgent agent;
    Animator anim;
    Vector3 lastGoal;

    // Use this for initialization
    void Start() {
        
        agent = this.GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        anim.SetBool("isWalking", true);

        Vector3 lastGoal = GameEnvironment.Singleton.GetRandomGoal().transform.position;
        PickGoalLocation();
    }

    void PickGoalLocation() {
        lastGoal = agent.destination;
        Vector3 newDestination = GameEnvironment.Singleton.GetRandomGoal().transform.position;
        agent.SetDestination(newDestination);
    }


    // Update is called once per frame
    void Update() {
        if (agent.remainingDistance < 1) { // Reach the goal
            PickGoalLocation();
        }

        CheckObstacle();        

    }

    private void CheckObstacle() {
        int size = GameEnvironment.Singleton.Obstacles.Count;
        List<GameObject> obstacles = GameEnvironment.Singleton.Obstacles;
        for (int i = 0; i < size; i++) {
            float distance = Vector3.Distance(obstacles[i].transform.position, transform.position);
            if (distance < 5 && Random.Range(0,100) < 5) {
                agent.SetDestination(lastGoal);
            }else if(distance < 1) {
                GameEnvironment.Singleton.RemoveObstacle(obstacles[i]);
                break;
            }
        }
    }

}
