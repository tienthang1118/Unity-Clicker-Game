using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Endgame_condition_script : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Time_script.timeCountDown <= 0){
            Scene_manager_script.resultLoad();
        }
    }
}
