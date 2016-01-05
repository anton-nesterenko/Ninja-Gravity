using UnityEngine;
using System.Collections;

public class SelectLevels : Popup {
    public GameObject gridView;
    public GameObject button_level;
    // Use this for initialization
    void Start () {
        for(int i = 0; i < 40; i++) {
            GameObject obj = Instantiate (button_level) as GameObject;
            obj.transform.parent = gridView.transform;
            obj.transform.localScale = new Vector3 (1, 1, 1);
            obj.GetComponent<Levels> ().setLock (true);
            if(i + 1 <= GameController.instance.openLockLevel) {
                obj.GetComponent<Levels> ().setLevel (i + 1);
                obj.GetComponent<Levels> ().setLock (false);
            }
        }
    }

    // Update is called once per frame
    void Update () {

    }
}
