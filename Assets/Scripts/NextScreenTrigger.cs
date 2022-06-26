using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextScreenTrigger : MonoBehaviour
{


    [SerializeField] GameObject player;

    private void Awake() {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.tag == "Player") ActivateTransition();
    }

    private void ActivateTransition()
    {
        player.transform.position += Vector3.up * 3f;
        Camera.main.transform.position += Vector3.up * 10.7f;
    }
}
