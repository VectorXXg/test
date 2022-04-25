using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Net.Component;
using Net.UnityComponent;
using System.Threading.Tasks;
using Net.Share;

public class GameManager : MonoBehaviour
{
    public GameObject[] PlayerPrefab;
    private async void Start()
    {

        await Task.Delay(2000);//延迟1秒后再执行下面代码
        if (ClientManager.I.client.Connected)
        {
            Connected();
        }
        else 
        { 
            ClientManager.Instance.client.OnConnectedHandle += Connected;
        }
           
       
    }

    private void Connected()
    {
        Vector3 x = new Vector3(0, 0, 1);

        //Random.Range(0, 2) == 0
        if (true)
        {
            SpawnPlayer(ClientManager.UID, x , Quaternion.identity);
        }

        else
            SpawnPlayer1(ClientManager.UID, x, Quaternion.identity);

    }
    //产生自己为猎人
    public void SpawnPlayer(int i, Vector3 position, Quaternion rotation)
    {

        GameObject _player = Instantiate( PlayerPrefab[2], position, rotation);

        _player.GetComponent<NetworkObject>().identity = i;

        //启用移动函数
         _player.GetComponent<DragonController>().enabled = true;
        //_player.GetComponent<PlayerFire>().enabled = true;

        //将玩家的位置赋值给摄像机进行同步移动
        FindObjectOfType<CameraControl>().target = _player.transform;

    }
    //产生自己为猎物
    public void SpawnPlayer1(int i, Vector3 position, Quaternion rotation)
    {

        GameObject _player = Instantiate(PlayerPrefab[1], position, rotation);

        _player.GetComponent<NetworkObject>().identity = i;

        //启用移动函数
        _player.GetComponent<PlayerController>().enabled = true;

        //将玩家的位置赋值给摄像机进行同步移动
        FindObjectOfType<CameraControl>().target = _player.transform;


    }

}