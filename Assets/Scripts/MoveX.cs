using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveX : MonoBehaviour
{
    [SerializeField] float speed = 40.0f;
    void Update()
    {
            transform.Translate(Vector2.right * Time.deltaTime * speed);
    }
}
