using UnityEngine;
using System.Collections;
using System.Collections.Generic;

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
    public int choseLevel;

    public int timeSec = 0;

    public int isMusic, isSound; //1 = on, -1 = off
    
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
}
