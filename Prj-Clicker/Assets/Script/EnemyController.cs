using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Model model;
    AudioSource audioSource;
    private bool enemyAliveStatus;
    private bool isScore;
    private bool isRight;
    private float elapsedTime;
    private Animator animator;
    private int score;
    private float movementSpeed;
    
    // Start is called before the first frame update
    void Start()
    {
        //Set enemy start speed
        if(gameObject.tag == "Blue enemy"){
            movementSpeed = model.getMovementSpeed1();
        }
        else if(gameObject.tag == "Violet enemy")
        {
            movementSpeed = model.getMovementSpeed2();
        }
        else if(gameObject.tag == "Yellow enemy")
        {
            movementSpeed = model.getMovementSpeed3();
        }
        else if(gameObject.tag == "Orange enemy")
        {
            movementSpeed = model.getMovementSpeed4();
        }
        else if(gameObject.tag == "Meteor"){
            movementSpeed = model.getMovementSpeed3();
        }

        score = model.getScore();
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        enemyAliveStatus = model.getEnemyAliveStatus();
        enemyAliveStatus = true;
        model.setEnemyAliveStatus(true);
        isScore = false;
        if (transform.position.x < 0){
            isRight = true;
        }
        else{
            isRight = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        enemyAliveStatus = model.getEnemyAliveStatus();
        elapsedTime += Time.deltaTime;
        if(isRight){
            transform.position += Vector3.right * Time.deltaTime * movementSpeed;
        }
        else{
            transform.position += Vector3.left * Time.deltaTime * movementSpeed;
        }
        if(!enemyAliveStatus){
            DestroyObject();
        }
    }
    void OnMouseDown(){
        audioSource.Play();
        DestroyObject();
    }
    void DestroyObject(){
        Destroy(gameObject, 1f);
        if(isScore == false){
            ScoreCaculator();
        }
        movementSpeed = 0;
        animator.SetBool("destroyed", true);
    }
    void OnBecameInvisible() {
        if(elapsedTime>1){
            Destroy(gameObject);
        }
    }
    void ScoreCaculator(){
        isScore = true;
        if(gameObject.tag == "Blue enemy"){
            score += 10;
        }
        else if(gameObject.tag == "Violet enemy")
        {
            score += 20;
        }
        else if(gameObject.tag == "Yellow enemy")
        {
            score += 40;
        }
        else if(gameObject.tag == "Orange enemy")
        {
            score += 80;
        }
        else if(gameObject.tag == "Meteor" && score > 0 && enemyAliveStatus == true){
            if(score <100){
                score = 0;
            }
            else{
                score -= 100;
            }
        }
        model.setScore(score);
    }
}
