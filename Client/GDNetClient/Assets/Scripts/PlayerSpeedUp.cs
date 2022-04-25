using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerSpeedUp : MonoBehaviour
{
    public void SpeedUp()
    {
        //ÐÞ¸ÄËÙ¶È
        gameObject.GetComponent<PlayerController>().speed = 100;
    }
}
