using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Levels : MonoBehaviour {
    bool isLock;
    int level;
    public Text text;
    public Image imageLock;

    // Use this for initialization
    void Start () {

    }

    // Update is called once per frame
    void Update () {

    }

    public void onClick () {
        if(!isLock) {
            GameController.instance.choseLevel = level;
            GameController.instance.currentLevel = level;
            Application.LoadLevel ("load");
        }
    }

    public void setLevel (int lv) {
        level = lv;
        text.text = "" + level;
        transform.name = "" + level;
    }
    public int getLevels () {
        return level;
    }

    public void setLock (bool islock) {
        isLock = islock;
        imageLock.enabled = isLock;
        GetComponent<Button> ().enabled = !isLock;
    }

    public bool getLock () {
        return isLock;
    }
}
