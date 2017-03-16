using UnityEngine;
using System.Collections;

public class MainInterfaceSceneManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
        UIManager.Instance.CloseUIAll();
        UIManager.Instance.OpenUI(EnumUIPlaneType.MainInterface);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
