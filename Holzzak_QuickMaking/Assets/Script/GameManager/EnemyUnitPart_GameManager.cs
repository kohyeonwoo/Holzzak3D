using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class GameManager : MonoBehaviour
{
    public void EnemySpawnUnit()
    {

        int rand = Random.Range(1, 6);

        for(int i =1; i <= rand; i++)
        {
            if (enemyUnitSpawnLocation.Count >= enemyLimit)
            {
                Instantiate(enemyUnitList[enemyMainIndex], enemyUnitSpawnLocation[enemyLimit].transform.position, enemyUnitSpawnLocation[enemyLimit].transform.rotation);
                enemyLimit++;
                enemyCount++;
            }
        }

           
        
    }
}
