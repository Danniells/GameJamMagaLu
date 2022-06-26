using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextScreenTrigger : MonoBehaviour
{
    [SerializeField] GameObject player;
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Player") ActivateTransition();
    }

    private void ActivateTransition()
    {
        player.
        Camera.main.transform.position += Vector3.up * 10.7f;
    }
}
