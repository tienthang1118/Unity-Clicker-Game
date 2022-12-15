using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    private Animator animator;
    private float flySpeed;
    public Model model;
    // Start is called before the first frame update
    void Start()
    {
        flySpeed = model.getWeaponSpeed();
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
