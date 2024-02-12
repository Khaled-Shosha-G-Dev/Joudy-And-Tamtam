using UnityEngine;
using UnityEngine.EventSystems;

public abstract class SpawnerObject : MonoBehaviour
{
    public abstract void Spawn(EnemysController enemysController, int count);
}