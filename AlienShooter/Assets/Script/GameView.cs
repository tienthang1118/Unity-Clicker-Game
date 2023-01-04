using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameView : MonoBehaviour
{
    public GameController gameController;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1)){
            gameController.UseWeapon();
        }
    }
    void ClickRightMouse()
    {
        gameController.UseWeapon();
        
    }
    public void ClickNextLevel()
    {
        gameController.NextLevel();
        
    }
    public void ClickBackMenu()
    {
        gameController.BackMenu();
        
    }
    public void ClickRestart()
    {
        gameController.RestartGame();
    }
    public void ClickQuit()
    {
        gameController.QuitGame();
    }
    public void ClickPauseGame()
    {
        gameController.PauseGame();
    }
    public void ClickResumeGame()
    {
        gameController.ResumeGame();
    }
}
