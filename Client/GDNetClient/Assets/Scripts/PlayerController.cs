using Net.Component;
using Net.Share;
using Net.UnityComponent;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 10f;
    public float Duration = 5;//持续时间
    public float timer ;    //计时器 
    bool duration = false;
    DragonSkill dragonSkill;

    public float horizontal;
    public float vertical;

    public Animator animator;


    Rigidbody2D rbody;
    Vector2 lookDirection = new Vector2(0, -1);

    private void Update()
    {
        //调整子弹发射方向
        if(Input.GetAxis("Horizontal")!=0|| Input.GetAxis("Vertical")!=0)
        {
            horizontal = Input.GetAxis("Horizontal");
            vertical = Input.GetAxis("Vertical");
        }


        //冲刺
        if (Input.GetKeyDown(KeyCode.J))
        {
            var _index = GetComponent<NetworkTransform>().netObj.identity;
            ClientManager.AddOperation(new Operation(MyCommand.Dash, _index));
        }


        //移动函数
        float horizontalMove = Input.GetAxis("Horizontal");
        float verticalMove = Input.GetAxis("Vertical");
        if (horizontalMove != 0 || verticalMove != 0)
        {
            transform.Translate(new Vector3(horizontalMove, verticalMove, 0f) * speed * Time.deltaTime);
            animator.SetFloat("running", Mathf.Abs(horizontalMove == 0 ? verticalMove : horizontalMove));
        }


        //变换障碍物
        if (Input.GetKeyDown(KeyCode.Alpha0))//当按下数字0时
        {
            var _index = GetComponent<NetworkTransform>().netObj.identity;
            ClientManager.AddOperation(new Operation(MyCommand.Deformation, _index));

        }

        if (Input.GetAxisRaw("Horizontal") != 0)
            transform.localScale = new Vector3(Input.GetAxisRaw("Horizontal"), 1, 1);
        

                //按C发送改变Player颜色指令 TransformComponent
                if (Input.GetKeyDown(KeyCode.C))
                {
                    var _index = GetComponent<NetworkTransform>().netObj.identity;
                    ClientManager.AddOperation(new Operation(MyCommand.ChangePlayerColor, _index)
                    {
                        buffer = new byte[]
                                {
                                   (byte)Random.Range(0,255),    //R
                                   (byte)Random.Range(0,255),    //G
                                   (byte)Random.Range(0,255)     //B
                                }
                    });
                }

        //猎人按空格发射子弹 GetComponent<NetworkTransform>().netObj.registerObjectIndex网络唯一标识符
        if (Input.GetKeyDown(KeyCode.Space)&& GetComponent<NetworkTransform>().netObj.registerObjectIndex==0) 
        {
            var _index = GetComponent<NetworkTransform>().netObj.identity;
            ClientManager.AddOperation(new Operation(MyCommand.Fire, _index));
        }

        //按X猎人放置夹子，夹子对猎物隐藏
        if (Input.GetKeyDown(KeyCode.X) && GetComponent<NetworkTransform>().netObj.registerObjectIndex == 0)
        {
            var _index = GetComponent<NetworkTransform>().netObj.identity;
            ClientManager.AddOperation(new Operation(MyCommand.Clip, _index));
        }
        if (Input.GetKeyDown(KeyCode.X) /*&& GetComponent<NetworkTransform>().netObj.registerObjectIndex == 1*/)
        {
            var _index = GetComponent<NetworkTransform>().netObj.identity;
            ClientManager.AddOperation(new Operation(MyCommand.SpeedUp, _index));

            //开始计时，记录技能只能持续5秒
            duration = true;
            timer = 0;
        }

        //技能持续时间
        if (duration == true)
        {
            if (timer > Duration)
            {
                //Debug.Log("timer" + timer);
                timer = 0;
                duration = false;
                gameObject.GetComponent<PlayerController>().speed = 8;
            }
            else
            {
                //Debug.Log("Time.deltaTime" + Time.deltaTime);
                timer += Time.deltaTime;
            }
        }
      
      
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {   //判断猎人是否碰到猎物了
        if (GetComponent<NetworkTransform>().netObj.registerObjectIndex == 0 && !collision.gameObject.tag.Equals("map") && !collision.gameObject.tag.Equals("mapflat") && !collision.gameObject.tag.Equals("Fire"))
            Destroy(collision.transform.gameObject);
        //判断猎物碰到猎人了
        else if (GetComponent<NetworkTransform>().netObj.registerObjectIndex == 1 && collision.gameObject.tag.Equals("hunter"))
        {
            Destroy(transform.gameObject);
        }

        

    }
    //子弹打中猎物，这里是当预制体为Is Trigger时处理碰撞检测的，如果是Is Trigger则没有碰撞体积
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Fire" && GetComponent<NetworkTransform>().netObj.registerObjectIndex == 1)
        {
            Destroy(collision.gameObject);
            Destroy(transform.gameObject);
        }
    }


}
