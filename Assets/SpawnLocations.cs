using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnLocations : MonoBehaviour
{
    public SpawnPoint[] spawnPoints;

    private void Start()
    {
        spawnPoints = GetComponentsInChildren<SpawnPoint>();
    }
}
