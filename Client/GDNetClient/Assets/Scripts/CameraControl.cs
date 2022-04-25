using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public Transform target;

    public float distance = 4.0f;
    public float maxDistance = 20;
    public float minDistance = 1.0f;

    public float xSpeed = 500.0f;
    public float ySpeed = 120.0f;

    public float z = 10;

    public Vector3 position;
  

    // Update is called once per frame
    void Update()
    {
        if (!target)
            return;
        
        if(target.position.y> 12.4677|| target.position.y< -5.682282)
        {
            transform.position = new Vector3(target.position.x, transform.position.y, -11);
        }
        else if(target.position.x< -58.55246 || target.position.x> 11)
        {
            transform.position = new Vector3(transform.position.x, target.position.y, -11);
        }
        else
        transform.position = new Vector3(target.position.x,target.position.y,-11) ;


    }

}
