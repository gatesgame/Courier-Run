using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public static GameManager Instance = null;
    public static UIManager UiManager;
    public static int Coins;
    public GameObject Player;

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
    }

    public void ReSpawnPlayer()
    {
        Instantiate(Player, transform.position, transform.rotation);
    }

    
}
