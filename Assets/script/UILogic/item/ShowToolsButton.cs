using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;


[RequireComponent(typeof(Button))]
public class ShowToolsButton:MonoBehaviour
{
    
    public GameObject Tool;
    public GameObject tool { get; private set; }
    public Image Icon;
    public  Image icon { get; private set; }
    public string ToolName;
    public string toolName { get; private set; }
    public Button M_Button;

    /// <summary>
    /// 初始化当前UI
    /// </summary>
    private void Awake()
    {
        tool = Tool;
        toolName = ToolName;
        icon = Icon;
        M_Button = this.GetComponent<Button>();
    }
   

    

}
