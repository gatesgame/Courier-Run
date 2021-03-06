﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{

    private Animator AnimatorPlayer;

    void Start()
    {
        AnimatorPlayer = GetComponent<Animator>();
    }

    //die
    public void PlayerDie()
    {
        AudioManager.Instance.PlayDieAudio();
        AnimatorPlayer.SetBool("Die", true);
        StartCoroutine(DelayToDestroy());
    }

    private IEnumerator DelayToDestroy()
    {
        yield return new WaitForSeconds(0.1f);
        FindObjectOfType<UIManager>().ShowGameOver();
        Destroy(gameObject);
    }
}
