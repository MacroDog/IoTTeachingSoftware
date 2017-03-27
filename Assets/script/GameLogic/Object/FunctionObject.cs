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
    
    
    public List<SensorType> Install
    {
        get;
        protected set;
    }//已安装的传感器

    public List<SensorType> ShoudbeInstall; //需要安装的传感器
    public List<SensorType> CanInstallSensor;
    public List<Transform> showTransform;//sensor出现位置
    private List<GameObject> instenssensors;
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
    protected bool isTrueInstall = false;
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
        Install = new List<SensorType>();
        _light = this.gameObject.AddComponent<Highlighter>();
        //Install.Add(SensorType.RFIDTag);
      
    }


    public void OnMouseOver()
    {    
        _light.On(LightColor);
        if (Input.GetMouseButtonDown(1)&&isTrueInstall==false)
        {
            //GameObject ui = UIManager.Instance.GetUIGameObject(EnumUIPlaneType.FunctionObjectInformationPanel);
            //ui.GetComponent<FunctionObjectInformationPanel>().Action_AddHaveSensor += InstallSensor;
            //ui.GetComponent<FunctionObjectInformationPanel>().Action_RemoveHaveSensor += UninstallSensor;
            openInfomationPanel();
            Debug.Log("Open funcationUI");
        }
    }
    //关闭 信息面板
    private void closeInformationPanel()
    {
        if (UIManager.Instance.GetUIGameObject(EnumUIPlaneType.FunctionObjectInformationPanel))
        {
            UIManager.Instance.CloseUI(EnumUIPlaneType.FunctionObjectInformationPanel);
        }
        
    }
    //开启 信息面板
    private void openInfomationPanel()
    {
        if (!UIManager.Instance.GetUIGameObject(EnumUIPlaneType.FunctionObjectInformationPanel))
        {
            UIManager.Instance.OpenUI(EnumUIPlaneType.FunctionObjectInformationPanel, false, this.gameObject);
            
            //UIManager.Instance.GetUIGameObject(EnumUIPlaneType.FunctionSceneMenu).GetComponent<FunctionObjectInformationPanel>().Action_AddHaveSensor += InstallSensor;
           // UIManager.Instance.GetUIGameObject(EnumUIPlaneType.FunctionSceneMenu).GetComponent<FunctionObjectInformationPanel>().Action_RemoveHaveSensor += UninstallSensor;

        }
        else
        {
            closeInformationPanel();
        }
    }


    private GameObject[] getSensors(List<SensorType> item)
    {
        List<GameObject> o=new List<GameObject>();
        for (int i = 0; i < item.Count; i++)
        {
          o.Add( SensorPrefabPath.getSensorPfb(item[i]));
        }
        return o.ToArray();
    }


    //安装传感器
    public void InstallSensor(SensorType item)
    {
        if (!Install.Contains(item))
        {
            Install.Add(item);
        }
        Debug.Log("Install"+item.ToString());
    }

    //卸载传感器
    public void UninstallSensor(SensorType item)
    {
        if (Install.Contains(item))
        {
            Install.Remove(item);
        }
        Debug.Log("UnInstall" + item.ToString());
    }
    
    //检测是否正确安装
    private bool chickOut()
    {
        if (Install.Count<=0)
        {
            isTrueInstall = false;
            return false;
        }
        for (int i = 0; i < Install.Count; i++)
        {
            if (!ShoudbeInstall.Contains(Install[i]))
            {
                isTrueInstall = false;
                return false;
            }
        }
        isTrueInstall = true;
        for (int i = 0; i < ShoudbeInstall.Count; i++)
        {

            GameObject tem =Resources.Load(SensorPrefabPath.GetPath(ShoudbeInstall[i])) as GameObject;
            instenssensors.Add( MonoBehaviour.Instantiate(tem, showTransform[i])as GameObject);
        }
        return true;
    }
}
