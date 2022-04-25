using Net.Component;
using Net.Share;
using Net.UnityComponent;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonController : MonoBehaviour
{
    public Animator animator;
    public float speed = 10f;       // �����ٶ�
    public float dashSpeed;         // ����ٶ�
    public float dashTime=0;     // ���ʱ�� 
    public bool isDash=false;            // �Ƿ��ڳ��״̬
    const float maxDashTimeLeft = 5f;    // ��̼��ܳ���ʱ��

    private void Start()
    {
        dashSpeed = 2f * speed;      // ���ó���ٶ�
    }

    // ���
    void dash()
    {
        if (isDash)
        {
            float dashTimeLeft = Time.time - dashTime;

            if (dashTimeLeft > maxDashTimeLeft)
            {
                isDash = false;
                speed = 10f;
            }
            else
            {
                speed = dashSpeed;
            }
        }
    }

    // �ܲ�����
    public void animatorController(float horizontalMove,float verticalMove)
    {
        if (horizontalMove != 0 || verticalMove != 0)
        {
            transform.Translate(new Vector3(horizontalMove, verticalMove, 0f) * speed * Time.deltaTime);
            animator.SetFloat("running", Mathf.Abs(speed*(horizontalMove==0?verticalMove:horizontalMove)));
        }
    }

    private void Update()
    {
        float horizontalMove = Input.GetAxis("Horizontal");
        float verticalMove = Input.GetAxis("Vertical");

        // ��̼���
        if (Input.GetKeyDown(KeyCode.J))
        {
            isDash = true;
            dashTime = Time.time;
        }

        if (Input.GetAxisRaw("Horizontal") != 0)
            transform.localScale = new Vector3(Input.GetAxisRaw("Horizontal"), 1, 1);

        dash();     // ���
        animatorController(horizontalMove,verticalMove);       // �ܲ�����

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
    //�ӵ���������
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Fire" && GetComponent<NetworkTransform>().netObj.registerObjectIndex == 1)
        {
            Destroy(collision.gameObject);
            Destroy(transform.gameObject);
        }
    }


}
