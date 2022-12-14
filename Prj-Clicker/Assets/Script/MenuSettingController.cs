using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuSettingController : MonoBehaviour
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
