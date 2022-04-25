using Net.Component;
using Net.Share;
using Net.UnityComponent;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonSkill : MonoBehaviour
{
    public float speed = 10f;       // 正常速度
    public float dashSpeed;         // 冲刺速度
    //public float dashTime = Time.deltaTime;     // 冲刺时间 
    public bool isDash = false;            // 是否处于冲刺状态
    const float maxDashTimeLeft = 5f;    // 冲刺技能持续时间


    public void Dash()
    {
        //gameObject.GetComponent<PlayerController>().speed = 100;
        isDash = true;
        dashSpeed = 2f * speed;      // 设置冲刺速度
        if (isDash)
        {
            //float dashTimeLeft = Time.deltaTime - dashTime;

            //if (dashTimeLeft > maxDashTimeLeft)
            //{
            //    isDash = false;
            //    gameObject.GetComponent<PlayerController>().speed = 10f;
            //}
            //else
            //{
                gameObject.GetComponent<PlayerController>().speed = dashSpeed;
           // }
        }
        
    }

}
