using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using TrafficSimulation;
using UnityEngine;

public class TriggerSpawner : MonoBehaviour
{

    public GameObject carPrefab;
    //public Transform waypointLocation;
    public List<Segment> segments;
    //public List<GameObject> spawningWaypoints;

    private List<List<int>> spawnIndexes = new List<List<int>>();
    private TrafficSystem trafficSystem;

    private void Start()
    {
        trafficSystem = transform.parent.GetComponentInParent<TrafficSystem>();
        foreach (var segment in segments)
        {
            List<int> temp = new List<int>();
            for (int i = 0; i < segment.waypoints.Count; i++)
            {
                if (segment.waypoints[i].isSpawn)
                {
                    temp.Add(i);
                }
            }
            spawnIndexes.Add(temp);
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.CompareTag("Player")) return;
        
        for (int i = 0; i < spawnIndexes.Count; i++)
        {
            for (int j = 0; j < spawnIndexes[i].Count; j++)
            {
                var car = Instantiate(carPrefab, segments[i].waypoints[j].transform.position, segments[i].waypoints[j].transform.rotation);
                car.transform.LookAt(segments[i].waypoints[j+1].transform);
                //???Possibly add velocity on spawn???
                car.GetComponent<VehicleAI>().trafficSystem = this.trafficSystem;
            }
            
            
        }
        //Destroy(gameObject);
        TriggeredTrafficManager.triggerManager.RotateTrigger();
    }
}
