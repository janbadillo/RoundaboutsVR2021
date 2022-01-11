using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIVehicleTriggeredStop : MonoBehaviour
{
    private void OnTriggerExit(Collider other)
    {
        Destroy(this.gameObject);
    }
}
