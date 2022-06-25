using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveNegative : MonoBehaviour
{

    [SerializeField] float speed = 40.0f;
    void Update()
    {
            transform.Translate(Vector2.left * Time.deltaTime * speed);
    }
}
