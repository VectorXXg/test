using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeformation : MonoBehaviour
{
    public Sprite[] pic;
    public SpriteRenderer sr;
    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }
    public void Deformation()
    {
        int i = Random.Range(0, 3);
        sr.sprite = pic[i]; 
    }
}
