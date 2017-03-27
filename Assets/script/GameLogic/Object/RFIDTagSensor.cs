using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;



public class RFIDTagSensor : Sensor
{
    public Sprite Icon; //用来设置当前传感器icon

    public override string getSoncserName()
    {
        return "RFID标签";
    }

    public override Sprite getSonserIcon()
    {
        return Icon;
    }

    public override SensorType getSonserType()
    {
        return SensorType.RFIDTag;
    }

    protected override void Init(Image icon, SensorType type)
    {
        
    }

    // Use this for initialization
    void Start ()
    {
       
    }
	
	// Update is called once per frame
	void Update () {
	
	}
   
}
