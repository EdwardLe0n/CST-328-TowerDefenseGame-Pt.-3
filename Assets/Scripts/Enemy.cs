using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{

    public float speed = 10f;

    public int health = 100;

    public int value = 50;

    public GameObject deathEffect;

    public Transform target;
    private int waypointIndex = 0;

    private NavMeshAgent enemyNav; 

    void Start()
    {

        // Outdated
        // target = Waypoints.points[0];

        enemyNav = GetComponent<NavMeshAgent>();
        enemyNav.SetDestination(target.position);

    }

    public void TakeDamage (int dam)
    {
        health -= dam;

        if (health <= 0)
        {
            Die();
        }

    }

    void Die()
    {

        PlayerStats.money += value;

        GameObject effect = (GameObject)Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(effect, 5f);

        Destroy(gameObject);
    }

    void Update()
    {

        // Outdated bc I'm no longer using the node system

        /*// Checks the current direction by comparing the current position to the next waypoint
        Vector3 dir = target.position - transform.position;

        // First normalizes the direction vector
        // Then multiplies that normalized vector by the enemies speed and by Time.deltaTime
        // Finally the code tells the system that it will move this enemy to the direction multiplied by all that
        // ... using the translate function

        transform.Translate(dir.normalized * speed * Time.deltaTime);
        
        // If the enemy is close enough to the waypoint, then it will look at 
        // ... the next waypoint as the new target
        
        if (Vector3.Distance(transform.position, target.position) <= 0.2f)
        {
            GetNextWaypoint();
        }*/

        // Tbh this one was a my b. I should be checking collision
        /*if (this.transform.position == target.position)
        {
            EndPath();
        }*/

    }

    private void OnTriggerEnter(Collider collision)
    {
        // Sanity check
        Debug.Log("Currently colliding");
        EndPath();

        /*if (collision.gameObject == transform.gameObject)
        {
            EndPath();
        }*/
    }

    // Outdated
    // Gets the next wavepoint
    void GetNextWaypoint()
    {

        // If there are no more waypoints then the enemy will destroy itself
        if (waypointIndex >= Waypoints.points.Length - 1)
        {

            EndPath();

            // return statement to avoid running more code
            return;

        }

        waypointIndex++;
        target = Waypoints.points[waypointIndex];

    }

    void EndPath ()
    {

        Destroy(gameObject);
        PlayerStats.lives -= 1;

    }

}
