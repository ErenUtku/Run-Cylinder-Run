using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Movement
{
    public class PlayerMovementController : MonoBehaviour
    {
        [SerializeField] private float speed;
        private Rigidbody _rigidbody;
        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }
        private void Update()
        {
            float xDirection = Input.GetAxis("Horizontal");
            float zDirection = Input.GetAxis("Vertical");

            Vector3 moveDirection = new Vector3(xDirection, 0 ,zDirection) * speed * Time.deltaTime;

            _rigidbody.MovePosition(transform.position + moveDirection);
        }
    }
}
