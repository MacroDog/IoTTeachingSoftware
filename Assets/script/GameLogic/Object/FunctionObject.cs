using UnityEngine;
using System.Collections;
using HighlightingSystem;
using System;
using System.Collections.Generic;

/// <summary>
/// 需要被安装传感器的物体
/// </summary>
public class FunctionObject : MonoBehaviour, IHightLight
{
    //安装的传感器
    public List<Sensor> Install
    {
        get;
        protected set;
    }
    //需要安装的传感器
    public List<Sensor> ShoudbeInstall;
    protected string objectName;
    public string ObjectName
    {
        get
        {
            return objectName;
        }
    }
    public string Information;
    public Color LightColor=Color.red;
    protected Highlighter _light;
    public Highlighter Light
    {
        get
        {
            return _light;
        }

      
    }
    public void HightLight(Color color)
    {
        _light.On(color);
    }
    private void Start()
    {
        _light = this.gameObject.AddComponent<Highlighter>();
      
    }
    public void OnMouseOver()
    {
        _light.On(LightColor);
    }

}
