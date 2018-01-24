using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class Main : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Advertisement.Initialize("1681330");
        Advertisement.Show();
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    private void ShowRewardedVideo() {
        ShowOptions options = new ShowOptions();
        options.resultCallback = HandleShowResult;
        Advertisement.Show("rewardedVideo", options);
    }

    void HandleShowResult(ShowResult result) {
        if (result == ShowResult.Finished) {
            Debug.Log("Video completed - Offer a reward to the player");

        } else if (result == ShowResult.Skipped) {
            Debug.LogWarning("Video was skipped - Do NOT reward the player");

        } else if (result == ShowResult.Failed) {
            Debug.LogError("Video failed to show"); 
        }
    }
}
