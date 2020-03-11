using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    public Transform SpawnPoint;
    public GameObject Player;

    private void OnTriggerEnter(Collider other)
    {
        Player.transform.position = SpawnPoint.transform.position;
    }
}
