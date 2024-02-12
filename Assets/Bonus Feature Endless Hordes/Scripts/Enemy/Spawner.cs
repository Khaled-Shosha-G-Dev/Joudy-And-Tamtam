using UnityEngine;

public class Spawner : MonoBehaviour
{
    public delegate void OnSpawn(EnemysController enemysController);

    private OnSpawn _onSpawn;

    public void SetOnSpawnFunction(OnSpawn onspawn){
        _onSpawn = onspawn;
    }
}