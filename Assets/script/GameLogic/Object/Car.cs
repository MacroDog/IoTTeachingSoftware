using UnityEngine;
using System.Collections;

public class Car : MonoBehaviour {
    public enum carState
    {
        None,
        Run,
        Stop
    }
    private carState m_carState=carState.None;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    //移动
    public void moveTo(Transform pos)
    {

    }
    private void rayCheck()
    {

    }
    private void changeCarState(carState newstate)
    {
        switch (newstate)
        {
            case carState.None:
                break;
            case carState.Run:
                break;
            case carState.Stop:
                break;
            default:
                break;
        }
    } 



}
