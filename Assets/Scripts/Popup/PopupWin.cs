using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PopupWin : Popup {
    public Text currentTime, bestTime, TextLevel;
    public Text TextNew;
    // Use this for initialization
    void Start () {
        UM_AdManager.StartInterstitialAd ();
    }

    // Update is called once per frame
    void Update () {

    }

    public void onShow (int newCurrentTime, int newBestTime) {
        Time.timeScale = 1;
        TextNew.gameObject.SetActive (false);
        if(newCurrentTime <= newBestTime || newBestTime == 0) {
            TextNew.gameObject.SetActive (true);
            newBestTime = newCurrentTime;
            GameController.instance.arrayBestTime[GameController.instance.currentLevel] = newBestTime;
        }

        currentTime.text = "Time: " + GameController.instance.converSecondsToMin (newCurrentTime);
        bestTime.text = "Time: " + GameController.instance.converSecondsToMin (newBestTime);
        TextLevel.text = "LEVEL " + (GameController.instance.currentLevel + 1);
        base.onShow ();
    }

    public void onClick_mainmenu () {
        Time.timeScale = 1;
        Application.LoadLevel ("home");
    }

    public void onClick_next () {
        Time.timeScale = 1;

        GameController.instance.currentLevel += 1;
        if(GameController.instance.currentLevel >= 19) {
            GameController.instance.currentLevel = 0;
        }
        Application.LoadLevel ("" + (GameController.instance.currentLevel));
    }

    public void onClick_restart () {
        Time.timeScale = 1;
        Application.LoadLevel ("load");
    }

    public void onClick_shareFacebook () {
        Time.timeScale = 1;
        StartCoroutine (PostFBScreenshot ());
    }

    private IEnumerator PostFBScreenshot () {
        yield return new WaitForEndOfFrame ();
        // Create a texture the size of the screen, RGB24 format
        int width = Screen.width;
        int height = Screen.height;
        Texture2D tex = new Texture2D (width, height, TextureFormat.RGB24, false);
        // Read screen contents into the texture
        tex.ReadPixels (new Rect (0, 0, width, height), 0, 0);
        tex.Apply ();

        UM_ShareUtility.FacebookShare ("Very good!", tex);

        Destroy (tex);
    }
}
