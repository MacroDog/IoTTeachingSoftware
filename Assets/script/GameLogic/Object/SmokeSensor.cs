using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;

public class SmokeSensor : Sensor {
    public Sprite Icon;
    public override string getSoncserName()
    {
        return "烟雾传感器";
    }

    public override Sprite getSonserIcon()
    {
        return Icon;
    }

    public override SensorType getSonserType()
    {
        return SensorType.Smoke;
    }

    protected override void Init(Image icon, SensorType type)
    {
        
    }

   
}
