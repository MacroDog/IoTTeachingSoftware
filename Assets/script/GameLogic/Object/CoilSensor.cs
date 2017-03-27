using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;

public class CoilSensor : Sensor {
    public Sprite Icon;
    public override string getSoncserName()
    {
        return "线圈传感器";
    }

    public override Sprite getSonserIcon()
    {
        return Icon;
    }

    public override SensorType getSonserType()
    {
        return SensorType.Coil;
    }

    protected override void Init(Image icon, SensorType type)
    {
        throw new NotImplementedException();
    }

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
