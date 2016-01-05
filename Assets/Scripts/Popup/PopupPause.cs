using UnityEngine;
using System.Collections;

public class PopupPause : Popup {

    // Use this for initialization
    void Start () {

    }

    // Update is called once per frame
    void Update () {

    }

    public void onClick_mainmenu () {
        Time.timeScale = 1;
        base.onHide ();
        Application.LoadLevel ("home");
    }

    public void onClick_restart () {
        Time.timeScale = 1;
        //Application.LoadLevel ("" + (GameController.instance.currentLevel));

        base.onHide ();
        Application.LoadLevel ("load");
    }

    public void onClick_continue () {
        Time.timeScale = 1;
        //Application.LoadLevel ("load");
        base.onHide ();
    }
}
