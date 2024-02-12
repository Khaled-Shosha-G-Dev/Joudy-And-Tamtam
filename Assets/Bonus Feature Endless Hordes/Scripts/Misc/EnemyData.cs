using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum EnemyType{
    Minion, Boss, Prop
}

public enum Probability{
    High, Low
}

[CreateAssetMenu(fileName = "Enemy", menuName = "ScriptableObjects/EndlessHordes/Enemy", order = 1)]
public class EnemyData : ScriptableObject
{
    public GameObject modelPrefab;
    public float Health = 100f;

    public EnemyType type = EnemyType.Minion;
    public int spawnCount = 15;

    public Probability probability = Probability.High;
}
