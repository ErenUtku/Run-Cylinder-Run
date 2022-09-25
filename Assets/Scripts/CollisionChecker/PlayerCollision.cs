using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Movement;
using Spawn;

namespace CollisionChecker
{
    public class PlayerCollision : MonoBehaviour
    {
        [SerializeField] private DroppedObjectChecker droppedObject;
        private void OnTriggerExit(Collider other)
        {
            if (other.gameObject.CompareTag("Ground"))
            {
                this.gameObject.GetComponent<PlayerMovementController>().enabled = false;
            }

            if (other.gameObject.CompareTag("SpawnPoint"))
            {
                other.GetComponent<SpawnPoint>().isActive = false;
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Collectable-Static"))
            {
                droppedObject.CollectObject(other);
            }

            if (other.gameObject.CompareTag("SpawnPoint"))
            {
                other.GetComponent<SpawnPoint>().isActive = true;
            }
        }
    }
}
