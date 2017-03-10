using UnityEngine;
using System.Collections;

public class gameTest : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {
        float time = System.Environment.TickCount;
        for (int i = 0; i < 2000; i++)
        {
            GameObject go = null;
            ResManager.Instance.LoadAsyncInstantiate("Prefabs/Cube", (_obj) => { go = _obj as GameObject;
                go.transform.position = UnityEngine.Random.insideUnitSphere * 20;
            });
            
        }
        Debug.Log("Times: " + (System.Environment.TickCount - time) * 1000);
	}
	
	// Update is called once per frame
	void Update ()
    {
	    
	}
}
