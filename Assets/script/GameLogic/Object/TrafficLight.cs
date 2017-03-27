
using UnityEngine;
using System.Collections;



public class TrafficLight : MonoBehaviour
{
    public enum TrafficLightEnum
    {
        None,
        Green,
        Red,
        Yellow
    }
    [SerializeField]
    private Material black;
    [SerializeField]
    private Material yellow;
    [SerializeField]
    private Material red;
    [SerializeField]
    private Material green;
    [SerializeField]
    private GameObject greenLight;
    [SerializeField]
    private GameObject yellowLight;
    [SerializeField]
    private GameObject redLight;


    private TrafficLightEnum TrafficLightState;

    public float GreenTime
    {
        get;
        private set;
    }
    public float RedTime
    {
        get;
        private set;
    }

    private bool isRun = true;
    private float LightTimer;


    private void Start()
    {
        GreenTime = 20;
        RedTime = 25;
        StartCoroutine(Change());
    }

    /// <summary>
    /// 改变挡墙状态
    /// </summary>
    /// <returns></returns>
    private IEnumerator Change()
    {
        while (isRun)
        {
            ChangeState(TrafficLightEnum.Green);
            yield return (new WaitForSeconds(LightTimer));
            ChangeState(TrafficLightEnum.Yellow);
            yield return (new WaitForSeconds(3));
            ChangeState(TrafficLightEnum.Red);
            yield return (new WaitForSeconds(LightTimer));
        }

    }

    public void SetGreenTime(float time)
    {
        if (time > 0 && time != GreenTime)
        {
            GreenTime = time;
        }
    }
    public void SetRedTime(float time)
    {
        if (time > 0 && time != RedTime)
        {
            GreenTime = RedTime;
        }
    }
    private void ChangeState(TrafficLightEnum state)
    {
        switch (state)
        {
            case TrafficLightEnum.None:
                break;
            case TrafficLightEnum.Green:
                greenLight.GetComponent<MeshRenderer>().material = green;
                redLight.GetComponent<MeshRenderer>().material = yellowLight.GetComponent<MeshRenderer>().material = black;
                LightTimer = GreenTime;
                TrafficLightState = TrafficLightEnum.Green;
                
                break;
            case TrafficLightEnum.Red:
                redLight.GetComponent<MeshRenderer>().material = red;
                yellowLight.GetComponent<MeshRenderer>().material = greenLight.GetComponent<MeshRenderer>().material = black;
                LightTimer = RedTime;
                TrafficLightState = TrafficLightEnum.Red;
                break;
            case TrafficLightEnum.Yellow:
                yellowLight.GetComponent<MeshRenderer>().material = yellow;
                redLight.GetComponent<MeshRenderer>().material = greenLight.GetComponent<MeshRenderer>().material = black;
                LightTimer = 3;
                TrafficLightState = TrafficLightEnum.Yellow;
                break;
            default:
                break;
        }
    }
    public void Green()
    {

    }
    public void Red()
    {
        
    }
    public void Yellow()
    {

    }



}
