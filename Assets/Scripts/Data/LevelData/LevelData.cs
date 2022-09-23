using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Data
{
    [CreateAssetMenu(fileName = "LevelData", menuName = "ScriptableObjects/LevelData-ScriptableObject", order = 1)]
    public class LevelData : ScriptableObject
    {
        public int level;
        public int attemptCount;
        public int totalPush;
    }
}