using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class MainMenuController : MonoBehaviour
{
    public GameObject menuSettingUI;
    public GameObject menuSelectUI;
    public GameObject menuHowToPlayUI;
    public GameObject lvNoti;
    public Model model;
    [SerializeField] Slider musicSlider;
    [SerializeField] Slider soundSlider;
    // Start is called before the first frame update
    void Start()
    {
        if(PlayerPrefs.GetInt("MaxLevel")<1){
            PlayerPrefs.SetInt("MaxLevel", 1);
        }
        if(!PlayerPrefs.HasKey("Sound")){
            PlayerPrefs.SetFloat("Sound", 1);
        }
        if(!PlayerPrefs.HasKey("Music")){
            PlayerPrefs.SetFloat("Music", 1);
        }
        soundSlider.value = PlayerPrefs.GetFloat("Sound");
        musicSlider.value = PlayerPrefs.GetFloat("Music");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        soundVolume();
        musicVolume();
    }
    public void LoadMenu(){
        SceneManager.LoadScene(sceneName:"Menu");
    }
    public void LoadGame(){
        PlayerPrefs.SetInt("Level", 1);
        SceneManager.LoadScene(sceneName:"Gameplay");
    }

    public void LoadSetting(){
        menuSettingUI.SetActive(true);
    }
    public void LoadSelectLevel(){
        menuSelectUI.SetActive(true);
    }
    public void LoadHowToPlay(){
        menuHowToPlayUI.SetActive(true);
    }
    public void Quit(){
        Application.Quit();
    }
    // Setting controller
    public void soundVolume(){
        AudioListener.volume = soundSlider.value;
        PlayerPrefs.SetFloat("Sound", soundSlider.value);
    }
    public void musicVolume(){
        AudioListener.volume = musicSlider.value;
        PlayerPrefs.SetFloat("Music", musicSlider.value);
    }
    public void BackMainMenu(){
        menuSettingUI.SetActive(false);
        menuSelectUI.SetActive(false);
        menuHowToPlayUI.SetActive(false);

    }
    // Select level controller
    public void LoadLevel(){
        string name=EventSystem.current.currentSelectedGameObject.name;
        int lv;
        int.TryParse(name, out lv);
        if(lv>PlayerPrefs.GetInt("MaxLevel")){
            lvNoti.SetActive(true);

        }
        else{
            PlayerPrefs.SetInt("Level", lv);
            SceneManager.LoadScene(sceneName:"Gameplay");
        }
        
    }
    public void BackNoti(){
        lvNoti.SetActive(false);
    }
}

