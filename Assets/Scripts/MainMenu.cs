using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public Text TextCoin;
    public Text TextHighScore;
    public GameObject TapToPlay;
    public GameObject ButtonSettingAudioOn;
    public GameObject ButtonSettingAudioOff;

    void Start()
    {
        StartCoroutine(FlickerTextTapToPlay());
        GetCoin();
        GetHighScore();
    }

    void Update()
    {
        if(PlayerPrefs.GetString("Audio") == "On")
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

    private IEnumerator FlickerTextTapToPlay()
    {
        TapToPlay.SetActive(false);
        yield return new WaitForSeconds(0.1f);
        TapToPlay.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        StartCoroutine(FlickerTextTapToPlay());
    }

    public void OnClickPlayGame()
    {
        SceneManager.LoadScene("GamePlay1");
        Time.timeScale = 1f;
    }

    public void GetCoin()
    {
        TextCoin.text = PlayerPrefs.GetInt("Coins").ToString();
    }

    public void GetHighScore()
    {
        TextHighScore.text = PlayerPrefs.GetFloat("HighScore").ToString() + " M";
    }

    public void OnClickSettingAudio()
    {
        if(PlayerPrefs.GetString("Audio") == "On")
        {
            ButtonSettingAudioOn.SetActive(false);
            ButtonSettingAudioOff.SetActive(true);
            PlayerPrefs.SetString("Audio" , "Off");
        }
        else
        {
            ButtonSettingAudioOn.SetActive(true);
            ButtonSettingAudioOff.SetActive(false);
            PlayerPrefs.SetString("Audio", "On");
        }
    }
}
