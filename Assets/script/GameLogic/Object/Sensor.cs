using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public  enum  SensorType
{
    None,
    Camera,
    GPS,
    RFIDTag,
    RFIDRead,
    Flame,
    Smoke,
    Tilt,
    Infra_Red,
    Ultrasonic,
    Coil
}



/// <summary>
/// 传感器PrefabPath
/// </summary>
public class SensorPrefabPath
{
    const string SensorPfb_Path = "GameObjectPrefabs/Sensor/";
    public static  string GetPath(SensorType type)
    {
        if (type!=SensorType.None)
        {
            return SensorPfb_Path + type.ToString()+"Sensor";
        }
        return null;
        
    }
    public static Type GetSensorScript(SensorType type)
    {
        Type temp=null;
        switch (type)
        {
            case SensorType.None:
                break;
            case SensorType.Camera:
                break;
            case SensorType.GPS:
                break;
            case SensorType.RFIDTag:
                break;
            case SensorType.RFIDRead:
                break;
            case SensorType.Flame:
                break;
            case SensorType.Smoke:
                break;
            case SensorType.Tilt:
                break;
            case SensorType.Infra_Red:
                break;
            case SensorType.Ultrasonic:
                break;
            default:
                break;
        }
        return temp;
    }
    public static GameObject getSensorPfb(SensorType type)
    {
        GameObject tem = Resources.Load(GetPath(type))as GameObject;
        return tem;
    }
}


/// <summary>
///必须实现
/// </summary>
public abstract class Sensor : MonoBehaviour
{

    //图标
    public abstract Sprite getSonserIcon();

    public abstract SensorType getSonserType();
    //名字
    public abstract string getSoncserName();

    //功能
    public virtual void Function()
    {

    }
    /// <summary>
    /// 初始化
    /// </summary>
    /// <param name="icon"></param>
    /// <param name="type"></param>
    protected abstract void Init(Image icon,SensorType type);
    private void Awake()
    {
        Debug.Log("awake");
    }
}
