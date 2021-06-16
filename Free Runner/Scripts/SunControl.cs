using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunControl : MonoBehaviour
{
    public float speed;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        speed = Time.deltaTime / 0.1f;
        transform.Rotate(0, speed, 0);
    }
}
