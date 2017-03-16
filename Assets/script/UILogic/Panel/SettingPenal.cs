using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;

public class SettingPenal : BaseUI
{
    private Dropdown screenResource;
    public override EnumUIPlaneType GetUIType()
    {
        return EnumUIPlaneType.SettingPenal;
    }
    protected override void OnState()
    {
        base.OnState();
        screenResource = transform.GetComponentInChildren<Dropdown>();
    }


}
