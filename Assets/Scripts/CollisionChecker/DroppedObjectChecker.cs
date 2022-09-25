using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CollisionChecker
{
    public class DroppedObjectChecker : MonoBehaviour
    {
        [SerializeField] private ObjectSpawner objectSpawner;
        [SerializeField] private ScoreCalculator scoreCalculator;
        [SerializeField] private CollectableObjectsList collectableList;
        private OBJECTTYPE objectType;
        private UIManager _uiManager;
        private void Start()
        {
            Time.timeScale = 1;
            _uiManager = UIManager.instance;
        }
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Collectable"))
            {
               

                CollectObject(other);
            }

            if (other.gameObject.CompareTag("Player"))
            {
                _uiManager.FailUIActivation(true);
                scoreCalculator.IncreaseAttemptCount();
                Time.timeScale = 0;
                Debug.Log("Game is Over");
            }
        }

        public void CollectObject(Collider other)
        {
            if (collectableList.totalObjectsCount != 0)
            {
                collectableList.totalObjectsCount--;

            }

            Destroy(other.gameObject);
            var data = other.GetComponent<CollectableObject>().objectData;
            scoreCalculator.IncreaseScore(data);
            scoreCalculator.IncreaseTotalPush();
            objectType = OBJECTTYPE.COLLECTABLE;
            Debug.Log("Collected");

            if (collectableList.totalObjectsCount == 0)
            {
                objectSpawner.InstantiateObject(objectType, scoreCalculator.ReturnCurrentData());
                
            }
        }
    }
}
