
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class WorldSpaceCanvas : MonoBehaviour {
    private Canvas _canvas;



    private void Awake()
    {
        _canvas=this.GetComponent<Canvas>();


    }
    // Use this for initialization
    void Start () {
        _canvas = this.GetComponent<Canvas>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    private void FixedUpdate()
    {
        if (_canvas.worldCamera!=null)
        {
            //transform.LookAt(_canvas.worldCamera.transform);
        }
        
    }
}
