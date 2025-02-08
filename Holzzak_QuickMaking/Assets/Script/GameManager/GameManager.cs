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

    public float enemyHealth;

    public float enemyMaxHealth;

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
        state = GameState.START;

        maxHealth = 50.0f;

        health = maxHealth;

        enemyMaxHealth = 50.0f;

        enemyHealth = enemyMaxHealth;

        healthBar.value = (float)health / (float)maxHealth;

        enemyHealthBar.value = (float)health / (float)maxHealth;

    }

    private void Update()
    {
        costText.text = cost.ToString();
    }

    public void Battle()
    {
        int enemyNum = Random.Range(1, 11);
    }

    private void HandleHp()
    {
        healthBar.value = (float)health / (float)maxHealth;
    }

    private void EnemyHandleHP()
    {
        enemyHealthBar.value = (float)enemyHealth / (float)enemyMaxHealth;
    }

    IEnumerator PlayerAttack()
    {

        bool isDead = false;

        yield return new WaitForSeconds(2.0f);

        if(isDead)
        {
            state = GameState.WON;
            EndBattle();
        }
        else
        {
            state = GameState.ENEMYTURN;
            StartCoroutine(EnemyTurn());
        }

    }

    IEnumerator EnemyTurn()
    {
        yield return new WaitForSeconds(1.0f);

        bool isDead = true;

        yield return new WaitForSeconds(1.0f);

        if(isDead)
        {
            state = GameState.LOST;
            EndBattle();
        }
        else
        {
            state = GameState.PLAYERTURN;
            PlayerTurn();
        }
    }

    private void EndBattle()
    {
        if(state == GameState.WON)
        {
            
        }
        else if(state == GameState.LOST)
        {

        }
    }

    private void PlayerTurn()
    {

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
