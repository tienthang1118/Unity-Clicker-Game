using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene_manager_script : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void menuLoad(){
        SceneManager.LoadScene(sceneName:"Menu");
    }
    public void gameLoad(){
        SceneManager.LoadScene(sceneName:"Game");
    }
    static public void resultLoad(){
        SceneManager.LoadScene(sceneName:"Result");
    }
    public void quit(){
        Application.Quit();
    }
}
