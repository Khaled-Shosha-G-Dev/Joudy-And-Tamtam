using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCreator : MonoBehaviour
{
    [SerializeField] private int numberOfEnemyInLevel;
    [SerializeField] private GameObject enemyInstance;
    [SerializeField] private GameObject creatorPoint1 , creatorPoint2 , creatorPoint3 , creatorPoint4;

    enum CreatorPoints
    {
        CP1 =1, CP2 =2 , CP3 =3, CP4 =4
    }
    // Start is called before the first frame update
    void Start()
    {
        numberOfEnemyInLevel = 4;
    }

    // Update is called once per frame
    void Update()
    {

        CreateNewEnemy();
    }

    private int GetEnemyNumber()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        // Get the number of enemies
        int numberOfEnemies = enemies.Length;

        return numberOfEnemies;
    }

    private void CreateNewEnemy()
    {
        if (GetEnemyNumber() < numberOfEnemyInLevel)
        {
            SelectCreatorPoint();
        }
    }
    private void SelectCreatorPoint()
    {
        int creatorPoint = Random.Range(1,5);
        CreatorPoints selectedCreatorPoint = (CreatorPoints)creatorPoint;
        if(selectedCreatorPoint == CreatorPoints.CP1)
            Instantiate(enemyInstance, creatorPoint1.transform);
        else if (selectedCreatorPoint == CreatorPoints.CP2)
            Instantiate(enemyInstance, creatorPoint2.transform);
        else if (selectedCreatorPoint == CreatorPoints.CP3)
            Instantiate(enemyInstance, creatorPoint3.transform);
        else if (selectedCreatorPoint == CreatorPoints.CP4)
            Instantiate(enemyInstance, creatorPoint4.transform);
    }


}
