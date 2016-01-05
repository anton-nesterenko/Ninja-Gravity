using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIController : MonoBehaviour {
    public MainMenu Main_Menu;
    public SelectLevels Select_Levels;
    public PopupWarning popupWarning;


    // Use this for initialization Awake
    void Start () {
        onClick_Back ();

        GameController.instance.openLockLevel = PlayerPrefs.GetInt ("OpenLockLevel", 1);
        GameController.instance.isMusic = PlayerPrefs.GetInt ("Music", 1);
        GameController.instance.isSound = PlayerPrefs.GetInt ("Sound", 1);
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
    }

    public void onClick_Play () {
        Main_Menu.onHide ();
        Select_Levels.onShow ();

        //effectPopup (Select_Levels);
    }
    public void onClick_Back () {
        Main_Menu.onShow ();
        Select_Levels.onHide ();
    }
}
