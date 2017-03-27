
using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine.UI;
public class FunctionObjectInformationPanel : BaseUI {


    public Action<SensorType> Action_RemoveHaveSensor;
    public Action<SensorType> Action_AddHaveSensor;
    [SerializeField]
    private ScrollRect haveSensorSV;
    [SerializeField]
    private ScrollRect canChoseSensorSV;
    [SerializeField]
    private Button SetSensor;
    [SerializeField]
    private Button ShowSensor;
    [SerializeField]
    private Vector2 itemSize = new Vector2(100, 100);//元素大小
    [SerializeField]
    private int textSize = 30;//元素text文本的大小
    [SerializeField]
    private int lineSpacing = 5;//每个元素之间的行间距
    [SerializeField]
    private Font m_font;
    private List<RectTransform> haveSensorHaveItems=new List<RectTransform>();
    private List<RectTransform> canSensorHaveItems=new List<RectTransform> ();
    
    private float haveSensorSVContentHight;//已有用传感器面板元素容器高度
    private float canChoseSensorSVContentHight;//可选择传感器元素容器高度

    private float haveSensorSVContentItemYPostion=0;
    private float canChoseSensorSVContentYPostion=0;
    public GameObject UI_item;
    public override EnumUIPlaneType GetUIType()
    {
        return EnumUIPlaneType.FunctionObjectInformationPanel;
    }

    Dictionary<SensorType, GameObject> haveSensorsDic=new Dictionary<SensorType, GameObject> ();
    Dictionary<SensorType, GameObject> choseSensorsDic=new Dictionary<SensorType, GameObject> ();
    /// <summary>
    /// 已拥有传感器面板添加元素
    /// </summary>
    /// <param name="item"></param>
    private void HaveSensorAddItem(GameObject sensor)
    {
        //Debug.Log(sensor.name);
        if (!sensor.GetComponent<Sensor>())
        {
            return;
        }
        if (haveSensorsDic.ContainsKey(sensor.GetComponent<Sensor>().getSonserType()))
        {
            return;
        }
        haveSensorSVContentHight += itemSize.y+textSize+lineSpacing;
        haveSensorSV.content.GetComponent<RectTransform>().sizeDelta = new Vector2(0, haveSensorSVContentHight);
        GameObject Element = creatScollViewItem(sensor.GetComponent<Sensor>().getSonserIcon(), sensor.GetComponent<Sensor>().getSoncserName(), haveSensorSV.content, new Vector3(0, haveSensorSVContentItemYPostion, 0));
        haveSensorSVContentItemYPostion = haveSensorSVContentItemYPostion - itemSize.y - textSize - lineSpacing;
        
        //添加点击事件
        var sensortype = sensor.GetComponent<Sensor>().getSonserType();
        haveSensorsDic.Add(sensortype, Element);
        //Debug.Log(Element.GetComponent<RectTransform>().localPosition);
        Element.GetComponent<Button>().onClick.AddListener(delegate () { RemoveHaveSensorItem(sensortype); });//移除已拥有的
        Action_AddHaveSensor(sensortype);
    }

    /// <summary>
    /// 可选择传感器添加元素
    /// </summary>
    /// <param name="item"></param>
    private void CanChoseSensorAddItem(GameObject sensor)
    {
        if (!sensor.GetComponent<Sensor>())
        {
            return;
        }
        if (choseSensorsDic.ContainsKey(sensor.GetComponent<Sensor>().getSonserType()))
        {
            return;
        }
        canChoseSensorSVContentHight += itemSize.y + textSize + lineSpacing;
        GameObject Element = creatScollViewItem(sensor.GetComponent<Sensor>().getSonserIcon(), sensor.GetComponent<Sensor>().getSoncserName(), canChoseSensorSV.content, new Vector3(0, canChoseSensorSVContentYPostion, 0));
        canChoseSensorSVContentYPostion = canChoseSensorSVContentYPostion- itemSize.y - textSize - lineSpacing;
        canChoseSensorSV.content.GetComponent<RectTransform>().sizeDelta = new Vector2(0, canChoseSensorSVContentHight);
        //添加点击事件
        var sensortype = sensor.GetComponent<Sensor>().getSonserType();
        choseSensorsDic.Add(sensortype, Element);
        Element.GetComponent<Button>().onClick.AddListener(delegate () { HaveSensorAddItem(sensor); });//安装传感器

    }

    /// <summary>
    /// 去除HaveSensorScrollView上的元素
    /// </summary>
    /// <param name="itemd"></param>
    public void RemoveHaveSensorItem(SensorType sensorType)
    {
        if (haveSensorsDic.ContainsKey(sensorType))
        {
            //Debug.Log("remove" + sensorType.ToString());
            GameObject item;
            haveSensorsDic.TryGetValue(sensorType, out item);
            //重新设置Context高度
            haveSensorSVContentHight-= itemSize.y + textSize + lineSpacing;
            haveSensorSV.content.GetComponent<RectTransform>().sizeDelta = new Vector2(0, haveSensorSVContentHight);
            Action_RemoveHaveSensor(sensorType);
            haveSensorsDic.Remove(sensorType);
            Destroy(item);
            List<GameObject> temp = new List<GameObject>(haveSensorsDic.Values);
            haveSensorSVContentItemYPostion= sortList(temp);
            Action_RemoveHaveSensor(sensorType);
        }
    }

    /// <summary>
    /// 去除CanChoseSensor元素
    /// </summary>
    /// <param name="sensortype"></param>
    public void RemoveCanChoseSensorItem(SensorType sensortype)
    {
        if (choseSensorsDic.ContainsKey(sensortype))
        {
            GameObject item;
            choseSensorsDic.TryGetValue( sensortype, out item);
            choseSensorsDic.Remove(sensortype);
            Destroy(item);
            //重新设置Context高度
            canChoseSensorSVContentHight -= itemSize.y + textSize + lineSpacing;
            canChoseSensorSV.content.GetComponent<RectTransform>().sizeDelta = new Vector2(0, canChoseSensorSVContentHight);
           
        }
    }

    private float sortList(List<GameObject> item)
    {
        float hight=-itemSize.y/2;
        for (int i = 0; i < item.Count; i++)
        {
            item[i].GetComponent<RectTransform>().anchoredPosition = new Vector2(0, hight);
            hight -= (itemSize.y + lineSpacing + textSize);
        }
        return hight;
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
    /// 生成一个可选元素
    /// </summary>
    private GameObject creatScollViewItem(Sprite sp,string name,RectTransform parent,Vector3 pos)
    {
        GameObject temp = new GameObject();
        GameObject temptT = new GameObject();
        RectTransform tempR= temp.AddComponent<RectTransform>();
        RectTransform tempTR= temptT.AddComponent<RectTransform>();
        temptT.AddComponent<Text>();
       
        temp.transform.SetParent(parent);
        tempR.anchorMin = tempR.anchorMax = new Vector2(0.5f, 1);
        temptT.transform.SetParent(temp.transform);
        temp.AddComponent<Image>();
        temp.AddComponent<Button>();
        temp.GetComponent<Image>().sprite = sp;
        tempR.sizeDelta = itemSize;
        tempTR.sizeDelta = new Vector2(itemSize.x, textSize);
        tempR.anchoredPosition = pos;
        //Debug.Log(pos);
        tempR.localScale = new Vector3(1, 1, 1);
        tempTR.localPosition = new Vector3(0,-(textSize / 2+itemSize.y/2),0);
        Text tex = tempTR.GetComponent<Text>();
        tex.text = name;
        tex.font = m_font;
        tex.fontSize = 20;
        tex.alignment = TextAnchor.MiddleCenter;
        tex.color = Color.black;

       
        //temptT.GetComponent<Text>()



        return temp;
    }
    protected override void SetUI(params object[] UIParams)
    {
        base.SetUI(UIParams);
        this.transform.position = Input.mousePosition;

        haveSensorSVContentItemYPostion = -itemSize.y / 2;
        canChoseSensorSVContentYPostion = -itemSize.y / 2;
        GameObject GO = UIParams[0] as GameObject;
        FunctionObject FCO = GO.GetComponent<FunctionObject>();
        Action_AddHaveSensor += FCO.InstallSensor;
        Action_RemoveHaveSensor += FCO.UninstallSensor;
        Debug.Log(GO.name);
        Debug.Log(FCO.CanInstallSensor.Count);
        for (int i = 0; i < FCO.CanInstallSensor.Count; i++)
        {
            GameObject ga = Resources.Load(SensorPrefabPath.GetPath(FCO.CanInstallSensor[i]))as GameObject;
            CanChoseSensorAddItem(ga);
            Debug.Log(ga.name);
        }
        for(int i = 0; i < FCO.Install.Count; i++)
        {
            GameObject ga = Resources.Load(SensorPrefabPath.GetPath(FCO.Install[i])) as GameObject;
            HaveSensorAddItem(ga);
        }

    }
    protected override void Init()
    {
        base.Init();
       
    }



}
