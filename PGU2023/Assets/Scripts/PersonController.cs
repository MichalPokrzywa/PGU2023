using System.Collections;
using System.Collections.Generic;
using Unity.AI.Navigation;
using UnityEngine;
using UnityEngine.AI;

public class PersonController : MonoBehaviour
{
    private NavMeshAgent agent;
    private NavMeshSurface navMeshSurface;
    private Vector3 center;
    private float maxDistance;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        navMeshSurface = FindObjectOfType<NavMeshSurface>();
        maxDistance = Mathf.Max( navMeshSurface.size.x / 2, navMeshSurface.size.z /2);
        center = navMeshSurface.center;

        if (navMeshSurface == null)
        {
            Debug.LogError("NavMeshSurface not found. Make sure you have a NavMeshSurface in your scene.");
        }
    }

    public static Vector3 GetRandomPoint(Vector3 center, float maxDistance)
    {
        // Get Random Point inside Sphere which position is center, radius is maxDistance
        Vector3 randomPos = Random.insideUnitSphere * maxDistance + center;

        NavMeshHit hit; // NavMesh Sampling Info Container

        // from randomPos find a nearest point on NavMesh surface in range of maxDistance
        NavMesh.SamplePosition(randomPos, out hit, maxDistance, NavMesh.AllAreas);

        return hit.position;
    }

    void Update()
    {
        if (!agent.pathPending && agent.remainingDistance < 0.5f)
        {
            
            agent.SetDestination(GetRandomPoint(center, maxDistance));
        }
    }
}
