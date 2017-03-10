using UnityEngine;
using System.Collections;





public delegate void StateChangeEvent(object ui, EnumObjectState oldState, EnumObjectState newState);


public enum EnumObjectState
{
    None,
    Initial,
    Loading,
    Ready,
    Disable,
    Closing
}


public enum EnumUIPlaneType : int
{
    MainInterface = 0,
    LoadInterface = 1,
}
public class UIPathDefines
{
    public const string UI_PREFAB = "UIPrefabs/";


    public const string UI_CONTROLS_PAEFAB = "UI_Controls_Prefabs/";
    public static string GetPrefabsPathByType(EnumUIPlaneType type)
    {
        string path = string.Empty;
        switch (type)
        {
            case EnumUIPlaneType.MainInterface:
                path = UI_PREFAB + "MainInterface";
                break;
            case EnumUIPlaneType.LoadInterface:
                path = UI_PREFAB + "LoadInterface";
                break;
            default:
                break;
        }
        return path;
    }
    public static System.Type GetUIScriptType(EnumUIPlaneType _uiType)
    {
        System.Type temp = null;
        switch (_uiType)
        {
            case EnumUIPlaneType.MainInterface:
                temp = typeof(MainInterface);
                break;
            case EnumUIPlaneType.LoadInterface:
                temp = typeof(LoadInterface);
                break;
            default:
                break;
        }
        return temp;
    }
}
public class Defines
{
    public Defines()
    {

    }

}
