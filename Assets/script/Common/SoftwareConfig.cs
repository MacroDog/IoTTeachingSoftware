using UnityEngine;
using System.Collections;
using System;

public  class Resolution 
{
    public static int width { get; private set; }
    public static int hight { get; private set; }
    public  Resolution(int Width, int Hight)
    {
        width = Width;
        hight = Hight;
    }
       
}
//软件配置 
public  class SoftwareConfig:Singleton<SoftwareConfig>
{
    //public Resources ScenResources { get;private set; }
   

}
