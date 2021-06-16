using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomObjectGenerator : MonoBehaviour
{

    public float timeBtObjects;
    private float objectGenCnt;

     

    public GameObject[] objects;


    public Transform minPoint;
    public Transform maxPoint;

    void Start()
    {
        
    }

    void Update()
    {
        if (GameManager._canMove)
        {
            objectGenCnt -= Time.deltaTime; 

            if (objectGenCnt <= 0)
            {
                int choosenObject = Random.Range(0, objects.Length);

                Vector3 genPoint = new Vector3(Random.Range(minPoint.position.x, maxPoint.position.x), transform.position.y, transform.position.z);
                Instantiate(objects[choosenObject], genPoint, transform.rotation);

                objectGenCnt = Random.Range(timeBtObjects * 1f, timeBtObjects * 4f);
            }
        }
    }
}
