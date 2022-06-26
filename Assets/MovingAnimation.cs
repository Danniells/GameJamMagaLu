using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingAnimation : MonoBehaviour
{
    [SerializeField] float maxSize;
    [SerializeField] float growFactor;
    [SerializeField] public static bool isDead = false;
    void FixedUpdate()
    {
        if (!isDead && maxSize > transform.localPosition.y)
        {
            transform.localPosition += (Vector3.up * growFactor) * Time.deltaTime;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Player")
        {
            isDead = true;
            Debug.Log("morreu");
        }
    }
}
