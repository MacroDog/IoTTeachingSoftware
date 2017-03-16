using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;
public class ToolsDisplayPanel : BaseUI {
    [SerializeField]
    private GameObject ShowTool;//展示目标工具
    [SerializeField]
    private RawImage toolShowImaga;
    [SerializeField]
    private EventTrigger toolShowEventTrigger;
    private bool isRotate;
    private Vector3 m_RotationDir;
    public float m_rotateSpeed;
   
    public override EnumUIPlaneType GetUIType()
    {
        return EnumUIPlaneType.ToolsDisplayPanel;
    }
    protected override void SetUI(params object[] UIParams)
    {
        base.SetUI(UIParams);
        ShowTool = UIParams[0]as GameObject;
        ShowTool = MonoBehaviour.Instantiate(ShowTool, new Vector3(0, 0, 1.5f), Quaternion.identity)as GameObject;
    }
    protected override void OnState()
    {
        base.OnState();
        m_RotationDir = new Vector3(0,0,0);
        initToolsShowImage();
    }
    protected override void OnUpdate()
    {
        if (isRotate==true)
        {
            m_RotationDir .y= Input.GetAxis("Mouse X") * m_rotateSpeed;
            m_RotationDir.x = Input.GetAxis("Mouse Y") * m_rotateSpeed;
            ShowTool.transform.rotation *= Quaternion.Euler(m_RotationDir);
        }
    }
    private void initToolsShowImage()
    {
        toolShowImaga = transform.FindChild("ToolsShow").GetComponent<RawImage>();
        toolShowEventTrigger = toolShowImaga.GetComponent<EventTrigger>();
        if (toolShowEventTrigger == null)
        {
            toolShowEventTrigger = toolShowImaga.gameObject.AddComponent<EventTrigger>();
        }
        EventTrigger.Entry DownEntry = new EventTrigger.Entry();
        EventTrigger.Entry UpEntry = new EventTrigger.Entry();
        UpEntry.eventID = EventTriggerType.PointerUp;
       
       
        DownEntry.eventID = EventTriggerType.PointerDown;
        DownEntry.callback = new EventTrigger.TriggerEvent();
        UpEntry.callback = new EventTrigger.TriggerEvent();
        UnityAction<BaseEventData> DownCallback = new UnityAction<BaseEventData>(beginRotateTargetObject);
        UnityAction<BaseEventData> UpCallback = new UnityAction<BaseEventData>(endRotateTargetObject);
        DownEntry.callback.AddListener(DownCallback);
        UpEntry.callback.AddListener(UpCallback);
        toolShowEventTrigger.triggers.Add(DownEntry);
        toolShowEventTrigger.triggers.Add(UpEntry);
        
    }

    private void beginRotateTargetObject(BaseEventData baseevent)
    {
        isRotate = true;
    }
    private void endRotateTargetObject(BaseEventData baseevent)
    {
        isRotate = false;
    }
    protected override void OnRelease()
    {
        base.OnRelease();
        if (ShowTool!=null)
        {
            Destroy(ShowTool);
        }
       
    }
    public void Return()
    {
        UIManager.Instance.OpenUI(EnumUIPlaneType.FunctionSceneMenu, true, null);
    }
    public void TestDebug()
    {
        Debug.Log ("test");
    }
    public void Rest()
    {
        if (ShowTool!=null)
        {
            ShowTool.transform.rotation = Quaternion.identity;
        }
    }
}
