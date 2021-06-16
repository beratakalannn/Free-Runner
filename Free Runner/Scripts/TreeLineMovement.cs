using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeLineMovement : MonoBehaviour
{
    public Transform dissPoint;
    public Collider col;

    void Start()
    {
        
    }

    void Update()
    {
        if (GameManager._canMove)
        {
            transform.position -= new Vector3(0, 0, GameManager._worldSpeed * Time.deltaTime);
        }

        if (transform.position.z < dissPoint.position.z)
        {
            transform.position += new Vector3(0f, 0f, col.bounds.size.z * 2f);
        }
    }
}
