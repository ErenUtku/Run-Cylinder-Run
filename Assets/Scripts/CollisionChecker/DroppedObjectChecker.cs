using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CollisionChecker
{
    public class DroppedObjectChecker : MonoBehaviour
    {
        [SerializeField] private ScoreCalculator scoreCalculator;

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
                Destroy(other.gameObject);
                scoreCalculator.IncreaseTotalPush();
                Debug.Log("Collected");
            }

            if (other.gameObject.CompareTag("Player"))
            {
                _uiManager.FailUIActivation(true);
                scoreCalculator.IncreaseAttemptCount();
                Time.timeScale = 0;
                Debug.Log("Game is Over");
            }
        }
    }
}
