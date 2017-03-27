using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
public class MainInterface : BaseUI
{
    [SerializeField]
    private Button[] chooseButton;//开启子界面的按钮
    private Button selectedButton;//当前打开界面的按钮
    private EnumUIPlaneType childPanel=EnumUIPlaneType.MainInterface;//子界面 只允许打开一个子界面
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
    protected override void Init()
    {
        base.Init();
    }

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
