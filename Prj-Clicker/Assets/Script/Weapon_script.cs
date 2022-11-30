using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Weapon_script : MonoBehaviour
{
    AudioSource audioSource;
    public int amount = 3;
    public Text amountDisplay;
    public GameObject nuclear;
    public GameObject nuclearPos;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        amountDisplay.text = amount.ToString();
        if (Input.GetMouseButtonDown(1)){
            if(amount>0){
                amount--;
                Instantiate(nuclear, nuclearPos.transform.position, nuclearPos.transform.rotation);
                StartCoroutine(Coroutine());
            }
        }    
    }
    IEnumerator Coroutine()
    {
        yield return new WaitForSeconds(1.25f);
        Enemy_script.isDestroy = true;
        audioSource.Play(0);
    }
}
