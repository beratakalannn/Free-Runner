using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMovement : MonoBehaviour
{
    //public float moveSpeed;

    void Start()
    {
        
    }

    void Update()
    {

        if (GameManager._canMove)
        {
            transform.position -= new Vector3(0, 0, GameManager._worldSpeed * Time.deltaTime);
        }



        if (transform.position.z < PathDestuructionPoint.zPos)
        {
            Destroy(gameObject);
        }
    }
}
