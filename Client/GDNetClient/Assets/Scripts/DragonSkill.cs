using Net.Component;
using Net.Share;
using Net.UnityComponent;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonSkill : MonoBehaviour
{
    public float speed = 10f;       // �����ٶ�
    public float dashSpeed;         // ����ٶ�
    //public float dashTime = Time.deltaTime;     // ���ʱ�� 
    public bool isDash = false;            // �Ƿ��ڳ��״̬
    const float maxDashTimeLeft = 5f;    // ��̼��ܳ���ʱ��


    public void Dash()
    {
        //gameObject.GetComponent<PlayerController>().speed = 100;
        isDash = true;
        dashSpeed = 2f * speed;      // ���ó���ٶ�
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
