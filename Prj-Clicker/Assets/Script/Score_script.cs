using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score_script : MonoBehaviour
{
    public static int score;
    public Text scoreDisplay;
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        scoreDisplay.text = "Score: " + score.ToString(); 
    }
}
