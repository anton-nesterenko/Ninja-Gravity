using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PreLoading : MonoBehaviour {

    int level;
    AsyncOperation async;
    public Slider slider;

    // Use this for initialization
    void Start () {
        level = GameController.instance.currentLevel;
        async = Application.LoadLevelAsync (level + "");
    }

    // Update is called once per frame
    void Update () {
        //textLoad.guiText.text = (async.progress * 100).ToString ().Substring (0, 2) + "%";
        slider.value = async.progress;
    }
}
