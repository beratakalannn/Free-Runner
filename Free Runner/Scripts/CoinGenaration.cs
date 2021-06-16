using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinGenaration : MonoBehaviour
{
    public float timeBeetwenCoin;
    private float coinGenCounter;
    public GameObject[] coinGroups;
    public Transform topPos;


    void Start()
    {
        coinGenCounter = timeBeetwenCoin;
    }

    void Update()
    {
        if (GameManager._canMove)
        {
            coinGenCounter -= Time.deltaTime;

            if (coinGenCounter <= 0)
            {
                bool goTop = Random.value > .5f;

                int choosenCoins = Random.Range(0, coinGroups.Length);

                if (goTop)
                {
                    Instantiate(coinGroups[choosenCoins], topPos.position, transform.rotation);

                }
                else
                {
                    Instantiate(coinGroups[choosenCoins], transform.position, transform.rotation);

                }

                coinGenCounter = Random.Range(timeBeetwenCoin * 1f, timeBeetwenCoin * 4f);
            }
        }

    }
}
