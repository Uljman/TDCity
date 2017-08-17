using System.Collections;
using System.Collections.Generic;
using UnityEngine.Advertisements;
using UnityEngine;


public class ShowAds : MonoBehaviour {

	public void ShowAd()
    {
        if(Advertisement.IsReady()) Advertisement.Show();

    }
}
