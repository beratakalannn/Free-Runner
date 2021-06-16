using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathDestuructionPoint : MonoBehaviour
{
   static public float zPos;

    void Start()
    {
        zPos = transform.position.z;
    }

    void Update()
    {
        zPos = transform.position.z;

    }
}
