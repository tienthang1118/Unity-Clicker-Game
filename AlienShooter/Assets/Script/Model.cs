using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Model : MonoBehaviour
{
    [SerializeField] private float movementSpeed1 = 1;
    [SerializeField] private float movementSpeed2 = 2;
    [SerializeField] private float movementSpeed3 = 4;
    [SerializeField] private float movementSpeed4 = 8;
    [SerializeField] private float timeLimit=20;
    [SerializeField] private float spawnTime=1;
    [SerializeField] private int weaponAmount=2;
    [SerializeField] private float weaponSpeed=5;
    [SerializeField] private int score;
    [SerializeField] private bool enemyAliveStatus;



    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public float getMovementSpeed1(){
        return movementSpeed1;
    }
    public float getMovementSpeed2(){
        return movementSpeed2;
    }
    public float getMovementSpeed3(){
        return movementSpeed3;
    }
    public float getMovementSpeed4(){
        return movementSpeed4;
    }
    public float getTimeLimit(){
        return timeLimit;
    }
    public float getSpawnTime(){
        return spawnTime;
    }
    public int getWeaponAmount(){
        return weaponAmount;
    }
    public float getWeaponSpeed(){
        return weaponSpeed;
    }
    public int getScore(){
        return score;
    }
    public void setScore(int newScore){
        score = newScore;
    }
    public bool getEnemyAliveStatus(){
        return enemyAliveStatus;
    }
    public void setEnemyAliveStatus(bool status){
        enemyAliveStatus = status;
    }
}
