using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;

public class CameraSensor : Sensor {
    public Sprite Icon;
    public override string getSoncserName()
    {
        return "摄像机传感器";
    }

    public override Sprite getSonserIcon()
    {
        return Icon;
    }

    public override SensorType getSonserType()
    {
        return SensorType.Camera;
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
