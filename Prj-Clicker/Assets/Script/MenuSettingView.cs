using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuSettingView : MonoBehaviour
{
    public MenuSettingController controller;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ClickBackMenu(){
        controller.BackMainMenu();
    }
}
