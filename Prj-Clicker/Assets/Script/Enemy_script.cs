using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_script : MonoBehaviour
{
    AudioSource audioSource;
    public static bool isDestroy;
    private bool isScore;
    private bool isRight;
    private Animator animator;
    [SerializeField] private float movementSpeed;
    private float elapsedTime;
    // Start is called before the first frame update
    void Start()
    {
        if(gameObject.tag == "Blue enemy"){
            movementSpeed = 1;
        }
        else if(gameObject.tag == "Violet enemy")
        {
            movementSpeed = 2;
        }
        else if(gameObject.tag == "Yellow enemy")
        {
            movementSpeed = 4;
        }
        else if(gameObject.tag == "Orange enemy")
        {
            movementSpeed = 8;
        }
        if(gameObject.tag == "Meteor"){
            movementSpeed = 4;
        }
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        isDestroy = false;
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
        elapsedTime += Time.deltaTime;
        if(isRight){
            transform.position += Vector3.right * Time.deltaTime * movementSpeed;
        }
        else{
            transform.position += Vector3.left * Time.deltaTime * movementSpeed;
        }
        if(isDestroy){
            DestroyObject();
        }
    }
    void OnMouseDown()
    {
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
            Score_script.score += 10;
        }
        else if(gameObject.tag == "Violet enemy")
        {
            Score_script.score += 20;
        }
        else if(gameObject.tag == "Yellow enemy")
        {
            Score_script.score += 40;
        }
        else if(gameObject.tag == "Orange enemy")
        {
            Score_script.score += 80;
        }
        else if(gameObject.tag == "Meteor" && Score_script.score > 0 && isDestroy == false){
            if(Score_script.score <100){
                Score_script.score = 0;
            }
            else{
                Score_script.score -= 100;
            }
        }
    }
}
