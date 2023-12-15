using System.Collections;
using System.Collections.Generic;
using Unity.AI.Navigation;
using UnityEngine;
using UnityEngine.AI;

/// <summary>
/// Controls the movement of a person in the game using Unity's NavMesh system.
/// </summary>
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
        maxDistance = Mathf.Max(navMeshSurface.size.x / 2, navMeshSurface.size.z / 2);
        center = navMeshSurface.center;

        if (navMeshSurface == null)
        {
            Debug.LogError("NavMeshSurface not found. Make sure you have a NavMeshSurface in your scene.");
        }
    }

    /// <summary>
    /// Gets a random point on the NavMesh surface within a specified range.
    /// </summary>
    /// <param name="center">The center position of the NavMesh surface.</param>
    /// <param name="maxDistance">The maximum distance from the center to search for a random point.</param>
    /// <returns>A random point on the NavMesh surface.</returns>
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
