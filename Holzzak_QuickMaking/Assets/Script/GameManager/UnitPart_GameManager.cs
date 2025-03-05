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
        int rand3 = Random.Range(2, 7);
       
        for (int i = 1; i <= rand; i++)
        {
            if (playerUnitSpawnLocation.Count >= limit)
            {

                switch (playerCharacter)
                {
                    case PlayerCharacter.Commissar:
                        Instantiate(unitList[rand2], playerUnitSpawnLocation[limit].transform.position, playerUnitSpawnLocation[limit].transform.rotation);
                        limit++;
                        unitCount++;
                        break;

                    case PlayerCharacter.Magician:
                        Instantiate(unitList[rand3], playerUnitSpawnLocation[limit].transform.position, playerUnitSpawnLocation[limit].transform.rotation);
                        limit++;
                        unitCount++;
                        break;

                    case PlayerCharacter.Knight:
                        Instantiate(unitList[9], playerUnitSpawnLocation[limit].transform.position, playerUnitSpawnLocation[limit].transform.rotation);
                        limit++;
                        unitCount++;
                        break;

                }

             
            }

           

          
        }
    }

    public void PlayerSpawnSpecialUnit()
    {
        int rand = Random.Range(0, 7);
        int rand2 = Random.Range(0, playerUnitSpawnLocation.Count - 1);

        if(cost >= 3)
        {
            Instantiate(specialUnitList[rand], playerUnitSpawnLocation[rand2].transform.position, playerUnitSpawnLocation[rand2].transform.rotation);
            cost -= 3;
        }
     
    }

   
}
