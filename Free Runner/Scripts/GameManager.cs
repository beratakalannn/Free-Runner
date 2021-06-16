using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public bool canMove;
    static public bool _canMove;
    public float worldSpeed;
    static public float _worldSpeed;
    public int coinsCollect;

    //private bool coinHitThisFrame;
    private bool gameStart;


    public float timeToIncreaseSpeed = 5;
    private float increaseSpeedCounter;
    public float speedMultiplier = 1;
    private float targetSpeedMultiplier;
    public float accelariton = 0.75f;
    private float accelaritonStore;
    public float speedIncreaseAmount = 1.5f;
    private float worldSpeedStore;


    public GameObject tapMessage;
    public Text coinsText;
    public Text distanceText;
    public float distanceCovered;

    public GameObject deathScreen;
    public Text deathScreenCoins;
    public Text DeathScreenDistance;

    public float deathScreenDelay;

    public string mainMenuName;
    public GameObject notEnoghCoinScreen;

    public PlayerController thePlayer;


    public GameObject pauseScreen;

    

    void Start()
    {
        if (PlayerPrefs.HasKey("CoinsCollected"))
        {
           coinsCollect = PlayerPrefs.GetInt("CoinsCollected");
        }

        increaseSpeedCounter = timeToIncreaseSpeed;
        targetSpeedMultiplier = speedMultiplier;

        worldSpeedStore = worldSpeed;
        accelaritonStore = accelariton;

        coinsText.text = "Coins: " + coinsCollect;

        distanceText.text = distanceCovered + "m";


    }

    void Update()
    {
        _canMove = canMove;
        _worldSpeed = worldSpeed;

        if (!gameStart && Input.GetMouseButtonDown(0))
        {
            canMove = true;
            _canMove = true;
            gameStart = true;

            tapMessage.SetActive(false);

        }


        if (canMove)
        {
            increaseSpeedCounter -= Time.deltaTime;
            if (increaseSpeedCounter <= 0)
            {
                increaseSpeedCounter = timeToIncreaseSpeed;

                targetSpeedMultiplier = targetSpeedMultiplier * speedIncreaseAmount;

                timeToIncreaseSpeed = timeToIncreaseSpeed / .97f;
            }
            accelariton = accelaritonStore * speedMultiplier;

            speedMultiplier = Mathf.MoveTowards(speedMultiplier, targetSpeedMultiplier, accelariton * Time.deltaTime);
            worldSpeed = worldSpeedStore * speedMultiplier;


            distanceCovered += Time.deltaTime * worldSpeed;
            distanceText.text = Mathf.Floor(distanceCovered) + "m";

        }


        //coinHitThisFrame = true;
    }

    public void HitHazard()
    {
        canMove = false;
        _canMove = false;

        PlayerPrefs.SetInt("CoinsCollected", coinsCollect);

        coinsText.gameObject.SetActive(false);
        distanceText.gameObject.SetActive(false);

        //deathScreen.SetActive(true);
        deathScreenCoins.text = coinsCollect + " coins!";
        DeathScreenDistance.text = Mathf.Floor(distanceCovered) + " m!";

        StartCoroutine("ShowDeathScreen");
        
    }

    public IEnumerator ShowDeathScreen()
    {
        yield return new WaitForSeconds(deathScreenDelay);
        deathScreen.SetActive(true);

    }

    public void AddCoin()
    {

        //if (!coinHitThisFrame)
        //{


            coinsCollect++;
        //coinHitThisFrame = true;

        coinsText.text = "Coins: " + coinsCollect;


        //}
    }

    public void ContinueGame()
    {
        if(coinsCollect >= 100)
        {
            coinsCollect -= 100;

            canMove = true;
            _canMove = true;
            deathScreen.SetActive(false);
            coinsText.gameObject.SetActive(true);
            distanceText.gameObject.SetActive(true);




            thePlayer.ResetPlayer();
        }
        else
        {
            notEnoghCoinScreen.SetActive(true);
        }
    }
   
    


    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(mainMenuName);

        Time.timeScale = 1f;

    }

    public void GetCoins()
    {

    }


    public void CloseNotEnoughCoins()
    {
        notEnoghCoinScreen.SetActive(false);
    }


    public void ResumeGame()
    {
        pauseScreen.SetActive(false);

        Time.timeScale = 1f;

    }

     
    public void PauseGame()
    {
        if (Time.timeScale == 1f)
        {

            pauseScreen.SetActive(true);

            Time.timeScale = 0f;

        }
        else
        {
            pauseScreen.SetActive(false);
            Time.timeScale = 1f;
        }
    }


}
