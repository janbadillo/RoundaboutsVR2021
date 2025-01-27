﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointNavigator : MonoBehaviour
{
    CharacterNavigationController controller;
    public Waypoint currentWaypoint;
    public bool backward = false;

    private void Awake()
    {
        controller = GetComponent<CharacterNavigationController>();
    }
    // Start is called before the first frame update
    void Start()
    {
        controller.SetDestination(currentWaypoint.GetPosition());
    }

    // Update is called once per frame
    void Update()
    {
        if (controller.reachedDestination)
        {
            if (backward)
            {
                currentWaypoint = currentWaypoint.previousWaypoint;
                controller.SetDestination(currentWaypoint.GetPosition());
            }
            else
            {
                currentWaypoint = currentWaypoint.nextWaypoint;
                controller.SetDestination(currentWaypoint.GetPosition());
            }
        }
    }
}
