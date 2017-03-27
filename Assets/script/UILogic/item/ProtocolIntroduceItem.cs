using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(EventTrigger))]
public class ProtocolIntroduceItem : MonoBehaviour {
    private EventTrigger eventTrigger;
   // public delegate void EventDelegate(UnityEngine.EventSystems.BaseEventData baseEvent);
    public GameObject IntroduceObj;//用于介绍的说明
    private GameObject _IntroduceObj;
    public Vector2 point;

    void Start()
    {
        init();
    }

    /// <summary>
    /// 初始化
    /// </summary>
    private void init()
    {
        eventTrigger = this.GetComponent<EventTrigger>();
        EventTrigger.Entry EnterEntry = new EventTrigger.Entry();
        EventTrigger.Entry ExitEntry = new EventTrigger.Entry();
        EnterEntry.eventID = EventTriggerType.PointerEnter;
        ExitEntry.eventID = EventTriggerType.PointerExit;
        EnterEntry.callback = new EventTrigger.TriggerEvent();
        ExitEntry.callback = new EventTrigger.TriggerEvent();
        UnityEngine.Events.UnityAction<BaseEventData> EnterCallbacke = new UnityEngine.Events.UnityAction<BaseEventData>(ShowIntroduce);
        UnityEngine.Events.UnityAction<BaseEventData> ExitCallbacke = new UnityEngine.Events.UnityAction<BaseEventData>(CloseIntroduce);
        EnterEntry.callback.AddListener(EnterCallbacke);
        ExitEntry.callback.AddListener(ExitCallbacke);
        eventTrigger.triggers.Add(EnterEntry);
        eventTrigger.triggers.Add(ExitEntry);
        
    }

   private void ShowIntroduce(UnityEngine.EventSystems.BaseEventData baseEvent)
    {

       _IntroduceObj= MonoBehaviour.Instantiate(IntroduceObj, GameObject.FindObjectOfType<Canvas>().transform) as GameObject ;
        RectTransform rectt= _IntroduceObj.GetComponent<RectTransform>();
         rectt.parent = this.transform.parent;
        rectt.pivot = point;
       // rectt.anchorMin = rectt.anchorMax;
       
        rectt.transform.position = Input.mousePosition;
        rectt.localScale= new Vector3(1, 1, 1);
    }
    private void CloseIntroduce(UnityEngine.EventSystems.BaseEventData baseEvent)
    {
        Destroy(_IntroduceObj);
    }
    
}
