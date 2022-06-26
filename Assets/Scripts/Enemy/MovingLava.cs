using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingLava : MonoBehaviour
{   
    [SerializeField] float maxSize;
    [SerializeField] float growFactor;
    [SerializeField] bool isDead = false;
    void FixedUpdate(){
        if(!isDead && maxSize > transform.localScale.y)
        {
            transform.localScale += (Vector3.up * growFactor) * Time.deltaTime;
        }
    }

    void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.name == "Player"){
            isDead = true;
        }
    }
}
