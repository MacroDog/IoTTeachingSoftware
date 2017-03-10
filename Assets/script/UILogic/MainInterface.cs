using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;
public class MainInterface : BaseUI {

    private Image[] chosePanel;//子界面

    public override EnumUIPlaneType GetUIType()
    {
        return EnumUIPlaneType.MainInterface;
    }

    public void changeChosePanel(string name)
    {
       
    }
    public void loader(string str)
    {
        SceneManager.LoadScene(str);
    }
}
