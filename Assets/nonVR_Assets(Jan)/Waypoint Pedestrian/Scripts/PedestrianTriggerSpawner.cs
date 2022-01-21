using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using TrafficSimulation;
using UnityEngine;

public class PedestrianTriggerSpawner : MonoBehaviour
{

    public GameObject humanPrefab;
    public Waypoint spawnWaypoint;
    

    private void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.CompareTag("Player")) return;
        
        var human = Instantiate(humanPrefab, spawnWaypoint.transform.position, spawnWaypoint.transform.rotation);
        human.transform.LookAt(spawnWaypoint.nextWaypoint.transform);
        human.GetComponent<TriggeredWaypointNavigator>().currentWaypoint = spawnWaypoint.nextWaypoint;
        Destroy(gameObject);
    }
}
