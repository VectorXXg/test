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
    public float Duration = 5;//����ʱ��
    public float timer ;    //��ʱ�� 
    bool duration = false;
    DragonSkill dragonSkill;

    public float horizontal;
    public float vertical;

    public Animator animator;


    Rigidbody2D rbody;
    Vector2 lookDirection = new Vector2(0, -1);

    private void Update()
    {
        //�����ӵ����䷽��
        if(Input.GetAxis("Horizontal")!=0|| Input.GetAxis("Vertical")!=0)
        {
            horizontal = Input.GetAxis("Horizontal");
            vertical = Input.GetAxis("Vertical");
        }


        //���
        if (Input.GetKeyDown(KeyCode.J))
        {
            var _index = GetComponent<NetworkTransform>().netObj.identity;
            ClientManager.AddOperation(new Operation(MyCommand.Dash, _index));
        }


        //�ƶ�����
        float horizontalMove = Input.GetAxis("Horizontal");
        float verticalMove = Input.GetAxis("Vertical");
        if (horizontalMove != 0 || verticalMove != 0)
        {
            transform.Translate(new Vector3(horizontalMove, verticalMove, 0f) * speed * Time.deltaTime);
            animator.SetFloat("running", Mathf.Abs(horizontalMove == 0 ? verticalMove : horizontalMove));
        }


        //�任�ϰ���
        if (Input.GetKeyDown(KeyCode.Alpha0))//����������0ʱ
        {
            var _index = GetComponent<NetworkTransform>().netObj.identity;
            ClientManager.AddOperation(new Operation(MyCommand.Deformation, _index));

        }

        if (Input.GetAxisRaw("Horizontal") != 0)
            transform.localScale = new Vector3(Input.GetAxisRaw("Horizontal"), 1, 1);
        

                //��C���͸ı�Player��ɫָ�� TransformComponent
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

        //���˰��ո����ӵ� GetComponent<NetworkTransform>().netObj.registerObjectIndex����Ψһ��ʶ��
        if (Input.GetKeyDown(KeyCode.Space)&& GetComponent<NetworkTransform>().netObj.registerObjectIndex==0) 
        {
            var _index = GetComponent<NetworkTransform>().netObj.identity;
            ClientManager.AddOperation(new Operation(MyCommand.Fire, _index));
        }

        //��X���˷��ü��ӣ����Ӷ���������
        if (Input.GetKeyDown(KeyCode.X) && GetComponent<NetworkTransform>().netObj.registerObjectIndex == 0)
        {
            var _index = GetComponent<NetworkTransform>().netObj.identity;
            ClientManager.AddOperation(new Operation(MyCommand.Clip, _index));
        }
        if (Input.GetKeyDown(KeyCode.X) /*&& GetComponent<NetworkTransform>().netObj.registerObjectIndex == 1*/)
        {
            var _index = GetComponent<NetworkTransform>().netObj.identity;
            ClientManager.AddOperation(new Operation(MyCommand.SpeedUp, _index));

            //��ʼ��ʱ����¼����ֻ�ܳ���5��
            duration = true;
            timer = 0;
        }

        //���ܳ���ʱ��
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
    {   //�ж������Ƿ�����������
        if (GetComponent<NetworkTransform>().netObj.registerObjectIndex == 0 && !collision.gameObject.tag.Equals("map") && !collision.gameObject.tag.Equals("mapflat") && !collision.gameObject.tag.Equals("Fire"))
            Destroy(collision.transform.gameObject);
        //�ж���������������
        else if (GetComponent<NetworkTransform>().netObj.registerObjectIndex == 1 && collision.gameObject.tag.Equals("hunter"))
        {
            Destroy(transform.gameObject);
        }

        

    }
    //�ӵ�������������ǵ�Ԥ����ΪIs Triggerʱ������ײ���ģ������Is Trigger��û����ײ���
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Fire" && GetComponent<NetworkTransform>().netObj.registerObjectIndex == 1)
        {
            Destroy(collision.gameObject);
            Destroy(transform.gameObject);
        }
    }


}
