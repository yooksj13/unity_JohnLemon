using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public static int money;
    public float rotateSpeed =180f;


    // Start is called before the first frame update
    void Start()
    {
        
    }


    void OnTriggerEnter(Collider other){
        if(other.gameObject.tag == "Player"){
            money += 1;
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0f, 0f, rotateSpeed * Time.deltaTime);
    }
}
