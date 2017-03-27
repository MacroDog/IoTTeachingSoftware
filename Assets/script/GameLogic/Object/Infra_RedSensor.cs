using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;

public class Infra_RedSensor : Sensor {
    public Sprite Icon;
    public override string getSoncserName()
    {
        return "红外传感器";
    }

    public override Sprite getSonserIcon()
    {
        return Icon;
    }

    public override SensorType getSonserType()
    {
        return SensorType.Infra_Red;
    }

    protected override void Init(Image icon, SensorType type)
    {
        
    }

   
}
