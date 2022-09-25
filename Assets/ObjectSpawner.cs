using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Data;
using UnityEngine.AI;
public class ObjectSpawner : MonoBehaviour
{
    [Header("EnemyObject")]
    [SerializeField] private GameObject[] enemyObject;
    [Header("CollectableObjects")]
    [SerializeField] private GameObject[] collectables;
    [SerializeField] private CollectableObjectsList collectablesList;
    private SpawnLocations _spawnLocations;
    public float objectScale;

    public int multiplierCount;
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

                var navmeshComponent = enemy.GetComponent<NavMeshAgent>();
                navmeshComponent.speed += 1;
            }

            multiplierCount = 1;
        }

        if (type == OBJECTTYPE.COLLECTABLE)
        {
            foreach (var collectable in collectables)
            {
                selectedObject.Add(collectable);
            }
            

            multiplierCount = leveldata.level;
        }

        if (multiplierCount >= 3)
        {
            multiplierCount = 3;
        }

        for (int i = 0; i < multiplierCount; i++)
        {
            var selectedInt = Random.Range(0, selectedObject.Count);
            var selectedPoint = SelectSpawnLocation().gameObject;
            var spawnObject = Instantiate(selectedObject[selectedInt], selectedPoint.transform.position, Quaternion.identity);

            if (type == OBJECTTYPE.ENEMY)
            {
                objectScale = ((leveldata.level) / 5);
                spawnObject.transform.localScale += new Vector3(objectScale, objectScale, objectScale);
            }

            if (type == OBJECTTYPE.COLLECTABLE)
            {
                collectablesList.totalObjectsCount++;
            }
            
        }

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
        newPoints[pointValue].isActive = true;
        return newPoints[pointValue];
    }
}

public enum OBJECTTYPE
{
    ENEMY,
    COLLECTABLE
}
