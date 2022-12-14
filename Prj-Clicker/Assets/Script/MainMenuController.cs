using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenuController : MonoBehaviour
{
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
    public static void LoadGame(){
        SceneManager.LoadScene(sceneName:"Game");
    }
    public void LoadLevel(){
        // SceneManager.LoadScene(sceneName:"Level");
    }
    public void LoadSetting(){
        // SceneManager.LoadScene(sceneName:"Setting");
    }
    static public void LoadResult(){
        SceneManager.LoadScene(sceneName:"Result");
    }
    public void Quit(){
        Application.Quit();
    }

}
