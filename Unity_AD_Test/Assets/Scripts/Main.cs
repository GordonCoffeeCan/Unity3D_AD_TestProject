using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.UI;

public class Main : MonoBehaviour {

    public Button showADButton;
    public Text coinsUI;

    private int coins = 0;

#if UNITY_IOS
    public string gameID = "1681331";
#elif UNITY_ANDROID
    public string gameID = "1681330";
#endif

    public string placementID = "rewardedVideo";

	// Use this for initialization
	void Start () {
        if (Advertisement.isSupported) {
            Advertisement.Initialize(gameID, true);
        }

        coinsUI.text = "Coins: 0";
    }
	
	// Update is called once per frame
	void Update () {
        showADButton.interactable = Advertisement.IsReady(placementID);
    }

    public void ShowAD() {
        ShowRewardedAD();
    }

    private void ShowRewardedAD() {
        ShowOptions options = new ShowOptions();
        options.resultCallback = OnShowADResult;
        Advertisement.Show(placementID, options);
    }

    void OnShowADResult(ShowResult result) {
        if (result == ShowResult.Finished) {
            Debug.Log("Video completed - Offer a reward to the player");
            coins += Random.Range(5, 11);
            coinsUI.text = "Coins: " + coins.ToString();

        } else if (result == ShowResult.Skipped) {
            Debug.LogWarning("Video was skipped - Do NOT reward the player");

        } else if (result == ShowResult.Failed) {
            Debug.LogError("Video failed to show"); 
        }
    }
}
