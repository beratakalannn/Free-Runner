using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerGenaration : MonoBehaviour
{
    public float timepower;
    private float powerCounter;
    public GameObject power;
    public Transform pos;

    void Start()
    {
        powerCounter = timepower;
    }

    void Update()
    {
        if (GameManager._canMove)
        {
            powerCounter -= Time.deltaTime;

            if (powerCounter < 0)
            {
                Instantiate(power, pos.position, Quaternion.identity);

                powerCounter = Random.Range(timepower * 1f, timepower * 4f);

            }
        }
    }
}
