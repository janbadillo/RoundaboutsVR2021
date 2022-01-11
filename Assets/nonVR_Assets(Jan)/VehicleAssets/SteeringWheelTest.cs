using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SteeringWheelTest : MonoBehaviour
{
    public GameObject sWheel;
    public Slider accBar;
    public Slider brakeBar;
    public Slider clutchBar;

    // Start is called before the first frame update
    void Start()
    {
        //sWheel = GameObject.Find("Steering_wheel");
    }

    // Update is called once per frame
    void Update()
    {

        if (LogitechGSDK.LogiUpdate() && LogitechGSDK.LogiIsConnected(0))
        {
            LogitechGSDK.DIJOYSTATE2ENGINES rec;
            rec = LogitechGSDK.LogiGetStateUnity(0);

            float steerVal = Convert.ToSingle(rec.lX);
            //print(rec.lRz);
            sWheel.transform.localRotation = Quaternion.Euler(0, -180, steerVal*(450.0f/32786.0f));

            accBar.value = (-Convert.ToSingle(rec.lY) + 32767.0f)/65535.0f;

            brakeBar.value = (-Convert.ToSingle(rec.lRz) + 32767.0f) / 65535.0f;
           

            clutchBar.value = (-Convert.ToSingle(rec.rglSlider[0]) + 32767.0f) / 65535.0f;
          
        }
    }
}
