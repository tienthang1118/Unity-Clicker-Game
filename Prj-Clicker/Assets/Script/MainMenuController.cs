using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public GameObject menuSettingUI;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void LoadMenu(){
        SceneManager.LoadScene(sceneName:"Menu");
    }
    public void LoadGame(){
        SceneManager.LoadScene(sceneName:"Game");
    }
    public void LoadLevel(){
        // SceneManager.LoadScene(sceneName:"Level");
    }
    public void LoadSetting(){
        menuSettingUI.SetActive(true);
    }
    static public void LoadResult(){
        SceneManager.LoadScene(sceneName:"Result");
    }
    public void Quit(){
        Application.Quit();
    }

}

