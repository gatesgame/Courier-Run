using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GameObject PanelMainMenu;
    public GameObject PanelGamePause;
    public GameObject PanelGameOver;
    public Text TextTapToPlay;
    public Text TextCoin;
    public Slider SliderSpeedBoost;
    public int NumberOfTimeToDie;
    public bool BuyBack;
    public GameObject ButtonBuyBack;
    public Text TextDistance;

    void Awake()
    {
        Time.timeScale = 0f;
        BuyBack = false;
    }

    private IEnumerator EffectTextTapToPlay()
    {
        TextTapToPlay.gameObject.SetActive(false);
        yield return new WaitForSeconds(0.1f);
        TextTapToPlay.gameObject.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        StartCoroutine(EffectTextTapToPlay());
    }

    public void OnClickButtonPlay()
    {
        PanelMainMenu.SetActive(false);
        Time.timeScale = 1f;
        GameManager.Instance.ReSpawnPlayer();
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
    }

    public void SetCoin(int _value)
    {
        TextCoin.text = _value.ToString();
    }

    public void SetEnemySpeedBoost(float _value)
    {
        SliderSpeedBoost.value = _value;
    }

    public void ShowGameOver()
    {
        PanelGameOver.SetActive(true);
        Time.timeScale = 0f;
        NumberOfTimeToDie++;
        PlayerPrefs.SetInt("CountDie", NumberOfTimeToDie);
    }

    public void OnClickButtonBuyBack()
    {
        if(GameManager.Coins >= 30 && !BuyBack)
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
        TextDistance.text = _value.ToString()+ "M";
    }
}
