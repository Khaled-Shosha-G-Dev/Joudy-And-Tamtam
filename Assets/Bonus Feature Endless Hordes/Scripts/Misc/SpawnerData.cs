using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Spawner Data", menuName = "ScriptableObjects/EndlessHordes/Spawner", order = 1)]
public class SpawnerData : ScriptableObject
{
    public SpawnerLevel[] levels;

    [System.Serializable]
    public class SpawnerLevel{

        public EnemyData[] types;
    }
}
