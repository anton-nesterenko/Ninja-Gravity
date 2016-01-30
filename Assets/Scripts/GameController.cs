using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System;
using SimpleJSON;

public class GameController {

    private static GameController _instance = null;
    public static GameController instance {
        get {
            if(_instance == null) {
                _instance = new GameController ();
            }

            return _instance;
        }
    }

    public int xGravity = 0, yGravity = 1;

    public int openLockLevel = 1;
    public int currentLevel;

    public int timeSec = 0;

    public int isMusic, isSound; //1 = on, -1 = off

    public List<int> arrayBestTime = new List<int> ();

    public string converSecondsToMin (int seconds) {
        int hours = seconds / 3600;
        int min = (seconds / 60) % 60;
        seconds = seconds % 60;
        string time = "";
        if(hours > 0)
            time = (hours.ToString ("00") + ":" + min.ToString ("00") + ":" + seconds.ToString ("00"));
        else
            time = min.ToString ("00") + ":" + seconds.ToString ("00");
        return time;
    }

    //id quang cao
   public int adid = 0;

    /*==========================Start Json==========================*/
    //string path = "Assets/Resources/json_data.txt";
    string str_json = "";
    public void read_data_from_json () {
        //str_json = readFile ();
        str_json = PlayerPrefs.GetString ("Data");
        var str = JSONNode.Parse (str_json);
        GameController.instance.openLockLevel = str["OpenLockLevel"].AsInt;
        GameController.instance.isMusic = str["Music"].AsInt;
        GameController.instance.isSound = str["Sound"].AsInt;

        Debug.Log ("============================: " + GameController.instance.isMusic + " VS " + GameController.instance.isSound);

        for(int i = 0; i < str["BestTime"].AsArray.Count; i++) {
            GameController.instance.arrayBestTime.Add (str["BestTime"][i].AsInt);
        }
    }

    public void write_data_to_json () {
        var str = JSONNode.Parse (str_json);

        str["OpenLockLevel"] = GameController.instance.openLockLevel + "";
        str["Music"] = GameController.instance.isMusic + "";
        str["Sound"] = GameController.instance.isSound + "";

        for(int i = 0; i < str["BestTime"].AsArray.Count; i++) {
            str["BestTime"][i] = GameController.instance.arrayBestTime[i] + "";
        }
        //str["BestTime"][0] = "0";
        // Debug.Log (str);
        // writeFile (str.ToString ());
        PlayerPrefs.SetString ("Data", str.ToString ());
        PlayerPrefs.Save ();
        
        Debug.Log (">>>>>>>>>>>>>>>>>>>>>>>>>>> " + GameController.instance.isMusic + " VS " + GameController.instance.isSound);
    }

    //string readFile () {
    //    string json_data = "";//File.ReadAllText (path);

    //    try {
    //        using(StreamReader sr = new StreamReader (path)) {
    //            json_data = sr.ReadLine ();
    //        }
    //    } catch(Exception e) {
    //         Let the user know what went wrong.
    //        Debug.Log ("The file could not be read:");
    //        Debug.Log (e.Message);
    //    }

    //    return json_data;
    //}

    //void writeFile (string content) {
    //    StreamWriter sw = new StreamWriter (path);
    //    sw.WriteLine (content);
    //    sw.Flush ();
    //    sw.Close ();
    //}
    /*==========================End Json==========================*/
}
