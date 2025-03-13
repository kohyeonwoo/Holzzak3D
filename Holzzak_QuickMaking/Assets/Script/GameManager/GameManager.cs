using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum GameState { START, PLAYERTURN, ENEMYTURN, WON, LOST}

public enum PlayerCharacter { Commissar, Magician, Knight}

public enum EnemyCharacter { Orks, PartyMonster, Guard, Mannequin}


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

    public int enemyListIndex = 0;

    public int enemyMainIndex = 0;

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

    public PlayerCharacter playerCharacter;

    public EnemyCharacter enemyCharacter;

    public GameObject knightShield;

    public GameObject healParticle;

    public GameObject healParticleLocation;

    public List<GameObject> enemyMainList = new List<GameObject>();

    public List<GameObject> unitList = new List<GameObject>();

    public List<GameObject> enemyUnitList = new List<GameObject>();

    public List<GameObject> specialUnitList = new List<GameObject>();

    public List<GameObject> playerUnitSpawnLocation = new List<GameObject>();

    public List<GameObject> enemyUnitSpawnLocation = new List<GameObject>();

    public GameObject playerChooseButton;

    public GameObject playerAbilityButton;

    public GameObject winPannel;

    public GameObject losePannel;

    public GameObject lowCostImage;

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

        AudioManager.Instance.PlayMusic("Background1");

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

        enemyMainIndex = 0;

        state = GameState.START;

        playerCharacter = PlayerCharacter.Commissar;

        enemyCharacter = EnemyCharacter.Orks;

    }

    private void Update()
    {
        costText.text = cost.ToString();

        SetEnemyMainCharacter();

        if (cost < 3)
        {
            lowCostImage.SetActive(true);
        }
        else
        {
            lowCostImage.SetActive(false);
        }

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
        playerAbilityButton.SetActive(true);
        yield return new WaitForSeconds(3.0f);
        playerAbilityButton.SetActive(false);
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

    public void PluseEnemyMainCharacterIndex()
    {
        enemyMainIndex++;
    }

    public void SetEnemyMainCharacter()
    {
        switch (enemyMainIndex)
        {
            //enemyMainIndex --> 0 오크 , 1 파티, 2 가드, 3 마네퀸
            case 0:
                enemyMainList[0].SetActive(true);
                enemyMainList[1].SetActive(false);
                enemyMainList[2].SetActive(false);
                enemyMainList[3].SetActive(false);
                enemyCharacter = EnemyCharacter.Orks;
                break;
            case 1:
                enemyMainList[0].SetActive(false);
                enemyMainList[1].SetActive(true);
                enemyMainList[2].SetActive(false);
                enemyMainList[3].SetActive(false);
                enemyCharacter = EnemyCharacter.PartyMonster;
                break;
            case 2:
                enemyMainList[0].SetActive(false);
                enemyMainList[1].SetActive(false);
                enemyMainList[2].SetActive(true);
                enemyMainList[3].SetActive(false);
                enemyCharacter = EnemyCharacter.Guard;
                break;
            case 3:
                enemyMainList[0].SetActive(false);
                enemyMainList[1].SetActive(false);
                enemyMainList[2].SetActive(false);
                enemyMainList[3].SetActive(true);
                enemyCharacter = EnemyCharacter.Mannequin;
                break;
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

    public void UseAbility()
    { 
        
        switch(playerCharacter)
        {
            case PlayerCharacter.Commissar:
                CommissarAbility();
                break;
            case PlayerCharacter.Magician:
                MagicianAbility();
                break;
            case PlayerCharacter.Knight:
                KnightAbility();
                break; 
        }

    }


    public void SetPlayerCharacter1()
    {
        playerCharacter = PlayerCharacter.Commissar;
    }

    public void SetPlayerCharacter2()
    {
        playerCharacter = PlayerCharacter.Magician;
    }

    public void SetPlayerCharacter3()
    {
        playerCharacter = PlayerCharacter.Knight;
    }

    public void CommissarAbility()
    {
        PlayerSpawnUnit();
    }

    public void MagicianAbility()
    {
        int point = Random.Range(1, 6);

        GameObject obj = Instantiate(healParticle, healParticleLocation.transform.position, Quaternion.identity);
        Destroy(obj, 2.0f);

        health += point;
        HandleHp();
    }

    public void KnightAbility()
    {
        SpawnKnightShield();
    }

    public void HandleHp()
    {
        healthBar.value = (float)health / (float)maxHealth;
    }
    public void EnemyHandleHP()
    {
        enemyHealthBar.value = (float)enemyHealth / (float)enemyMaxHealth;
    }

    public void NextGame()
    {
        health = maxHealth;
        enemyHealth = enemyMaxHealth;
        //enemyMainIndex++;
        enemyListIndex++;
        HandleHp();
        EnemyHandleHP();
        losePannel.SetActive(false);
    }

    public void Retry()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void GoMenu()
    {
        SceneManager.LoadScene("GameScene");
    }
    
}
