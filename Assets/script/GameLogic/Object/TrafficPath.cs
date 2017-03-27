using UnityEngine;
using System.Collections;
using System.Collections.Generic;


//交通路线
public class TrafficPath : MonoBehaviour
{

    [SerializeField]
    private List<Transform> wayPoints;



    private void Start()
    {
        wayPoints = new List<Transform>(GetComponentsInChildren<Transform>());
    }


    //返回下一个wayspoint
    public Transform GetnetWayPoint(Transform item)
    {
        if (wayPoints.Contains(item))
        {
            int i = wayPoints.IndexOf(item);
            if (i++<wayPoints.Count)
            {
                return wayPoints[i];
            }
            else
            {
                return wayPoints[0];
            }
        }
        else
        {
            return null;
        }
    }

}
