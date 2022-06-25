using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    float rightBoud = 10;

    void Update()
    {
        if(transform.position.x > rightBoud){
            Destroy(gameObject);
        }
        else if(transform.position.x < -rightBoud){
            Destroy(gameObject);
        }
    }
}
