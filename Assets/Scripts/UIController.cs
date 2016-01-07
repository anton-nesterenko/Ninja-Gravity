using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIController : MonoBehaviour {
    public MainMenu Main_Menu;
    public SelectLevels Select_Levels;
    public PopupWarning popupWarning;
    public PopupSetting popupSetting;

    void Awake () {
        string str =  PlayerPrefs.GetString ("Data");
        if(str == "") {
            TextAsset data = (TextAsset) Resources.Load<TextAsset> ("json_data");
            PlayerPrefs.SetString ("Data", data.text);
            PlayerPrefs.Save ();
        }
        //Debug.Log (text.text);
        GameController.instance.read_data_from_json ();
    }
    // Use this for initialization Awake
    void Start () {
        onClick_Back ();
        SoundController.instance.PlaySoundMainMenu ();
    }

    // Update is called once per frame
    void Update () {
        if(Input.GetKeyDown (KeyCode.Escape)) {
            if(!popupWarning.isShow) {
                popupWarning.onShow ();
            } else {
                popupWarning.onHide ();
            }
        }

        if(!SoundController.instance.audio.isPlaying) {
            SoundController.instance.PlaySoundMainMenu ();
        }
    }

    public void onClick_Play () {
        hideAllPopup ();
        Main_Menu.onHide ();
        Select_Levels.onShow ();

        //effectPopup (Select_Levels);
    }
    public void onClick_Back () {
        hideAllPopup ();
        Main_Menu.onShow ();
        Select_Levels.onHide ();
    }
    public void onClick_setting () {
        //Time.timeScale = 1;
        if(popupSetting.isShow)
            popupSetting.onHide ();
        else
            popupSetting.onShow ();
    }
    public void hideAllPopup () {
        popupSetting.onHide ();
        popupWarning.onHide ();
    }
}
