using UnityEngine;
using System.Collections;

public class ProtocolIntroduceSceneManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
        UIManager.Instance.OpenUI(EnumUIPlaneType.ProtocolIntroduceMenu);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
