using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class GameController : MonoBehaviour
{
    [SerializeField] Slider musicSlider;
    [SerializeField] Slider soundSlider;
    public GameObject pauseMenuUI;
    public GameObject resultMenuUI;
    public GameObject nextLevelBtn;
    //score result
    public Text resultScore;
    public Text resultHighScore;
    public Text resultStatus;
    //custom cursor
    public Texture2D cursorTexture;
    //score
    public Text resultText;
    public int winScore;
    //time
    private float timeCountDown;
    private int timeRounded;
    private float spawnTime;
    private float baseSpawnTime;
    private float timeLimit;
    private float elapsedTime;
    public Text timeDisplay;
    //model
    public Model model;
    private int score;

    //spawn position
    public Transform[] spawnPosition;

    //enemy prefab
    public GameObject[] enemyPrefabs;

    //weapon
    AudioSource audioSource;
    private int weaponAmount;
    public Text weaponAmountDisplay;
    public GameObject nuclear;
    public GameObject nuclearPos;

    private GameObject cloneNuclear;
    private GameObject cloneEnemy;
    // Level
    private int enemyTypeNumber;
    private int loadedLevel;

    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("HighScore1", 0);
        PlayerPrefs.SetInt("HighScore2", 0);
        PlayerPrefs.SetInt("HighScore3", 0);
        PlayerPrefs.SetInt("HighScore4", 0);
        loadedLevel = PlayerPrefs.GetInt("Level");
        if(loadedLevel == 1)
        {
            enemyTypeNumber = 2;
            winScore = 100;
        }
        else if(loadedLevel == 2)
        {
            enemyTypeNumber = 3;
            winScore = 300;
        }
        else if(loadedLevel == 3)
        {
            enemyTypeNumber = 4;
            winScore = 500;
        }
        else if(loadedLevel == 4)
        {
            enemyTypeNumber = 5;
            winScore = 700;
        }
        soundSlider.value = PlayerPrefs.GetFloat("Sound");
        musicSlider.value = PlayerPrefs.GetFloat("Music");

        audioSource = GetComponent<AudioSource>();
        //Set cursor
        Vector2 cursorOffset = new Vector2(cursorTexture.width/2, cursorTexture.height/2);
        Cursor.SetCursor(cursorTexture, cursorOffset, CursorMode.Auto);
        baseSpawnTime = model.getSpawnTime();
        timeLimit = model.getTimeLimit();
        timeCountDown = timeLimit;

        weaponAmount = model.getWeaponAmount();
    }

    // Update is called once per frame
    void Update()
    {
        //get sccore
        weaponAmountDisplay.text = weaponAmount.ToString();
        resultText.text = "Score: " + score.ToString() + "/" + winScore.ToString();
        //Hien thi thoi gian con lai
        if(timeCountDown>0){
            timeCountDown -= Time.deltaTime;
        }
        timeRounded = Mathf.FloorToInt(timeCountDown);
        timeDisplay.text = "Time: " + timeRounded.ToString();
        //end game condition
        if(timeCountDown <= 0)
        {   
            if(loadedLevel==1){
                if(score>PlayerPrefs.GetInt("HighScore1")){
                    PlayerPrefs.SetInt("HighScore1", score);
                }
                resultHighScore.text = "High score: " + PlayerPrefs.GetInt("HighScore1").ToString();
            }
            else if(loadedLevel==2){
                if(score>PlayerPrefs.GetInt("HighScore2")){
                    PlayerPrefs.SetInt("HighScore2", score);
                }
                resultHighScore.text = "High score: " + PlayerPrefs.GetInt("HighScore2").ToString();
            }
            else if(loadedLevel==3){
                if(score>PlayerPrefs.GetInt("HighScore3")){
                    PlayerPrefs.SetInt("HighScore3", score);
                }
                resultHighScore.text = "High score: " + PlayerPrefs.GetInt("HighScore3").ToString();
            }
            else if(loadedLevel==4){
                if(score>PlayerPrefs.GetInt("HighScore4")){
                    PlayerPrefs.SetInt("HighScore4", score);
                }
                resultHighScore.text = "High score: " + PlayerPrefs.GetInt("HighScore4").ToString();
            }
    
            if(score>=winScore){
                resultStatus.text = "Win";
                if(loadedLevel != 4){
                    nextLevelBtn.SetActive(true);
                }
                else{
                    nextLevelBtn.SetActive(false);
                }
            }
            else{
                resultStatus.text = "Lose";
                nextLevelBtn.SetActive(false);
            }
            
            resultScore.text = "Score: " + score.ToString();
            resultMenuUI.SetActive(true);
        }
        //Tao ke dich tai vi tri cho truoc tren man hinh
        if(timeCountDown > 1){
            spawnTime = baseSpawnTime - (baseSpawnTime / 2) / timeLimit * (timeLimit - timeCountDown);
            elapsedTime += Time.deltaTime;
            if (elapsedTime > spawnTime) 
            {
                int randEnemy = Random.Range(0, enemyTypeNumber);
                int randSpawPosition = Random.Range(0, spawnPosition.Length);
                cloneEnemy = Instantiate(enemyPrefabs[randEnemy], spawnPosition[randSpawPosition].position, transform.rotation);
                cloneEnemy.SetActive(true);
                elapsedTime = 0;
            }
        }
    }
    void FixedUpdate(){
        score = model.getScore();
        soundVolume();
        musicVolume();
    }
    public void NextLevel(){
        loadedLevel +=1;
        PlayerPrefs.SetInt("Level", loadedLevel);
        if(loadedLevel > PlayerPrefs.GetInt("MaxLevel")){
            PlayerPrefs.SetInt("MaxLevel", loadedLevel);
        }
        SceneManager.LoadScene("Gameplay");
    }
    public void RestartGame(){
        SceneManager.LoadScene("Gameplay");
    }
    public void BackMenu(){
        SceneManager.LoadScene("Menu");
    }
    public void QuitGame(){
        Application.Quit();
    }
    public void PauseGame(){
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0.0f;
    }
    public void ResumeGame(){
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1.0f;

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
    public void UseWeapon(){
        
        if(weaponAmount>0){
            weaponAmount--;
            cloneNuclear = Instantiate(nuclear, nuclearPos.transform.position, nuclearPos.transform.rotation);
            cloneNuclear.SetActive(true);
            StartCoroutine(Coroutine());
        }
    }
    IEnumerator Coroutine()
    {
        yield return new WaitForSeconds(1.25f);
        model.setEnemyAliveStatus(false);
        audioSource.Play(0);
    }
}
