using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class UnityAdManager : MonoBehaviour {

#if UNITY_ANDROID
    private string GameID = "1554802"; // Set this value from the inspector.
    public bool enableTestMode = true;
#endif

#if UNITY_IPHONE
    private string GameID = "1554801"; // Set this value from the inspector.
    public bool enableTestMode = true;
#endif


    public static UnityAdManager Instance = null;

    void Awake()
    {
        //Check if instance already exists
        if (Instance == null)
        {
            //if not, set instance to this
            Instance = this;
        }
        //If instance already exists and it's not this:
        else if (Instance != this)
        {
            //Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a GameManager.
            Destroy(gameObject);
        }
    }

    IEnumerator Start()
    {
#if !UNITY_ADS // If the Ads service is not enabled...
        if (Advertisement.isSupported)
        { // If runtime platform is supported...
            Advertisement.Initialize(GameID, enableTestMode); // ...initialize.
        }
#endif

        // Wait until Unity Ads is initialized,
        //  and the default ad placement is ready.
        if (!Advertisement.isInitialized || !Advertisement.IsReady())
        {
            yield return new WaitForSeconds(0.5f);
        }
    }

    public void ShowVideoAd()
    {
        Advertisement.Show();
    }
}
