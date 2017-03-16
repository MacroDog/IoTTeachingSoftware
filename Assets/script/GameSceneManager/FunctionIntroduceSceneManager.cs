using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class FunctionIntroduceSceneManager : MonoBehaviour
{

    private void Start()
    {
        UIManager.Instance.OpenUI(EnumUIPlaneType.FunctionSceneMenu);
    }

}
