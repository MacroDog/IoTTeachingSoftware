using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
public class MainInterface : BaseUI
{
    private Button OpenChosePanel;
    public EnumUIPlaneType childPanel=EnumUIPlaneType.MainInterface;//子界面 只允许打开一个子界面
    //private Dictionary<string, GameObject> dicChildPanel;//用来管理子界面
    public override EnumUIPlaneType GetUIType()
    {
        return EnumUIPlaneType.MainInterface;
    }
    protected override void OnState()
    {
        base.OnState();
        OpenModuleCognitionPenal();

    }
    //protected override void OnState()
    // {
    //     base.OnState();
    //     dicChildPanel = new Dictionary<string, GameObject>();
    //     for (int i = 0; i < childPanel.Length; i++)
    //     {
    //         dicChildPanel.Add(childPanel[i].name, childPanel[i].gameObject);
    //         childPanel[i].gameObject.SetActive(false);
    //     }
    //     childPanel[0].gameObject.SetActive(true);
    // }


    ///// <summary>
    ///// 打开子界面并关闭其它子面板
    ///// </summary>
    ///// <param name="str"></param>
    //public void OpenChildPanel_CloseOther(string str)
    //{
    //    List<string> keys = new List<string>(dicChildPanel.Keys);
    //    for (int i = 0; i < keys.Count; i++)
    //    {
    //        GameObject temp = null;
    //        if (keys[i]!=str)
    //        {
    //            if (dicChildPanel.TryGetValue(keys[i], out temp))
    //            {
    //                temp.SetActive(false);
    //            }
    //        }
    //        else
    //        {
    //            dicChildPanel.TryGetValue(keys[i],out temp);
    //            temp.SetActive(true);
    //        }    
    //    }
    //}

    ///// <summary>
    ///// 设置分辨率
    ///// </summary>
    //public void SetResolution()
    //{

    //}
    /// <summary>
    /// 退出登录
    /// </summary>
    public void QuitLogin()
    {
        SceneManager.LoadScene("Login");
    }

    /// <summary>
    /// 进入主场景
    /// </summary>
    public void EnterTheMainGame()
    {
        SceneManager.LoadScene("MainGame");
    }

    private void OpenChildPanel(EnumUIPlaneType type)
    {
        if (type==childPanel)
        {
            return;
        }
        if (childPanel != EnumUIPlaneType.MainInterface)
        {
            UIManager.Instance.OpenUI(type);
            UIManager.Instance.CloseUI(childPanel);
            childPanel = type;
        }
        else
        {
            UIManager.Instance.OpenUI(type);
            childPanel = type;
        }
    }

    /// <summary>
    /// 打开模块认知
    /// </summary>
    public void OpenModuleCognitionPenal()
    {
        OpenChildPanel(EnumUIPlaneType.ModuleCognitionPenal);


    }

    /// <summary>
    /// 打开模块认知
    /// </summary>
    public void OpenMainGamePanel()
    {
        OpenChildPanel(EnumUIPlaneType.MainGamePanel);
    }

    /// <summary>
    /// 打开测试系统
    /// </summary>
    public void OpenExamPanel()
    {
        OpenChildPanel(EnumUIPlaneType.ExamPenal);
    }

    /// <summary>
    /// 打开设置面板
    /// </summary>
    public void OpenSettingPanel()
    {
        OpenChildPanel(EnumUIPlaneType.SettingPenal);
    }

    
}
