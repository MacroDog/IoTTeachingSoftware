using UnityEngine;
using System.Collections;
using System;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
public class FunctionSceneMenu : BaseUI
{
    [SerializeField]
    ShowToolsButton[] ToolButton;
    public override EnumUIPlaneType GetUIType()
    {
        return EnumUIPlaneType.FunctionSceneMenu;
    }
    /// <summary>
    /// 打开下个UI要求
    /// </summary>
    /// <param name="tools"></param>
    protected override void OnState()
    {
        base.OnState();
        ToolButton= transform.GetComponentsInChildren<ShowToolsButton>();
        Debug.Log(ToolButton.Length);
        for (int i = 0; i < ToolButton.Length; i++)
        {

            //UnityAction<GameObject>asd = new UnityAction<GameObject>(ObserverTool);
            //ToolButton[i].M_Button.onClick.AddListener(asd);
            Debug.Log("tool0"+i);
            GameObject temp = ToolButton[i].gameObject;
            ToolButton[i].M_Button.onClick.AddListener(delegate () { this.ObserverTool(temp); });
            Debug.Log("tools"+i);
        }
    }
    private void openTollDisplayPanelUI(GameObject tool)
    {
        
        if (tool!=null)
        {
           UIManager.Instance.OpenUI(EnumUIPlaneType.ToolsDisplayPanel, true, tool);
        }
    }
    /// <summary>
    /// 观察物体
    /// </summary>
    /// <param name="str"></param>
    public void ObserverTool(GameObject seder)
    {
        Debug.Log(seder.name);
        openTollDisplayPanelUI(seder.GetComponent<ShowToolsButton>().tool);
    }
    /// <summary>
    /// 返回主菜单
    /// </summary>
    public void Return()
    {
        SceneManager.LoadScene("MainInterfaceScene");
    }
}
