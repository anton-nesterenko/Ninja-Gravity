using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PopupSetting : Popup {

    public Button btnSound, btnMusic;
    public Sprite Music_off, Music_on, Sound_on, Sound_off;


    // Use this for initialization
    void Start () {

    }

    // Update is called once per frame
    void Update () {

    }


    public void onClick_music () {
        if(GameController.instance.isMusic == 1) {
            GameController.instance.isMusic = 0;
            btnMusic.image.sprite = Music_off;
        } else {
            GameController.instance.isMusic = 1;
            btnMusic.image.sprite = Music_on;
        }

        PlayerPrefs.SetInt ("Music", GameController.instance.isMusic);
        PlayerPrefs.Save ();
    }

    public void onClick_sound () {
        if(GameController.instance.isSound == 1) {
            GameController.instance.isSound = 0;
            btnSound.image.sprite = Sound_off;
        } else {
            GameController.instance.isSound = 1;
            btnSound.image.sprite = Sound_on;
        }

        PlayerPrefs.SetInt ("Sound", GameController.instance.isSound);
        PlayerPrefs.Save ();
    }

    public void onClick_info () {

    }
}
