using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
namespace Movement
{
    public class EnemyMovement : MonoBehaviour
    {
        public Transform targetPlayer;

        private NavMeshAgent navMeshAgent;

        private void Start()
        {
            navMeshAgent = GetComponent<NavMeshAgent>();
        }

        private void Update()
        {
            if (targetPlayer != null)
            {
                navMeshAgent.destination = targetPlayer.position;
            }
        }
    }
}