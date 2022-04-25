using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Net.Share;
using Net.Component;
using System;
using Net.UnityComponent;

public class MyClientSceneManager : NetworkSceneManager
{
    //接收到指令执行同步
    public override void OnOtherOperator(Operation opt)
    {
        switch (opt.cmd)
        {   //变色
            case MyCommand.ChangePlayerColor:
                {   //找到是谁发出的变色指令
                    if (identitys.TryGetValue(opt.identity, out var t))
                    {
                        t.GetComponent<SpriteRenderer>().color =
                            new Color32(opt.buffer[0], opt.buffer[1], opt.buffer[2], 255);
                    }
                    
                }
                break;
                //猎人发射子弹
            case MyCommand.Fire:
                {
                    if (identitys.TryGetValue(opt.identity, out var t))
                    {
                        t.GetComponent<PlayerFire>().Fire();
                    }
                }
                    break;
                //猎人放置夹子
            case MyCommand.Clip:
                {
                    if (identitys.TryGetValue(opt.identity, out var t))
                    {
                        t.GetComponent<PlayerClip>().Clip(t);
                    }
                }
                break;
                //猎物技能提高速度
            case MyCommand.SpeedUp:
                {   //获取所有游戏角色
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
                //变换模型
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