using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_script : MonoBehaviour
{
    public static bool isDestroy;
    private Animator animator;
    [SerializeField] private float movementSpeed;
    private bool isRight;
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
        isDestroy = false;
        animator = GetComponent<Animator>();
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
        DestroyObject();
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
        else if(gameObject.tag == "Meteor" && Score_script.score > 0){
            if(Score_script.score <100){
                Score_script.score = 0;
            }
            else{
                Score_script.score -= 100;
            }
        }
    }
    void DestroyObject(){
        Destroy(gameObject, 1f);
        movementSpeed = 0;
        animator.SetBool("destroyed", true);
    }
    void OnBecameInvisible() {
        if(elapsedTime>1){
            Destroy(gameObject);
        }
    }
}
