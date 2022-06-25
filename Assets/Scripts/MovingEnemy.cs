using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingEnemy : MonoBehaviour
{

    Vector2 direction = Vector2.right;
    [SerializeField] float speed = 120;

    void Update() => transform.Translate(direction * speed * Time.deltaTime);

    void OnTriggerExit2D(Collider2D other) {
        if(other.gameObject.CompareTag("Ground") && transform.position.x > 0){
            direction = Vector2.left;
            Debug.Log(direction);
        }
        if(other.gameObject.CompareTag("Ground") && transform.position.x < 0){
            direction = Vector2.right;
            Debug.Log(direction);
        }
    }
}
    

