using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nuclear_fly_script : MonoBehaviour
{
    private Animator animator;
    public float flySpeed = 5;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y > 0){
            Destroy(gameObject,1f);
            animator.SetBool("nuclearExplosion", true);
        }
        else{
            transform.position += Vector3.up * Time.deltaTime * flySpeed;
        }
    }
}
