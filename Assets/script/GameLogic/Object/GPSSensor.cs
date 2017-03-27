using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;

public class GPSSensor : Sensor {
    public Sprite Icon;
    public override string getSoncserName()
    {
        return "GPS传感器";
    }

    public override Sprite getSonserIcon()
    {
        return Icon;
    }

    public override SensorType getSonserType()
    {
        return SensorType.GPS;
    }

    protected override void Init(Image icon, SensorType type)
    {
       
    }

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
