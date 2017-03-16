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
    ModuleCognitionPenal=2,
    MainGamePanel=3,
    ExamPenal=4,
    SettingPenal=5,
    ProtocolIntroduceMenu=6,
    FunctionSceneMenu=7,
    ToolsDisplayPanel=8,
   FunctionObjectInformationPanel=9
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
            case EnumUIPlaneType.MainGamePanel:
                path = UI_PREFAB + "MainGamePanel";
                break;
            case EnumUIPlaneType.ModuleCognitionPenal:
                path = UI_PREFAB + "ModuleCognitionPenal";
                break;
            case EnumUIPlaneType.SettingPenal:
                path = UI_PREFAB + "SettingPenal";
                break;
            case EnumUIPlaneType.ExamPenal:
                path = UI_PREFAB + "ExamPenal";
                break;
            case EnumUIPlaneType.ProtocolIntroduceMenu:
                path = UI_PREFAB + "ProtocolIntorduceManu";
                break;
            case EnumUIPlaneType.ToolsDisplayPanel:
                path = UI_PREFAB + "ToolsDisplayPanel";
                break;
            case EnumUIPlaneType.FunctionSceneMenu:
                path = UI_PREFAB + "FunctionSceneMenu";
                break;
            case EnumUIPlaneType.FunctionObjectInformationPanel:
                path = UI_PREFAB + "FunctionObjectInformationPanel";
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
            case EnumUIPlaneType.ModuleCognitionPenal:
                temp = typeof(ModuleCognitionPenal);
                break;
            case EnumUIPlaneType.SettingPenal:
                temp = typeof(SettingPenal);
                break;
            case EnumUIPlaneType.MainGamePanel:
                temp = typeof(MainGamePanel);
                break;
            case EnumUIPlaneType.ProtocolIntroduceMenu:
                temp = typeof(ProtocolIntroduceMenu);
                break;
            case EnumUIPlaneType.ToolsDisplayPanel:
                temp = typeof(ToolsDisplayPanel);
                break;
            case EnumUIPlaneType.FunctionSceneMenu:
                temp = typeof(FunctionSceneMenu);
                break;
            case EnumUIPlaneType.FunctionObjectInformationPanel:
                temp = typeof(FunctionObjectInformationPanel);
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
