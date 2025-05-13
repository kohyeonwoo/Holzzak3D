using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum GameState { START, PLAYERTURN, ENEMYTURN, WON, LOST}


public partial class GameManager : MonoBehaviour
{
    public static GameManager instance = null;

    public float health;

    public float maxHealth;

    public float enemyHealth;

    public float enemyMaxHealth;

    public float timer;

    public int team1DeadCount;

    public int team2DeadCount;

    public bool bShake;

    public bool bAttack;

    public GameState state;

    public List<GameObject> playerUnitSpawnLocation = new List<GameObject>();

    public List<GameObject> enemyUnitSpawnLocation = new List<GameObject>();

    public List<Soldiers> soldiers = new List<Soldiers>();

    public GameObject diceRollButton;

    public GameObject winPannel;

    public GameObject team1WinText;

    public GameObject team2WinText;

    public GameObject drawText;

    public Slider healthBar;

    public Slider enemyHealthBar;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    private void Start()
    {

        //AudioManager.Instance.PlayMusic("Background1");

        maxHealth = 15.0f;

        health = maxHealth;

        enemyMaxHealth = 15.0f;

        enemyHealth = enemyMaxHealth;

        healthBar.value = (float)health / (float)maxHealth;

        enemyHealthBar.value = (float)health / (float)maxHealth;

        bShake = false;

        bAttack = false;

        state = GameState.START;

    }
 
    public void ActiveDiceButton()
    {
        diceRollButton.SetActive(true);
    }

    public void DeActiveDiceButton()
    {
        diceRollButton.SetActive(false);
    }

    public void Attacks()
    {
        for(int i =0; i < soldiers.Count; i++)
        {
            soldiers[i].Attack();
        }

        Invoke("ActiveResult", timer);
    }

    public void ActiveResult()
    {
        winPannel.SetActive(true);

        if(team1DeadCount < team2DeadCount)
        {
            team1WinText.SetActive(true);
        }
        else if(team1DeadCount > team2DeadCount)
        {
            team2WinText.SetActive(true);
        }
        else
        {
            drawText.SetActive(true);
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

    public void Retry()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void GoMenu()
    {
        SceneManager.LoadScene("StartScene");
    }
    
}
