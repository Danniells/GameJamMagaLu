using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> levels = new List<GameObject>();

    private void Awake()
    {
        var height = 10.7f;
        
        for (int i = 0; i < levels.Count; i++)
        {
            Instantiate(levels[i], (Vector3.up * height) * i, Quaternion.identity);
        }
    }
}
