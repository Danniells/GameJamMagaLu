using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatEnemy : MonoBehaviour
{
    Transform playerPosition;

    [SerializeField] float speed = 2f;
    [SerializeField] float distance;
    [SerializeField] bool isFollowingPlayer = false;

    void Awake() => playerPosition = GameObject.Find("Player").GetComponent<Transform>();

    void Update()
    {
        //AI enemey following
        if(Vector2.Distance(transform.position, playerPosition.position) >= distance && !isFollowingPlayer)
          transform.position = Vector2.MoveTowards(transform.position, playerPosition.position, speed * Time.deltaTime);
        
        //enemy rotation
        if(transform.position.x < playerPosition.position.x)
            transform.localScale = new Vector3(-1f,1f,1f);
        else
            transform.localScale = Vector3.one * 1f;
    }

    void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.name == "Player"){
            isFollowingPlayer = true;
            Debug.Log("Morreu pelo morcego");
        }
    }
}
