using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggeredWaypointNavigator : MonoBehaviour
{
    CharacterNavigationController controller;
    public Waypoint currentWaypoint; //given by the trigger
    //public bool backward = false;

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
            if (currentWaypoint.nextWaypoint == null)
            {
                Destroy(gameObject);
            }
            else
            {
                currentWaypoint = currentWaypoint.nextWaypoint;
                controller.SetDestination(currentWaypoint.GetPosition());
            }
        }
    }
}
