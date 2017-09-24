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
        UiManager = FindObjectOfType<UIManager>();
        Coins = PlayerPrefs.GetInt("Coins");
        UiManager.SetCoin(Coins);
        Energys = 0f;
        UiManager.SetEnemySpeedBoost(Energys);
        Distance = 0;
        UiManager.SetDistance(Distance);
    }

    void Update()
    {
        CalculateDistance();
    }

    public void ReSpawnPlayer()
    {
        Instantiate(Player, transform.position, transform.rotation);
    }

    private void CalculateDistance()
    {
        //S= v*t
        Timer += Time.deltaTime;
        if (Timer >= 1f)
        {
            Distance += FindObjectOfType<Movement>().MoveSpeed * 1;
            UiManager.SetDistance(Distance);
            Timer = 0f;
        }
    }


}
