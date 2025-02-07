using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;

    public int cost = 5;

    public List<GameObject> unitList = new List<GameObject>();

    public List<GameObject> playerUnitSpawnLocation = new List<GameObject>();

    public GameObject enemyUnitSpawnLocation;

    public Text costText;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    private void Update()
    {
        costText.text = cost.ToString();
    }

    public void SpawnUnit(int Code)
    {
        if(cost > 0)
        {
            switch (Code)
            {
                case 0:
                    Instantiate(unitList[Code], playerUnitSpawnLocation[0].transform.position, playerUnitSpawnLocation[0].transform.rotation);
                    cost -= 1;
                    break;

                case 1:
                    Instantiate(unitList[Code], playerUnitSpawnLocation[0].transform.position, playerUnitSpawnLocation[0].transform.rotation);
                    break;

                case 2:
                    Instantiate(unitList[Code], playerUnitSpawnLocation[0].transform.position, playerUnitSpawnLocation[0].transform.rotation);
                    break;

                case 3:
                    Instantiate(unitList[Code], playerUnitSpawnLocation[0].transform.position, playerUnitSpawnLocation[0].transform.rotation);
                    break;

                case 4:
                    Instantiate(unitList[Code], playerUnitSpawnLocation[0].transform.position, playerUnitSpawnLocation[0].transform.rotation);
                    break;

                default:
                    break;
            }
        }
        else
        {
            Debug.Log("보유 코스트를 전부 사용했습니다.");
        }

        
    }

}
