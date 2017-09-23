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

    void Awake()
    {
        Time.timeScale = 0f;
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
}
