using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEngine.GraphicsBuffer;
public class StatSystem : MonoBehaviour
{

    public int playerCurrentHealth = 100;
    public int playerMaxHealth = 100;
    public int CurrentHealth = 100;
    public int playerExperiencePoints = 0;
    public int playerLevel = 1;
    public int playerGold = 0;

    public int enemyMaxHealth = 80;
    public int enemyCurrentHealth = 80;
    public int enemyMinDamage = 2;
    public int enemyMaxDamage = 9;
    public int levelLoadCount = 0;
    public GameObject level;
    public GameObject castleDoorOpen;

    public GameObject Player;
    public GameObject PlayerInstance;
    public TMP_Text damageDealtText;

    public Sprite[] levelStatesIntro = new Sprite[3];
    public Sprite[] levelStatesCastleLevel1 = new Sprite[6];
    public Sprite[] levelStatesBossLevel = new Sprite[6];

    public int goblinKills;

    public static StatSystem Instance { get; private set; }
    private void Start()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
        
    }

    public  void ResetPlayerStats()
    {
        playerCurrentHealth = playerMaxHealth;
        playerExperiencePoints = 0;
        playerLevel = 1;
        playerGold = 0;
    }
    private void Update()
    {
        ColourLevel();
        if (PlayerInstance == null)
        {
            PlayerInstance = GameObject.Find("Player");
        } else
        {
            PlayerInstance = Instantiate(Player).gameObject;
        }
        level = GameObject.Find("LevelBackground");
        if (SceneManager.GetActiveScene().name == "IntroLevel")
        {
            if (castleDoorOpen == null)
            {
                castleDoorOpen = level.transform.Find("CastleDoorOpening").gameObject;

            }
        }
    }
    public void TakeDamage(GameObject gameObject, int damage)
    {

        if (gameObject.CompareTag("Player"))
        {
            Player player = gameObject.GetComponent<Player>();

                player.currentHealth -= damage;
                GameObject damageDealtTextInstance = Instantiate(damageDealtText.gameObject, GameObject.Find("DamageTextCanvas").GetComponent<Canvas>().transform);
                damageDealtTextInstance.GetComponent<DamageDeltText>().flagPlayerText = true;
                damageDealtTextInstance.GetComponent<TMP_Text>().text = "-" + damage.ToString();
                
        }
        else if (gameObject.CompareTag("Goblin"))
        {
            Enemy enemy = gameObject.GetComponent<Enemy>();

                enemy.currentHealth -= damage;
                GameObject damageDealtTextInstance = Instantiate(damageDealtText.gameObject, enemy.transform.position , Quaternion.identity, GameObject.Find("DamageTextCanvas").GetComponent<Canvas>().transform);
                damageDealtTextInstance.GetComponent<DamageDeltText>().flagPlayerText = false;
                damageDealtTextInstance.GetComponent<TMP_Text>().text = "-" + damage.ToString();   
        }

    }

    public int DealDamage(int minDamage, int maxDamage)
    {
        
        return Random.Range(minDamage, maxDamage + 1);
        
    }
    public void ColourLevel()
    {
        if (SceneManager.GetActiveScene().name == "IntroLevel")
        {
            if (goblinKills == 6)
            {
                level.GetComponent<SpriteRenderer>().sprite = levelStatesIntro[2];
                castleDoorOpen.SetActive(true);
            }
            else if (goblinKills == 4)
            {
                level.GetComponent<SpriteRenderer>().sprite = levelStatesIntro[1];
            }
            else if (goblinKills == 2)
            {
                level.GetComponent<SpriteRenderer>().sprite = levelStatesIntro[0];
            }
        }
        if (SceneManager.GetActiveScene().name == "CastleLevel1")
        {
            if (goblinKills == 6)
            {
                level.GetComponent<SpriteRenderer>().sprite = levelStatesCastleLevel1[5];

            }
            else if (goblinKills == 5)
            {
                level.GetComponent<SpriteRenderer>().sprite = levelStatesCastleLevel1[4];

            }
            else if (goblinKills == 4)
            {
                level.GetComponent<SpriteRenderer>().sprite = levelStatesCastleLevel1[3];

            }
            else if (goblinKills == 3)
            {
                level.GetComponent<SpriteRenderer>().sprite = levelStatesCastleLevel1[2];
                
            }
            else if (goblinKills == 2)
            {
                level.GetComponent<SpriteRenderer>().sprite = levelStatesCastleLevel1[1];
            }
            else if (goblinKills == 1)
            {
                level.GetComponent<SpriteRenderer>().sprite = levelStatesCastleLevel1[0];
            }
        }
        if (SceneManager.GetActiveScene().name == "BossLevel")
        {
            if (goblinKills == 6)
            {
                level.GetComponent<SpriteRenderer>().sprite = levelStatesBossLevel[5];

            }
            else if (goblinKills == 5)
            {
                level.GetComponent<SpriteRenderer>().sprite = levelStatesBossLevel[4];

            }
            else if (goblinKills == 4)
            {
                level.GetComponent<SpriteRenderer>().sprite = levelStatesBossLevel[3];

            }
            else if (goblinKills == 3)
            {
                level.GetComponent<SpriteRenderer>().sprite = levelStatesBossLevel[2];

            }
            else if (goblinKills == 2)
            {
                level.GetComponent<SpriteRenderer>().sprite = levelStatesBossLevel[1];
            }
            else if (goblinKills == 1)
            {
                level.GetComponent<SpriteRenderer>().sprite = levelStatesBossLevel[0];
            }

        }
        }
    
}