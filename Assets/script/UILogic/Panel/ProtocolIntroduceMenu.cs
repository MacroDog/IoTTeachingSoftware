using UnityEngine;
using System.Collections;
using System;
using UnityEngine.SceneManagement;
public class ProtocolIntroduceMenu : BaseUI
{
    public override EnumUIPlaneType GetUIType()
    {
        return EnumUIPlaneType.ProtocolIntroduceMenu;
    }

    /// <summary>
    /// 返回主界面
    /// </summary>
    public void ReturnMainInterface()
    {
        SceneManager.LoadScene("MainInterfaceScene");
    }

    public void showBox ()
    {
        Debug.Log("show");
    }
}
