using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Net.Share;
using Net.Component;
using System;
using Net.UnityComponent;

public class MyClientSceneManager : NetworkSceneManager
{
    //���յ�ָ��ִ��ͬ��
    public override void OnOtherOperator(Operation opt)
    {
        switch (opt.cmd)
        {   //��ɫ
            case MyCommand.ChangePlayerColor:
                {   //�ҵ���˭�����ı�ɫָ��
                    if (identitys.TryGetValue(opt.identity, out var t))
                    {
                        t.GetComponent<SpriteRenderer>().color =
                            new Color32(opt.buffer[0], opt.buffer[1], opt.buffer[2], 255);
                    }
                    
                }
                break;
                //���˷����ӵ�
            case MyCommand.Fire:
                {
                    if (identitys.TryGetValue(opt.identity, out var t))
                    {
                        t.GetComponent<PlayerFire>().Fire();
                    }
                }
                    break;
                //���˷��ü���
            case MyCommand.Clip:
                {
                    if (identitys.TryGetValue(opt.identity, out var t))
                    {
                        t.GetComponent<PlayerClip>().Clip(t);
                    }
                }
                break;
                //���＼������ٶ�
            case MyCommand.SpeedUp:
                {   //��ȡ������Ϸ��ɫ
                    var t = identitys.GetValueOrDefault1(opt.identity);
                    //    Debug.Log("entries=" + t[0].value.tag);
                    //    Debug.Log("entries0=" + t[0].value.identity);
                    //Debug.Log("entries1=" + t[1].value.identity);
                    for(int i=0;i<t.Length;i++)
                    {
                        Debug.Log("entries1=" + t[1].value.identity);
                        if (t[i].value.tag!="hunter")
                            t[i].value.GetComponent<PlayerController>().speed = 100;
                    }

                }
                break;
                //�任ģ��
            case MyCommand.Deformation:
                {
                    if (identitys.TryGetValue(opt.identity, out var t))
                    {
                        t.GetComponent<PlayerDeformation>().Deformation();
                    }

                }
                break;
            case MyCommand.Dash:
                {
                    if (identitys.TryGetValue(opt.identity, out var t))
                    {
                      t.GetComponent<DragonSkill>().Dash();
                    }

                }
                break;

        }
    }
}