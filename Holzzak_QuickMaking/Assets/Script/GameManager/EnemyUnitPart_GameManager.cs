using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class GameManager : MonoBehaviour
{
    public void EnemySpawnUnit()
    {

        int rand = Random.Range(0, 6);

        for(int i =0; i < rand; i++)
        {
            if (enemyUnitSpawnLocation.Count >= enemyLimit)
            {
                Instantiate(enemies, enemyUnitSpawnLocation[limit].transform.position, enemyUnitSpawnLocation[limit].transform.rotation);
                limit++;
                unitCount++;
            }
        }

           
        
    }
}
