using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathGenaration : MonoBehaviour
{

    public GameObject[] pathPieces;

    public Transform tresholdPoint;

    void Start()
    {
        
    }

    void Update()
    {
        if (transform.position.z < tresholdPoint.position.z)
        {

            int selectPiece = Random.Range(0, pathPieces.Length);
            Instantiate(pathPieces[selectPiece], transform.position, transform.rotation);
            transform.position += new Vector3(0, 0, 3.2f);
        }
    }
}
