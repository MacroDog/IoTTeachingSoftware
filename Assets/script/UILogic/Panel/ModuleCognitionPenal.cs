using UnityEngine;
using System.Collections;
using System;

public class ModuleCognitionPenal : BaseUI
{
    public override EnumUIPlaneType GetUIType()
    {
        return EnumUIPlaneType.ModuleCognitionPenal;
    }
    public void LoadProtocolClass()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("ProtocolIntroduce");
    }
    public void LoadFunctionIntroduce()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("FunctionIntroduce");
    }
}
