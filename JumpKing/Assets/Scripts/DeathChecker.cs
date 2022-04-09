using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathChecker : MonoBehaviour
{
     [SerializeField] Transform spawnPoint;

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.transform.CompareTag("Player"))
            col.transform.position = spawnPoint.position;
    }
}
