using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Data;
public class ObjectSpawner : MonoBehaviour
{
    [Header("EnemyObject")]
    [SerializeField] private GameObject[] enemyObject;
    [Header("CollectableObjects")]
    [SerializeField] private GameObject[] collectables;
    private SpawnLocations _spawnLocations;
    private float objectScale;

    private void Start()
    {
        _spawnLocations = GetComponent<SpawnLocations>();
    }

    public void InstantiateObject(OBJECTTYPE type,LevelData leveldata)
    {
        var selectedObject = new List<GameObject>();

        if (type == OBJECTTYPE.ENEMY)
        {
            foreach (var enemy in enemyObject)
            {
                selectedObject.Add(enemy);
            }

            objectScale = (leveldata.level)/5;

        }

        if (type == OBJECTTYPE.COLLECTABLE)
        {
            foreach (var collectable in collectables)
            {
                selectedObject.Add(collectable);
            }

            objectScale = 0;
        }

        var selectedInt = Random.Range(0, collectables.Length);
        var selectedPoint = SelectSpawnLocation().gameObject;
        var spawnObject = Instantiate(selectedObject[selectedInt], selectedPoint.transform.position, Quaternion.identity);
        
        spawnObject.transform.localScale += new Vector3(objectScale, objectScale, objectScale);

        selectedObject.Clear();
    }

    private SpawnPoint SelectSpawnLocation()
    {
        var newPoints = new List<SpawnPoint>();
        foreach (var point in _spawnLocations.spawnPoints)
        {
            if (point.isActive == false)
            {
                newPoints.Add(point);
            }
        }
        var pointValue = Random.Range(0, newPoints.Count);
        return newPoints[pointValue];
    }
}

public enum OBJECTTYPE
{
    ENEMY,
    COLLECTABLE
}
