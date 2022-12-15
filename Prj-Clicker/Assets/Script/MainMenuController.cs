using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public GameObject menuSettingUI;
    [SerializeField] Slider musicSlider;
    [SerializeField] Slider soundSlider;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        soundVolume();
        musicVolume();
    }
    public void LoadMenu(){
        SceneManager.LoadScene(sceneName:"Menu");
    }
    public void LoadGame(){
        SceneManager.LoadScene(sceneName:"Level 1");
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
    // Setting controller
    public void soundVolume(){
        AudioListener.volume = soundSlider.value;
    }
    public void musicVolume(){
        AudioListener.volume = musicSlider.value;
    }
    public void BackMainMenu(){
        menuSettingUI.SetActive(false);
    }

}

