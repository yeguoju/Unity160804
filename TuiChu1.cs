using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;//在跳转Scene时要用的
using System;//在 用String.Format（“”）时用的

public class TuiChu1 : MonoBehaviour
{
    public float i1 = 0;
    public float i2 = 0;
    public int CiShu = 0;//次数
    //&& Application.platform == RuntimePlatform.
    //  Android && Input.GetKey(KeyCode.Home) //手机退出键
    //int a=0;暂时用不到，等要按两次退出键时才来解封
    //Time.time 当前游戏时间
    // Update is called once per frame

    void Update()
    {
        // Debug.Log(Time.time);
        // Debug.Log(Time.time+"kk");
        // Debug.Log(Time.time);==0。。。0.5。。。1 是从0开始增加的
        if (Input.GetKeyDown(KeyCode.Escape))//按手机：返回键
        {
            CiShu += 1;//按一次就加一次
            if (CiShu == 1) { i1 = Time.time; }//记录第一次按下返回键的时间

            if (CiShu == 2)
            {
                i2 = Time.time;//记录第二次按下返回键的时间

                if (i2 - i1 <= 2f)
                {//第二次 减 第一次的时间在2秒内，就执行
                    Application.Quit();//退出
                }
                else//否则次数归还为0
                {
                    CiShu = 0;
                }
            }


        }

    }
    void OnGUI()//显示Text
    {
        GUI.skin.label.fontSize = 50;
        //20, 700,位置  600, 600宽高
        GUI.Label(new Rect(20, 700, 600, 600), "i1时间: " + i1 + " i2时间:" + i2 + " CiShu次数:" + CiShu);
       
    }
    /*                      失败的逻辑
       void Update() {
       // Debug.Log(Time.time);==0。。。0.5。。。1 是从0开始增加的
        if (Input.GetKey(KeyCode.Escape))//按手机：返回键
        {
            if (Time.time-i1<200f) {//2秒内，再按（手机：返回键）就执行
                Application.Quit();//退出
            }
       

        }
        i1 = Time.time;//i1  ==  记录按下返回键时的当前时间（ Time.time）
                       //Debug.Log(Time.time);
                       //逻辑 i1是5秒，但我按下后是6秒，6-5怎样都小于2.。。Time.time-i1<2f所以判断不合心意

    }*/
}
