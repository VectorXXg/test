using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerSpeedUp : MonoBehaviour
{
    public void SpeedUp()
    {
        //�޸��ٶ�
        gameObject.GetComponent<PlayerController>().speed = 100;
    }
}
