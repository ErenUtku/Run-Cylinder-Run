using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Data
{
    [CreateAssetMenu(fileName = "CollectableData", menuName = "ScriptableObjects/CollectableData-ScriptableObject", order = 1)]
    public class CollectablesData : ScriptableObject
    {
        public NAME dataName;
        public int score;
    }

    public enum NAME
    {
        SPHERE,
        CAPSULE
    }
}
