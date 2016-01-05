using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PopupWin : Popup {
    public Text currentTime, bestTime;
    public Text TextNew;
    // Use this for initialization
    void Start () {

    }

    // Update is called once per frame
    void Update () {

    }

    public void onShow (int newCurrentTime, int newBestTime) {
        Time.timeScale = 1;
        TextNew.gameObject.SetActive (false);
        if(newCurrentTime <= newBestTime) {
            TextNew.gameObject.SetActive (true);
            string str = "BestTime" + (GameController.instance.currentLevel - 1);

            PlayerPrefs.SetInt (str, newCurrentTime);
            PlayerPrefs.Save ();

            Debug.Log (str + " mmmmmmmmmmm " + newCurrentTime);

            newBestTime = newCurrentTime;
        }
        currentTime.text = "Time: " + GameController.instance.converSecondsToMin (newCurrentTime);
        bestTime.text = "Time: " + GameController.instance.converSecondsToMin (newBestTime);
        base.onShow ();
    }

    public void onClick_mainmenu () {
        Time.timeScale = 1;
        Application.LoadLevel ("home");
    }

    public void onClick_next () {
        Time.timeScale = 1;
        Application.LoadLevel ("" + (GameController.instance.currentLevel));
    }

    public void onClick_restart () {
        Time.timeScale = 1;
        Application.LoadLevel ("load");
    }

    public void onClick_shareFacebook () {
        Time.timeScale = 1;
    }
}
