using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class GameManager : MonoBehaviour
{
    public void EnemySpawnUnit(int Code)
    {
        if (cost > 0)
        {
            if (enemyUnitSpawnLocation.Count >= enemyLimit)
            {
                switch (Code)
                {
                    case 0:
                        Instantiate(unitList[Code], enemyUnitSpawnLocation[enemyLimit].transform.position, enemyUnitSpawnLocation[enemyLimit].transform.rotation);
                        enemyLimit++;
                        enemyCount++;
                        cost -= 1;
                        break;

                    case 1:
                        Instantiate(unitList[Code], enemyUnitSpawnLocation[enemyLimit].transform.position, enemyUnitSpawnLocation[enemyLimit].transform.rotation);
                        enemyLimit++;
                        enemyCount++;
                        cost -= 2;
                        break;

                    case 2:
                        Instantiate(unitList[Code], enemyUnitSpawnLocation[enemyLimit].transform.position, enemyUnitSpawnLocation[enemyLimit].transform.rotation);
                        enemyLimit++;
                        enemyCount++;
                        cost -= 3;
                        break;

                    case 3:
                        Instantiate(unitList[Code], enemyUnitSpawnLocation[enemyLimit].transform.position, enemyUnitSpawnLocation[enemyLimit].transform.rotation);
                        enemyLimit++;
                        enemyCount++;
                        cost -= 4;
                        break;

                    case 4:
                        Instantiate(unitList[Code], enemyUnitSpawnLocation[enemyLimit].transform.position, enemyUnitSpawnLocation[enemyLimit].transform.rotation);
                        enemyLimit++;
                        enemyCount++;
                        cost -= 5;
                        break;

                    case 5:
                        Instantiate(unitList[Code], enemyUnitSpawnLocation[enemyLimit].transform.position, enemyUnitSpawnLocation[enemyLimit].transform.rotation);
                        enemyLimit++;
                        enemyCount++;
                        cost -= 6;
                        break;

                    case 6:
                        Instantiate(unitList[Code], enemyUnitSpawnLocation[enemyLimit].transform.position, enemyUnitSpawnLocation[enemyLimit].transform.rotation);
                        enemyLimit++;
                        enemyCount++;
                        cost -= 7;
                        break;

                    case 7:
                        Instantiate(unitList[Code], enemyUnitSpawnLocation[enemyLimit].transform.position, enemyUnitSpawnLocation[enemyLimit].transform.rotation);
                        enemyLimit++;
                        enemyCount++;
                        cost -= 8;
                        break;

                    case 8:
                        Instantiate(unitList[Code], enemyUnitSpawnLocation[enemyLimit].transform.position, enemyUnitSpawnLocation[enemyLimit].transform.rotation);
                        enemyLimit++;
                        enemyCount++;
                        cost -= 9;
                        break;

                    case 9:
                        Instantiate(unitList[Code], enemyUnitSpawnLocation[enemyLimit].transform.position, enemyUnitSpawnLocation[enemyLimit].transform.rotation);
                        enemyLimit++;
                        enemyCount++;
                        cost -= 10;
                        break;

                    default:
                        break;
                }
            }
        }
    }
}
