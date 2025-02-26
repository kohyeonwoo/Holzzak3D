using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class GameManager : MonoBehaviour
{
    public void SpawnUnit(int Code)
    {
        if (cost > 0)
        {
            if (playerUnitSpawnLocation.Count >= limit)
            {
                switch (Code)
                {
                    case 0:
                        Instantiate(unitList[Code], playerUnitSpawnLocation[limit].transform.position, playerUnitSpawnLocation[limit].transform.rotation);
                        limit++;
                        unitCount++;
                        cost -= 1;
                        break;

                    case 1:
                       Instantiate(unitList[Code], playerUnitSpawnLocation[limit].transform.position, playerUnitSpawnLocation[limit].transform.rotation);
                        limit++;
                        unitCount++;
                        cost -= 2;
                        break;

                    case 2:
                       Instantiate(unitList[Code], playerUnitSpawnLocation[limit].transform.position, playerUnitSpawnLocation[limit].transform.rotation);
                        limit++;
                        unitCount++;
                        cost -= 3;
                        break;

                    case 3:
                       Instantiate(unitList[Code], playerUnitSpawnLocation[limit].transform.position, playerUnitSpawnLocation[limit].transform.rotation);
                        limit++;
                        unitCount++;
                        cost -= 4;
                        break;

                    case 4:
                        Instantiate(unitList[Code], playerUnitSpawnLocation[limit].transform.position, playerUnitSpawnLocation[limit].transform.rotation);
                        limit++;
                        unitCount++;
                        cost -= 5;
                        break;

                    case 5:
                       Instantiate(unitList[Code], playerUnitSpawnLocation[limit].transform.position, playerUnitSpawnLocation[limit].transform.rotation);
                        limit++;
                        unitCount++;
                        cost -= 6;
                        break;

                    case 6:
                        Instantiate(unitList[Code], playerUnitSpawnLocation[limit].transform.position, playerUnitSpawnLocation[limit].transform.rotation);
                        limit++;
                        unitCount++;
                        cost -= 7;
                        break;

                    case 7:
                        Instantiate(unitList[Code], playerUnitSpawnLocation[limit].transform.position, playerUnitSpawnLocation[limit].transform.rotation);
                        limit++;
                        unitCount++;
                        cost -= 8;
                        break;

                    case 8:
                       Instantiate(unitList[Code], playerUnitSpawnLocation[limit].transform.position, playerUnitSpawnLocation[limit].transform.rotation);
                        limit++;
                        unitCount++;
                        cost -= 9;
                        break;

                    case 9:
                        Instantiate(unitList[Code], playerUnitSpawnLocation[limit].transform.position, playerUnitSpawnLocation[limit].transform.rotation);
                        limit++;
                        unitCount++;
                        cost -= 10;
                        break;

                    default:
                        break;
                }
            }
        }
        else
        {
            Debug.Log("보유 코스트를 전부 사용했습니다.");
        }
    }


    public void PlayerSpawnUnit()
    {

        int rand = Random.Range(1, 6);
        int rand2 = Random.Range(0, 2);

        for (int i = 1; i <= rand; i++)
        {
            if (playerUnitSpawnLocation.Count >= limit)
            {
                Instantiate(unitList[rand2], playerUnitSpawnLocation[limit].transform.position, playerUnitSpawnLocation[limit].transform.rotation);
                limit++;
                unitCount++;
            }
        }



    }

}
