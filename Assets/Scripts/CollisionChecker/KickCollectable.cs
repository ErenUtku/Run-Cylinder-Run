using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CollisionChecker
{
    public class KickCollectable : MonoBehaviour
    {
        private float kickForce = 10;

        private Rigidbody _rigidbody;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }

        private void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                Vector3 direction = (other.transform.position - transform.position).normalized;
                _rigidbody.AddForce(-direction * kickForce, ForceMode.Impulse);
            }
        }
    }
}
