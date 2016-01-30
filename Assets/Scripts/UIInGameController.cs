using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

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

        SoundController.instance.PlaySoundInGame ();
        UM_AdManager.HideBanner (GameController.instance.adid);
    }

    bool cf = false;
    // Update is called once per frame
    void Update () {
        if(!Pause.isShow && cf && !popupWin.isShow) {
            controlFreak.SetActive (true);
            cf = false;
        }

        //if(!SoundController.instance.audio.isPlaying && GameController.instance.isMusic == 1) {
        //  SoundController.instance.PlaySoundInGame ();
        //}
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

        int bestTime = GameController.instance.arrayBestTime[GameController.instance.currentLevel];
        popupWin.onShow (GameController.instance.timeSec, bestTime);

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
