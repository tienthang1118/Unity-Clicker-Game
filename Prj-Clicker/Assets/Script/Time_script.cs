using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Time_script : MonoBehaviour
{
    public static float timeLimit = 61;
    public static float timeCountDown;
    private int timeRounded;
    public Text timeDisplay;
    // Start is called before the first frame update
    void Start()
    {
        timeCountDown = timeLimit;
    }

    // Update is called once per frame
    void Update()
    {
        if(timeCountDown>0){
            timeCountDown -= Time.deltaTime;
        }
        timeRounded = Mathf.FloorToInt(timeCountDown);
        timeDisplay.text = "Time: " + timeRounded.ToString();
    }
}
