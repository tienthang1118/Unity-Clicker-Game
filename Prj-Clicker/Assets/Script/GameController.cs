using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameObject pauseMenuUI;
    //custom cursor
    public Texture2D cursorTexture;
    //score
    public Text resultText;
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

    // Start is called before the first frame update
    void Start()
    {
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
        score = model.getScore();
        resultText.text = "Score: " + score.ToString(); 
        //Hien thi thoi gian con lai
        if(timeCountDown>0){
            timeCountDown -= Time.deltaTime;
        }
        timeRounded = Mathf.FloorToInt(timeCountDown);
        timeDisplay.text = "Time: " + timeRounded.ToString();
        //end game condition
        if(timeCountDown <= 0){
            SceneManager.LoadScene(sceneName:"Result");
        }
        //Tao ke dich tai vi tri cho truoc tren man hinh
        if(timeCountDown > 1){
            spawnTime = baseSpawnTime - (baseSpawnTime / 2) / Time_script.timeLimit * (timeLimit - timeCountDown);
            elapsedTime += Time.deltaTime;
            if (elapsedTime > spawnTime) 
            {
                int randEnemy = Random.Range(0, enemyPrefabs.Length);
                int randSpawPosition = Random.Range(0, spawnPosition.Length);
                cloneEnemy = Instantiate(enemyPrefabs[randEnemy], spawnPosition[randSpawPosition].position, transform.rotation);
                cloneEnemy.SetActive(true);
                elapsedTime = 0;
            }
        }
    }
    public void PauseMenu(){
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
    }
    public void BackGame(){
        pauseMenuUI.SetActive(false);
    }
    public void UseWeapon(){
        weaponAmountDisplay.text = weaponAmount.ToString();
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
