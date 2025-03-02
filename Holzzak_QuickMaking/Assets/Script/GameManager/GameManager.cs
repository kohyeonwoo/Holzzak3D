using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public enum GameState { START, PLAYERTURN, ENEMYTURN, WON, LOST}

public enum PlayerCharacter { NONE, Commissar, Magician, WON, LOST}


public partial class GameManager : MonoBehaviour
{
    public static GameManager instance = null;

    public float health;

    public float maxHealth;

    public int cost = 5;

    public int limit = 0;

    public int enemyLimit = 0;

    public int unitCount = 0;

    public int enemyCount = 0;

    public int playerNum = 0;

    public int enemyNum = 0;

    public float enemyHealth;

    public float enemyMaxHealth;

    public bool bPlayerUnitMove;

    public bool bPlayerUnitDestroy;

    public bool bEnemyUnitMove;

    public bool bEnemyUnitDestroy;

    public bool bPlayerDead;

    public bool bEnemyDead;

    public bool bShake;

    public GameState state;

    public GameObject enemies;

    public List<GameObject> unitList = new List<GameObject>();

    public List<GameObject> unitClones = new List<GameObject>();

    public List<GameObject> playerUnitSpawnLocation = new List<GameObject>();

    public List<GameObject> enemyUnitSpawnLocation = new List<GameObject>();

    public GameObject playerChooseButton;

    public GameObject winPannel;

    public GameObject losePannel;

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

        maxHealth = 15.0f;

        health = maxHealth;

        enemyMaxHealth = 15.0f;

        enemyHealth = enemyMaxHealth;

        healthBar.value = (float)health / (float)maxHealth;

        enemyHealthBar.value = (float)health / (float)maxHealth;

        bPlayerUnitMove = false;

        bEnemyUnitMove = false;

        bPlayerUnitDestroy = false;

        bEnemyUnitDestroy = false;

        bShake = false;

        state = GameState.START;
       
    }

    private void Update()
    {
        costText.text = cost.ToString();
    }

    public void BattleStart()
    {
        StartCoroutine(Battle());
    }

    IEnumerator Battle()
    {
        playerChooseButton.SetActive(false);
        bPlayerUnitMove = true;
        bEnemyUnitMove = true;
        yield return new WaitForSeconds(3.0f);
        playerChooseButton.SetActive(true);
        enemyLimit = 0;
        enemyCount = 0;
        limit = 0;
        unitCount = 0;

        if(health <= 0)
        {
            losePannel.SetActive(true);
        }

        if(enemyHealth <= 0)
        {
            winPannel.SetActive(true);
        }
    }

    private void PlayerTurn()
    {
        state = GameState.PLAYERTURN;
        Debug.Log("현재 플레이어 차례");
    }

    IEnumerator EnemyTurn()
    {

        yield return new WaitForSeconds(1.0f);

        EnemyTurns();

        if(health < 0)
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


    private void EnemyTurns()
    {
        state = GameState.ENEMYTURN;
        Debug.Log("현재 적 차례");
    }

    IEnumerator PlayerAttack()
    {
        
        yield return new WaitForSeconds(2.0f);
        //yield return new WaitForSeconds(0.5f);

        if(enemyHealth < 0)
        {
            state = GameState.WON;
            EndBattle();
        }
        else
        {
            state = GameState.ENEMYTURN;
            EnemyTurns();
        }

    }

    public void OnAttackButton()
    {
        if((state != GameState.PLAYERTURN) && (unitCount <= 1))
        {
            return;
        }

        StartCoroutine(PlayerAttack());
    }

    private void EndBattle()
    {
        if(state == GameState.WON)
        {
            Debug.Log("플레이어 승리");
        }
        else if(state == GameState.LOST)
        {
            Debug.Log("상대방 승리");
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

    
}
