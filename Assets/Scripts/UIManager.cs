using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GameObject PanelGamePause;
    public GameObject PanelGameOver;
    public Text TextCoin;
    public Slider SliderSpeedBoost;
    public int NumberOfTimeToDie;
    public bool BuyBack;
    public GameObject ButtonBuyBack;
    public Text TextDistance;
    public Text TextDistanceResult;
    public Text TextHighDistanceResult;

    void Awake()
    {
        BuyBack = false;
    }

    public void OnClickButtonPause()
    {
        PanelGamePause.SetActive(true);
        Time.timeScale = 0f;
    }

    public void OnClickButtonResume()
    {
        PanelGamePause.SetActive(false);
        Time.timeScale = 1f;
    }

    public void OnClickButtonRePlay()
    {
        SceneManager.LoadScene("GamePlay1");
        Time.timeScale = 1f;
    }

    public void SetCoin(int _value)
    {
        TextCoin.text = _value.ToString();
    }

    public void SetEnergySpeedBoost(float _value)
    {
        SliderSpeedBoost.value = _value;
    }

    public void ShowGameOver()
    {
        GameManager.Instance.SaveHighScore();
        TextHighDistanceResult.text = PlayerPrefs.GetFloat("HighScore").ToString() + "M";
        PanelGameOver.SetActive(true);
        SetTextDistanceResult();
        Time.timeScale = 0f;
        NumberOfTimeToDie++;
        PlayerPrefs.SetInt("CountDie", NumberOfTimeToDie);
    }

    public void OnClickButtonBuyBack()
    {
        if (GameManager.Coins >= 30 && !BuyBack)
        {
            Time.timeScale = 1f;
            PanelGameOver.SetActive(false);
            GameManager.Instance.ReSpawnPlayer();
            GameManager.Coins -= 30;
            SetCoin(GameManager.Coins);
            BuyBack = true;
        }
        else
        {
            ButtonBuyBack.SetActive(false);
        }
    }

    public void SetDistance(float _value)
    {
        TextDistance.text = _value.ToString() + "M";
    }

    public void SetTextDistanceResult()
    {
        TextDistanceResult.text = GameManager.Distance.ToString() + "M";
    }
}
