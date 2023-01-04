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
    public void ClickSelectLevel()
    {
        controller.LoadSelectLevel();
    }
    public void ClickHowToPlay()
    {
        controller.LoadHowToPlay();
    }
    public void ClickBackMenu(){
        controller.BackMainMenu();
    }
    public void ClickLoadLevel(){
        controller.LoadLevel();
    }
    public void ClickBackNoti()
    {
        controller.BackNoti();
    }
    public void ClickQuit()
    {
        controller.Quit();
    }
}


