using Net.UnityComponent;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    public GameObject FirePrefab;
public void Fire()
    {

        var _Fire= Instantiate(FirePrefab, new Vector3(transform.position.x, transform.position.y, -10) , Quaternion.identity);
        if (gameObject.GetComponent<PlayerController>().vertical > 0)
            _Fire.GetComponent<Rigidbody2D>().AddForce(Vector3.up * 500);
        else if(gameObject.GetComponent<PlayerController>().horizontal > 0)
            _Fire.GetComponent<Rigidbody2D>().AddForce(Vector3.right * 500);
        if (gameObject.GetComponent<PlayerController>().vertical < 0)
            _Fire.GetComponent<Rigidbody2D>().AddForce(Vector3.down * 500);
        else if (gameObject.GetComponent<PlayerController>().horizontal < 0)
            _Fire.GetComponent<Rigidbody2D>().AddForce(Vector3.left * 500);

    }

}
