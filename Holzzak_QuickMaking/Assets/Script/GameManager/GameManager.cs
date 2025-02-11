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

    public int enemyLimit = 0;

    public int unitCount = 0;

    public int enemyCount = 0;

    public int playerNum = 0;

    public int enemyNum = 0;

    public float enemyHealth;

    public float enemyMaxHealth;

    public bool bPlayerUnitMove;

    public bool bEnemyUnitMove;

    public bool bPlayerDead;

    public bool bEnemyDead;

    public GameState state;

    public List<GameObject> unitList = new List<GameObject>();

    public List<GameObject> unitClones = new List<GameObject>();

    public List<GameObject> playerUnitSpawnLocation = new List<GameObject>();

    public List<GameObject> enemyUnitSpawnLocation = new List<GameObject>();

    public GameObject playerAttackButton;

    public GameObject playerDefenceButton;

    public GameObject playerHitEffect;

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

        playerAttackButton.SetActive(false);

        playerDefenceButton.SetActive(false);

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
        SetTurn();
    }

    public void SetTurn()
    {
        int rand = Random.Range(1, 3);

        if(rand == 1)
        {
            PlayerTurn();
        }else
        {
            EnemyTurn();
        }
    }

    private void PlayerTurn()
    {
        Debug.Log("현재 플레이어 차례");

        playerAttackButton.SetActive(true);
        playerDefenceButton.SetActive(false);
    }

    private void EnemyTurn()
    {
        Debug.Log("현재 적 차례");

        playerAttackButton.SetActive(false);
        playerDefenceButton.SetActive(true);
    }

    IEnumerator PlayerAttack()
    {

        yield return new WaitForSeconds(2.0f);

        Battle();

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
            EnemyTurn();
            Debug.Log("상대방 방어 성공");
        }
        else if (enemyNum != GetPlayerNum())
        {
            Debug.Log("플레이어 예측 성공");
            bPlayerUnitMove = true;
        }

        Debug.Log("적의 수 : " + enemyNum);

    }

    public void Battle_Enemy()
    {
        if (playerNum == GetEnemyNum())
        {
            PlayerTurn();
            Debug.Log("상대방 방어 성공");
        }
        else if (playerNum != GetEnemyNum())
        {
            Debug.Log("플레이어 예측 성공");
            bEnemyUnitMove = true;
        }

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

    public int GetEnemyNum()
    {
        if (enemyCount % 2 == 0)
        {
            return 0;
        }
        else
        {
            return 1;
        }
    }

    public void PlayerDefenceNum(int Num)
    {
        playerNum = Num;
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
