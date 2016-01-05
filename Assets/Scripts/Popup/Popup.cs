using UnityEngine;
using System.Collections;

public class Popup : MonoBehaviour {

    public bool isShow = false;

    // Use this for initialization
    void Start () {

    }

    // Update is called once per frame
    void Update () {

    }

    public void onHide () {
        isShow = false;
        gameObject.SetActive (false);
    }

    public void onShow () {
        isShow = true;
        gameObject.SetActive (true);
    }
}
