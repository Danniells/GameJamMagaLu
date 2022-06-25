using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingEnemy : MonoBehaviour
{
    [SerializeField] Rigidbody2D enemy;
    [SerializeField] float speed = 5f;

    void Update() => enemy?.AddForce(Vector2.right * speed * Time.deltaTime);

    void OnTriggerExit2D(Collider2D other) {
        if(other.gameObject.CompareTag("Ground")){
            enemy?.AddForce(Vector2.left * speed * Time.deltaTime);
        }
        else if (other.gameObject.CompareTag("Ground") && transform.position.x < 0){
            enemy?.AddForce(Vector2.right * speed * Time.deltaTime);
        }
    }
}
    

