using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class PopupSetting : Popup {
    public Button btnSound, btnMusic;
    public Sprite Music_off, Music_on, Sound_on, Sound_off;

    // Use this for initialization
    void Start () {
        changeSprite ();
    }

    // Update is called once per frame
    void Update () {

    }


    public void onClick_music () {
        if(GameController.instance.isMusic == 1) {
            GameController.instance.isMusic = 0;
            btnMusic.image.sprite = Music_off;
            SoundController.instance.pauseSound ();
        } else {
            GameController.instance.isMusic = 1;
            btnMusic.image.sprite = Music_on;
            SoundController.instance.unpauseSound ();
        }
        GameController.instance.write_data_to_json ();
    }

    public void onClick_sound () {
        if(GameController.instance.isSound == 1) {
            GameController.instance.isSound = 0;
            btnSound.image.sprite = Sound_off;
        } else {
            GameController.instance.isSound = 1;
            btnSound.image.sprite = Sound_on;
        }

        GameController.instance.write_data_to_json ();
    }

    public void onClick_info () {

    }

    void changeSprite () {
        if(GameController.instance.isMusic == 1) {
            btnMusic.image.sprite = Music_on;
        } else {
            btnMusic.image.sprite = Music_off;
        }

        if(GameController.instance.isSound == 1) {
            btnSound.image.sprite = Sound_on;
        } else {
            btnSound.image.sprite = Sound_off;
        }
    }
}
