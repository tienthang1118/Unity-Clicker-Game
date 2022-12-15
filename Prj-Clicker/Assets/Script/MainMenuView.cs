using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuView : MonoBehaviour
{
    public MainMenuController controller;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ClickStartGame()
    {
        controller.LoadGame();
    }
    public void ClickMenuSetting()
    {
        controller.LoadSetting();
    }
    public void ClickBackMenu(){
        controller.BackMainMenu();
    }
}


