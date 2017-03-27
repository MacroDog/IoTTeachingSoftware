using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;

public class TiltSensor : Sensor {
    public Sprite Icon;
    public override string getSoncserName()
    {
        return "倾角传感器";
    }

    public override Sprite getSonserIcon()
    {
        return Icon;
    }

    public override SensorType getSonserType()
    {
        return SensorType.Tilt;
    }

    protected override void Init(Image icon, SensorType type)
    {
        
    }

   
}
