using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggeredTrafficManager : MonoBehaviour
{
    public static TriggeredTrafficManager triggerManager;
    private List<GameObject> triggers = new List<GameObject>();
    private int activeIndex = 0;

    private void OnEnable()
    {
        if (triggerManager == null)
        {
            triggerManager = this;
        }
    }

    void Start()
    {
        var tempTransforms = transform.Find("Triggers").GetComponentsInChildren<Transform>();
        for (int i = 1; i < tempTransforms.Length; i++) //index starts in 1 to ignore parent gameObject
        {
            triggers.Add(tempTransforms[i].gameObject);
        }
        StartTriggerCycle();
    }

    private void StartTriggerCycle()
    {
        triggers[0].SetActive(true);
        for (int i = 1; i < triggers.Count; i++)
        {
            triggers[i].SetActive(false);
        }
    }

    public void RotateTrigger()
    {
        triggers[activeIndex].SetActive(false);
        activeIndex = (activeIndex >= triggers.Count - 1) ? 0 : ++activeIndex;
        triggers[activeIndex].SetActive(true);
    }
    
    
}
