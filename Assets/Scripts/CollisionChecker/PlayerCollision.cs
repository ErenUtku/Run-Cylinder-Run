using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Movement;
namespace CollisionChecker
{
    public class PlayerCollision : MonoBehaviour
    {
        private void OnTriggerExit(Collider other)
        {
            if (other.gameObject.CompareTag("Ground"))
            {
                this.gameObject.GetComponent<PlayerMovementController>().enabled = false;
            }
        }
    }
}
