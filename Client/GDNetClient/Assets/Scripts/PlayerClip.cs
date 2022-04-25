using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerClip : MonoBehaviour
{
    public GameObject FirePrefab;
    public void Clip(Net.UnityComponent.NetworkObject t)
    {
        Instantiate(FirePrefab, transform.position + new Vector3(0, 0, 0), Quaternion.identity);
        if (t.tag != "hunter") 
        FirePrefab.SetActive(false);

    }
}

