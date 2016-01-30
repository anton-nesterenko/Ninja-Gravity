using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SoundController : MonoBehaviour {
    private static SoundController _instance;
    public static SoundController instance {
        get {
            if(_instance == null) {
                _instance = new SoundController ();
                DontDestroyOnLoad (_instance.gameObject);
            }

            return _instance;
        }
    }

    public AudioClip main_menu, in_game, pickup, die, flip, rotate, click_button;
    public AudioSource audio;
    void Awake () {
        if(_instance == null) {
            _instance = this;
            DontDestroyOnLoad (this);
        } else {
            if(this != _instance)
                Destroy (this.gameObject);
        }
    }
    void Start () {
        audio = GetComponent<AudioSource> ();
        audio.rolloffMode = AudioRolloffMode.Linear;
        audio.volume = 1;
    }

    // Update is called once per frame
    void Update () {
        //if(!audio.isPlaying) {
        //   PlaySoundMainMenu ();
        // }
    }

    public void PlaySoundMainMenu () {
        audio.Stop ();
        audio.loop = true;
        audio.clip = main_menu;
        audio.Play ();
        pauseSound ();
        if(GameController.instance.isMusic == 1) unpauseSound ();
        //audio.PlayOneShot (main_menu);
    }

    public void PlaySoundInGame () {
        audio.Stop ();
        audio.loop = true;
        //audio.PlayOneShot (in_game);

        audio.clip = in_game;
        audio.Play ();
        pauseSound ();
        if(GameController.instance.isMusic == 1) unpauseSound ();
    }

    public void pauseSound () {
        audio.Pause ();
    }
    public void unpauseSound () {
        audio.UnPause ();
    }

    void PlaySound (AudioClip audioClip) {
        if(GameController.instance.isSound == 1) {
            Debug.Log (audioClip);
            audio.PlayOneShot (audioClip);
        }
    }
    public void SoundClickButton () {
        PlaySound (click_button);
    }

    public void SoundPickUp () {
        PlaySound (pickup);
    }

    public void SoundFlip () {
        PlaySound (flip);
    }

    public void SoundRotate () {
        PlaySound (rotate);
    }

    public void SoundDie () {
        PlaySound (die);
    }
}
