using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Result_display_scipt : MonoBehaviour
{
    public Text resultText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        resultText.text = "Score: " + Score_script.score.ToString(); 
    }
}
