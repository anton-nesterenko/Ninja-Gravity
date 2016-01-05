using UnityEngine;
using System.Collections;

public class LoadData : MonoBehaviour {

    // Use this for initialization
    void Awake () {
        PlayerPrefs.DeleteAll ();
        GameController.instance.openLockLevel = PlayerPrefs.GetInt ("OpenLockLevel", 1);
        GameController.instance.isMusic = PlayerPrefs.GetInt ("Music", 1);
        GameController.instance.isSound = PlayerPrefs.GetInt ("Sound", 1);
        Debug.Log ("Chay het roi nha!");
        //for(int i = 0; i < 40; i++) {
        //    string str = "BestTime" + (i + 1);
        //    int timebest = PlayerPrefs.GetInt (str, 9999);
        //    GameController.instance.bestTimes[i] = timebest;
        //    Debug.Log (str + "  tttttttttttttt: " + timebest);
        //}
    }

    // Update is called once per frame
    void Update () {

    }
}
