using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Facebook.Unity;

public class FacebookShare : MonoBehaviour {

    private void Awake()
    {
        if (!FB.IsInitialized)
        {
            FB.Init();
        }
        else
        {
            FB.ActivateApp();
        }
    }

    public void LogIn()
    {
        FB.LogInWithReadPermissions();
    }

    public void Share()
    {
        if (!FB.IsLoggedIn)
        {
            LogIn();
        }
        else
        {
#if UNITY_ANDROID
            FB.ShareLink(
                contentTitle: "Game hay lắm bà con ơi!, mình chạy được " + GameManager.Distance.ToString()+"M này!"
                +" Download về chơi thôi !",
                contentURL: new System.Uri("https://play.google.com/store/apps/details?id=com.xgatestudio.runcourierrun"),
                contentDescription: "Click on the link to download the game");
#elif UNITY_IPHONE
                FB.ShareLink(
                contentTitle: "Share link game",
                contentURL: new System.Uri("itms-apps://itunes.apple.com/app/tap-tap-tap-numbers/id1258506386?mt=12"),
                contentDescription: "Click on the link to download the game");
#endif
        }
    }
}
