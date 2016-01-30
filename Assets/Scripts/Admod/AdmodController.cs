using UnityEngine;
using System.Collections;

public class AdmodController : MonoBehaviour {
    int adid = 0;
    // Use this for initialization
    void Start () {

        if(!UM_AdManager.IsInited) {
            UM_AdManager.Init ();
        }
        if(adid <= 0) {
            adid = UM_AdManager.CreateAdBanner (TextAnchor.UpperCenter);
            GameController.instance.adid = adid;
            UM_AdManager.ShowBanner (adid);
            UM_AdManager.StartInterstitialAd ();
        }
    }

    // Update is called once per frame
    void Update () {

    }
}
