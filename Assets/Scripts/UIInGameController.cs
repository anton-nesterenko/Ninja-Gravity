using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIInGameController : MonoBehaviour {
    public GameObject controlFreak;
    public PopupPause Pause;
    public PopupWin popupWin;
    public PopupSetting popupSetting;
    public Text timeInGame;

    void Awake () {
    }

    // Use this for initialization
    void Start () {
        hideAllPopup ();
        controlFreak.SetActive (true);
        InvokeRepeating ("setTimeInGame", 0, 1);
    }

    bool cf = false;
    // Update is called once per frame
    void Update () {
        if(!Pause.isShow && cf && !popupWin.isShow) {
            controlFreak.SetActive (true);
            cf = false;
        }
    }

    public void onClick_Pause () {
        hideAllPopup ();
        Pause.onShow ();

        Time.timeScale = 0;
    }
    public void onClick_setting () {
        Time.timeScale = 1;
        if(popupSetting.isShow)
            popupSetting.onHide ();
        else
            popupSetting.onShow ();
    }

    void setTimeInGame () {
        GameController.instance.timeSec++;
        timeInGame.text = GameController.instance.converSecondsToMin (GameController.instance.timeSec);
    }

    public void showPopupWin () {
        Time.timeScale = 1;
        hideAllPopup ();


        string str = "BestTime" + (GameController.instance.currentLevel - 1);

        int bestTime = PlayerPrefs.GetInt (str, 9999);
        popupWin.onShow (GameController.instance.timeSec, bestTime);
        Debug.Log (str + " zzzzzzzzz: " + GameController.instance.timeSec + "=============: " + bestTime);

        CancelInvoke ("setTimeInGame");
        GameController.instance.timeSec = 0;
    }

    void hideAllPopup () {
        cf = true;
        controlFreak.SetActive (false);
        Pause.onHide ();
        popupSetting.onHide ();
        popupWin.onHide ();
    }
}
