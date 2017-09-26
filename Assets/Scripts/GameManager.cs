using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance = null;
    public static UIManager UiManager;
    public static int Coins;
    public static float Energys;
    public static float Distance;
    public GameObject Player;
    public float HighScore;

    private float Timer;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            if (Instance != this)
            {
                Destroy(gameObject);
            }
        }
    }

    void Start()
    {
        NeverSleepScreen();
        ReSpawnPlayer();
        UiManager = FindObjectOfType<UIManager>();
        Coins = PlayerPrefs.GetInt("Coins");
        UiManager.SetCoin(Coins);
        Energys = 33f;
        UiManager.SetEnergySpeedBoost(Energys);
        Distance = 0;
        UiManager.SetDistance(Distance);
        HighScore = PlayerPrefs.GetFloat("HighScore");
    }

    void Update()
    {
        StartCoroutine(CoCalculateDistance());
    }

    public void ReSpawnPlayer()
    {
        Instantiate(Player, transform.position, transform.rotation);
    }

    private IEnumerator CoCalculateDistance()
    {
        yield return new WaitForSeconds(3f);
        //S= v*t
        Timer += Time.deltaTime;
        if (Timer >= 1f)
        {
            Distance += FindObjectOfType<Movement>().MoveSpeed * 1;
            UiManager.SetDistance(Distance);
            Timer = 0f;
        }
    }

    public void SaveHighScore()
    {
        if (Distance > HighScore)
        {
            PlayerPrefs.SetFloat("HighScore", Distance);
        }
    }

    private void NeverSleepScreen()
    {
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
    }
}
