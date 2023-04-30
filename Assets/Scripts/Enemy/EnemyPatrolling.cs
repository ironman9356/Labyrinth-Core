using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrolling : MonoBehaviour
{
    public float speed = 5.0f;
    public List<Vector2> waypoints = new List<Vector2>();
    private int currentWaypoint = 0;


    void Update()
    {
        Vector2 direction = waypoints[currentWaypoint] - (Vector2)transform.position;
        transform.Translate(direction.normalized * speed * Time.deltaTime);

        if (Vector2.Distance(transform.position, waypoints[currentWaypoint]) < 0.1f)
        {
            currentWaypoint++;
            if (currentWaypoint >= waypoints.Count)
            {
                currentWaypoint = 0;
            }
        }
    }
}
