using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControler : MonoBehaviour
{

    public float JumpHight;
    public bool IsGround;
    public bool IsDoubleJump;
    public Transform GroundCheck;
    public float SoundHeightToJump;
    public float CoolDownDoubleJump;
    public float CoolDownSpeedBoost;
    public float TimeToStartSpeedBoost;
    public float TimeBoostDuration;

    private Rigidbody2D RigidbodyPlayer;
    private int LayerMarkPlatform;
    private MicrophoneInput MicroInput;
    private float TimeToDelayMic;
    private Animator AnimatorPlayer;
    private Movement SpeedUp;
    private bool IsSpeedBoost;
    private float CurrentTimeWait;
    private float CurrentTimeToStartSpeedBoost;
    private float CurrentTimeBoostDuration;
    private bool IsJump;
    private UIManager UiManager;

    void Start()
    {
        RigidbodyPlayer = GetComponent<Rigidbody2D>();
        LayerMarkPlatform = LayerMask.GetMask("Platform");
        MicroInput = FindObjectOfType<MicrophoneInput>();
        AnimatorPlayer = GetComponent<Animator>();
        SpeedUp = FindObjectOfType<Movement>();
        UiManager = FindObjectOfType<UIManager>();
    }

    void Update()
    {
        Jump();
        JumpControlByAudioInput();
        SpeedBoost();
        AnimationController();
    }

    public void Jump()
    {
        //Check player stand in ground ?
        IsGround = Physics2D.OverlapCircle(GroundCheck.position, 0.2f, LayerMarkPlatform);

        if (IsGround)
        {
            IsDoubleJump = false;
        }

        //jump
        if (Input.GetKeyDown(KeyCode.Space) && IsGround)
        {
            RigidbodyPlayer.velocity = new Vector2(RigidbodyPlayer.velocity.x, JumpHight);
        }

        //double jump
        if (Input.GetKeyDown(KeyCode.Space) && !IsGround && !IsDoubleJump)
        {
            RigidbodyPlayer.velocity = new Vector2(RigidbodyPlayer.velocity.x, JumpHight);
            IsDoubleJump = true;
        }
    }

    //Mic controler in Jump
    public void JumpControlByAudioInput()
    {
        TimeToDelayMic += Time.deltaTime;

        // mic control jump
        if (MicroInput.Loudness >= SoundHeightToJump && IsGround)
        {
            RigidbodyPlayer.velocity = new Vector2(RigidbodyPlayer.velocity.x, JumpHight);
            TimeToDelayMic = 0f;
        }

        //mic controll double jump
        if (MicroInput.Loudness >= SoundHeightToJump && !IsGround && !IsDoubleJump && TimeToDelayMic >= CoolDownDoubleJump)
        {
            RigidbodyPlayer.velocity = new Vector2(RigidbodyPlayer.velocity.x, JumpHight);
            IsDoubleJump = true;
        }
    }

    public void SpeedBoost()
    {
        CurrentTimeWait += Time.deltaTime;
        //neu thoi...
        if (MicroInput.Loudness >= 0.1f && CurrentTimeWait >= CoolDownSpeedBoost && GameManager.Energys >= 33f)
        {
            //thơi gian thổi chạy
            CurrentTimeToStartSpeedBoost += Time.deltaTime;
            //neu thoi dai... 
            if (CurrentTimeToStartSpeedBoost >= TimeToStartSpeedBoost && !IsSpeedBoost)
            {
                GameManager.Energys -= 33f;
                UiManager.SetEnergySpeedBoost(GameManager.Energys);
                CurrentTimeWait = 0f;
                StartCoroutine(CoSpeedBoost());
            }
        }
        else
        {
            //tat thoi
            CurrentTimeToStartSpeedBoost = 0f;
            IsSpeedBoost = false;
        }
    }

    private IEnumerator CoSpeedBoost()
    {
        IsSpeedBoost = true;
        //speedboost
        RigidbodyPlayer.velocity = new Vector2(3f, RigidbodyPlayer.velocity.y);
        yield return new WaitForSeconds(1);
    }

    //Get coin
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Coin")
        {
            GameManager.Coins++;
            PlayerPrefs.SetInt("Coins", GameManager.Coins);
            UiManager.SetCoin(GameManager.Coins);
            Destroy(col.gameObject);
        }

        if (col.gameObject.tag == "Energy")
        {
            GameManager.Energys++;
            UiManager.SetEnergySpeedBoost(GameManager.Energys);
            Destroy(col.gameObject);
        }
    }

    //điều khiển animation 
    void AnimationController()
    {
        if (IsGround)
        {
            IsJump = false;
            IsSpeedBoost = false;
        }

        if (!IsSpeedBoost)
        {
            if (!IsGround)
            {
                IsJump = true;
            }
        }


        if (IsJump && !IsSpeedBoost && !IsGround)
        {
            AnimatorPlayer.SetBool("Jump", true);
            AnimatorPlayer.SetBool("Move", false);
            AnimatorPlayer.SetBool("SpeedBoost", false);
        }

        if (IsGround && !IsSpeedBoost && !IsJump)
        {
            AnimatorPlayer.SetBool("Move", true);
            AnimatorPlayer.SetBool("Jump", false);
            AnimatorPlayer.SetBool("SpeedBoost", false);
        }

        if (IsSpeedBoost && !IsGround)
        {
            AnimatorPlayer.SetBool("SpeedBoost", true);
            AnimatorPlayer.SetBool("Move", false);
            AnimatorPlayer.SetBool("Jump", false);
        }
    }
}
