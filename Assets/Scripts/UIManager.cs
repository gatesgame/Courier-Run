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
    public int NumberOfTimeDieToShowAd;
    public bool BuyBack;
    public GameObject ButtonBuyBack;
    public Text TextDistance;
    public Text TextDistanceResult;
    public Text TextHighDistanceResult;
    public GameObject ButtonSettingAudioOn;
    public GameObject ButtonSettingAudioOff;

    private int NumberOfTimeToDie;

    void Awake()
    {
        BuyBack = false;
        NumberOfTimeToDie = PlayerPrefs.GetInt("Die");
    }

    void Update()
    {
        if (PlayerPrefs.GetString("Audio") == "On")
        {
            ButtonSettingAudioOn.SetActive(true);
            ButtonSettingAudioOff.SetActive(false);
        }
        else
        {
            ButtonSettingAudioOn.SetActive(false);
            ButtonSettingAudioOff.SetActive(true);
        }
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

    public void OnClickMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
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
        PlayerPrefs.SetInt("Die", NumberOfTimeToDie);
        ShowUnityAd();
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

    private void ShowUnityAd()
    {
        if (PlayerPrefs.GetInt("Die") >= NumberOfTimeDieToShowAd)
        {
            UnityAdManager.Instance.ShowVideoAd();
            NumberOfTimeToDie = 0;
            PlayerPrefs.SetInt("Die", 0);
        }
    }

    public void OnClickSettingAudio()
    {
        if (PlayerPrefs.GetString("Audio") == "On")
        {
            ButtonSettingAudioOn.SetActive(false);
            ButtonSettingAudioOff.SetActive(true);
            PlayerPrefs.SetString("Audio", "Off");
        }
        else
        {
            ButtonSettingAudioOn.SetActive(true);
            ButtonSettingAudioOff.SetActive(false);
            PlayerPrefs.SetString("Audio", "On");
        }
    }
}
