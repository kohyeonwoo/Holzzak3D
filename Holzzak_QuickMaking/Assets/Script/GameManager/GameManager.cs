using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public enum GameState { START, PLAYERTURN, ENEMYTURN, WON, LOST}

public partial class GameManager : MonoBehaviour
{
    public static GameManager instance = null;

    public float health;

    public float maxHealth;

    public int cost = 5;

    public int limit = 0;

    public int unitCount = 0;

    public int enemyNum = 0;

    public float enemyHealth;

    public float enemyMaxHealth;

    public bool bPlayerUnitMove;

    public bool bEnemyUnitMove;

    public bool bPlayerDead;

    public bool bEnemyDead;

    public GameState state;

    public List<GameObject> unitList = new List<GameObject>();

    public List<GameObject> playerUnitSpawnLocation = new List<GameObject>();

    public GameObject enemyUnitSpawnLocation;

    public Slider healthBar;

    public Slider enemyHealthBar;

    public Text costText;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    private void Start()
    {

       
        maxHealth = 50.0f;

        health = maxHealth;

        enemyMaxHealth = 50.0f;

        enemyHealth = enemyMaxHealth;

        healthBar.value = (float)health / (float)maxHealth;

        enemyHealthBar.value = (float)health / (float)maxHealth;

        bPlayerUnitMove = false;

        bEnemyUnitMove = false;

        state = GameState.START;

        StartCoroutine(SetUp());

    }

    private void Update()
    {
        costText.text = cost.ToString();
    }

    IEnumerator SetUp()
    {


        yield return new WaitForSeconds(2.0f);
        PlayerTurn();
    }

    private void PlayerTurn()
    {
        Debug.Log("현재 플레이어 차례");
    }

    IEnumerator PlayerAttack()
    {
        yield return new WaitForSeconds(2.0f);
    }

    public void OnAttackButton()
    {
        if(state != GameState.PLAYERTURN)
        {
            return;
        }

        StartCoroutine(PlayerAttack());
    }

    public void Battle()
    {

        enemyNum = Random.Range(1, 3);

        if (enemyNum == GetPlayerNum())
        {
            Debug.Log("적의 승리");
        }
        else if (enemyNum != GetPlayerNum())
        {
            Debug.Log("플레이어의 승리");
            bPlayerUnitMove = true;
        }

        Debug.Log("적의 수 : " + enemyNum);

    }

    public int GetPlayerNum()
    {
        if(unitCount % 2 == 0)
        {
            return 0;
        }
        else
        {
            return 1;
        }
    }

    public void HandleHp()
    {
        healthBar.value = (float)health / (float)maxHealth;
    }
    public void EnemyHandleHP()
    {
        enemyHealthBar.value = (float)enemyHealth / (float)enemyMaxHealth;
    }

    public void SpawnUnit(int Code)
    {
        if(cost > 0)
        {
           if(playerUnitSpawnLocation.Count >= limit)
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

}
