using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HazardGenerator : MonoBehaviour
{
    public GameObject[] hazards;
    public float timeBetweenHazards = 3;
    private float hazardGenCounter;

    public GameManager Gm;

    void Start()
    {
        hazardGenCounter = timeBetweenHazards;
    }

    void Update()
    {
        if (Gm.canMove)
        {
            hazardGenCounter -= Time.deltaTime;

            if (hazardGenCounter <= 0)
            {
                int choosenHazard = Random.Range(0, hazards.Length);
                Instantiate(hazards[choosenHazard], transform.position, transform.rotation);

                hazardGenCounter = Random.Range(timeBetweenHazards * 1f, timeBetweenHazards * 4f);


                hazardGenCounter = hazardGenCounter / Gm.speedMultiplier;
            }
        }

        
    }
}
