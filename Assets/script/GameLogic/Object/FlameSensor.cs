using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;

public class FlameSensor : Sensor {
    public Sprite Icon;
    public override string getSoncserName()
    {
        return "火焰传感器";
    }

    public override Sprite getSonserIcon()
    {
        return Icon;
    }

    public override SensorType getSonserType()
    {
        return SensorType.Flame;
    }

    protected override void Init(Image icon, SensorType type)
    {
        
    }

    
}
