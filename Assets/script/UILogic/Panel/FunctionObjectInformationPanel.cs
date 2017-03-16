
using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine.UI;
public class FunctionObjectInformationPanel : BaseUI {

    [SerializeField]
    private ScrollRect haveSensorSV;
    [SerializeField]
    private ScrollRect canChoseSensorSV;
    [SerializeField]
    private Button SetSensor;
    [SerializeField]
    private Button ShowSensor;
    [SerializeField]
    private Vector2 itemSize = new Vector2(100, 100);
    [SerializeField]
    private int textSize = 30;
    private List<RectTransform> haveSensorHaveItems;
    private List<RectTransform> canSensorHaveItems;

    public GameObject UI_item;
    public override EnumUIPlaneType GetUIType()
    {
        return EnumUIPlaneType.FunctionObjectInformationPanel;
    }

    Dictionary<SensorType, RectTransform> haveSensors;
    Dictionary<SensorType, RectTransform> choseSensors;
    /// <summary>
    /// 添加元素
    /// </summary>
    /// <param name="item"></param>
    public void HaveSensorAddItem(SensorType item)
    {
        if (haveSensors.ContainsKey(item))
        {
            return;
        }
        Type type = SensorPrefabPath.GetSensorScript(item);
        GameObject SensorTemp = Resources.Load(SensorPrefabPath.GetPath(item)) as GameObject;
      





    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="item"></param>
    public void CanChoseSensorAddItem(RectTransform item)
    {

    }

    /// <summary>
    /// 去除HaveSensorScrollView上的元素
    /// </summary>
    /// <param name="itemd"></param>
    public void RemoveHaveSensorAddItem(RectTransform itemd)
    {

    }
    
    public void OpenAndClose_haveSensorSV()
    {
        if (haveSensorSV.gameObject.active==false)
        {
            canChoseSensorSV.gameObject.SetActive(false);
            haveSensorSV.gameObject.SetActive(true);
        }
        else
        {
            haveSensorSV.gameObject.SetActive(false);
        }
    }
    public void OpenAndClose_canChoseSensorSV()
    {
        if (canChoseSensorSV.gameObject.active == false)
        {
            haveSensorSV.gameObject.SetActive(false);
            canChoseSensorSV.gameObject.SetActive(true);
        }
        else
        {
            canChoseSensorSV.gameObject.SetActive(false);
        }
    }


    /// <summary>
    /// s生成一个可选元素
    /// </summary>
    private GameObject creatScollViewItem(Sprite sp,string name,RectTransform parent,Vector3 pos)
    {
        GameObject temp = new GameObject();
        GameObject temptT = new GameObject();
        temp.AddComponent<RectTransform>();
        temptT.AddComponent<RectTransform>();
        temptT.AddComponent<Text>();
        temp.transform.SetParent(parent);
        temptT.transform.SetParent(temp.transform);
        temp.AddComponent<Image>();
        temp.AddComponent<Button>();
        temp.GetComponent<Image>().sprite = sp;
        temp.GetComponent<RectTransform>().sizeDelta = itemSize;
        temptT.GetComponent<RectTransform>().sizeDelta = new Vector2(itemSize.x, textSize);
        temp.GetComponent<RectTransform>().localPosition = pos;
        temptT.GetComponent<RectTransform>().localPosition = new Vector3(0,textSize / 2+itemSize.y/2,0);
        temptT.GetComponent<Text>().text = name;

        //temptT.GetComponent<Text>()
        


        return temp;
    }



}
