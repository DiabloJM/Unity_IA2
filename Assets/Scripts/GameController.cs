using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    [Header("IA")]
    public IAController IA;

    [Header("UI Components")]
    public Text playerLifeText;
    public Text playerCoinsText;
    public Text enemyLifeText;

    [Header("Spawn Points")]
    public GameObject playerSpawn;
    public GameObject enemySpawn;

    [Header("Player Prefabs")]
    public GameObject playerKnight;
    public GameObject playerArcher;
    public GameObject playerCavalry;

    [Header("Enemy Prefabs")]
    public GameObject enemyKnight;
    public GameObject enemyArcher;
    public GameObject enemyCavalry;

    [Header("Canvas")]
    public GameObject victoryCanvas;
    public GameObject defeatCanvas;

    [Header("Upgrades Prices")]
    public GameObject knightHealthPrice;
    public GameObject knightDamagePrice;
    public GameObject archerHealthPrice;
    public GameObject archerDamagePrice;
    public GameObject cavalryHealthPrice;
    public GameObject cavalryDamagePrice;

    [HideInInspector]
    public int playerCoins;
    [HideInInspector]
    public int enemyCoins;
    [HideInInspector]
    public int playerLife;
    [HideInInspector]
    public int enemyLife;

    [HideInInspector]
    public int knightCount;
    public int archerCount;
    public int cavalryCount;

    //Player Unit stats
    private int pKnightHealth;
    private int pKnightDamage;
    private int pArcherHealth;
    private int pArcherDamage;
    private int pCavalryHealth;
    private int pCavalryDamage;
    //Player Unit Upgrades
    private bool pKnightHealthUpgrade;
    private bool pKnightDamageUpgrade;
    private bool pArcherHealthUpgrade;
    private bool pArcherDamageUpgrade;
    private bool pCavalryHealthUpgrade;
    private bool pCavalryDamageUpgrade;
    //Enemy Unit stats
    private int eKnightHealth;
    private int eKnightDamage;
    private int eArcherHealth;
    private int eArcherDamage;
    private int eCavalryHealth;
    private int eCavalryDamage;
    //Enemy Unit Upgrades
    [HideInInspector]
    public bool eKnightHealthUpgrade;
    [HideInInspector]
    public bool eKnightDamageUpgrade;
    [HideInInspector]
    public bool eArcherHealthUpgrade;
    [HideInInspector]
    public bool eArcherDamageUpgrade;
    [HideInInspector]
    public bool eCavalryHealthUpgrade;
    [HideInInspector]
    public bool eCavalryDamageUpgrade;

    private void Start()
    {
        playerCoins = 200;
        enemyCoins = 200;    
        playerLife = 200;
        enemyLife = 200;

        knightCount = 0;
        archerCount = 0;
        cavalryCount = 0;

        pKnightHealth = 30;
        pKnightDamage = 20;
        pArcherHealth = 15;
        pArcherDamage = 5;
        pCavalryHealth = 45;
        pCavalryDamage = 20;

        pKnightHealthUpgrade = false;
        pKnightDamageUpgrade = false;
        pArcherHealthUpgrade = false;
        pArcherDamageUpgrade = false;
        pCavalryHealthUpgrade = false;
        pCavalryDamageUpgrade = false;

        eKnightHealth = 30;
        eKnightDamage = 10;
        eArcherHealth = 15;
        eArcherDamage = 5;
        eCavalryHealth = 45;
        eCavalryDamage = 20;

        eKnightHealthUpgrade = false;
        eKnightDamageUpgrade = false;
        eArcherHealthUpgrade = false;
        eArcherDamageUpgrade = false;
        eCavalryHealthUpgrade = false;
        eCavalryDamageUpgrade = false;
    }

    //Damge playe tower
    public void PlayerDamage(int damage)
    {
        playerLife -= damage;

        if (playerLife <= 0)
        {
            playerLifeText.text = "0";
            Time.timeScale = 0;
            defeatCanvas.gameObject.SetActive(true);
            IA.UpdateIA();
        }
        else
            playerLifeText.text = playerLife.ToString();
    }

    //Damage enemy tower
    public void EnemyDamage(int damage)
    {
        enemyLife -= damage;

        if (enemyLife <= 0)
        {
            enemyLifeText.text = "0";
            Time.timeScale = 0;
            victoryCanvas.gameObject.SetActive(true);
            IA.UpdateIA();
        }
        else
            enemyLifeText.text = enemyLife.ToString();
    }

    public void PlayerSpawnKnight()
    {
        if(playerCoins >= 25)
        {
            GameObject unit = Instantiate(playerKnight, playerSpawn.transform.position, Quaternion.identity);
            unit.GetComponent<PlayerUnitController>().health = pKnightHealth;
            unit.GetComponent<PlayerUnitController>().damage = pKnightDamage;
            playerCoins -= 25;
            knightCount++;
            playerCoinsText.text = playerCoins.ToString();
        }
    }

    public void PlayerSpawnArcher()
    {
        if (playerCoins >= 50)
        {
            GameObject unit = Instantiate(playerArcher, playerSpawn.transform.position, Quaternion.identity);
            unit.GetComponent<PlayerUnitController>().health = pArcherHealth;
            unit.GetComponent<PlayerUnitController>().damage = pArcherDamage;
            playerCoins -= 50;
            archerCount++;
            playerCoinsText.text = playerCoins.ToString();
        }
    }

    public void PlayerSpawnCavalry()
    {
        if (playerCoins >= 100)
        {
            GameObject unit = Instantiate(playerCavalry, playerSpawn.transform.position, Quaternion.identity);
            unit.GetComponent<PlayerUnitController>().health = pCavalryHealth;
            unit.GetComponent<PlayerUnitController>().damage = pCavalryDamage;
            playerCoins -= 100;
            cavalryCount++;
            playerCoinsText.text = playerCoins.ToString();
        }
    }

    public void EnemySpawnKnight()
    {
        if(enemyCoins >= 25)
        {
            GameObject unit = Instantiate(enemyKnight, enemySpawn.transform.position, Quaternion.identity);
            unit.GetComponent<EnemyUnitController>().health = eKnightHealth;
            unit.GetComponent<EnemyUnitController>().damage = eKnightDamage;
            enemyCoins -= 25;
        }
    }

    public void EnemySpawnArcher()
    {
        if (enemyCoins >= 50)
        {
            GameObject unit = Instantiate(enemyArcher, enemySpawn.transform.position, Quaternion.identity);
            unit.GetComponent<EnemyUnitController>().health = eArcherHealth;
            unit.GetComponent<EnemyUnitController>().damage = eArcherDamage;
            enemyCoins -= 50;
        }
    }

    public void EnemySpawnCavalry()
    {
        if (enemyCoins >= 100)
        {
            GameObject unit = Instantiate(enemyCavalry, enemySpawn.transform.position, Quaternion.identity);
            unit.GetComponent<EnemyUnitController>().health = eCavalryHealth;
            unit.GetComponent<EnemyUnitController>().damage = eCavalryDamage;
            enemyCoins -= 100;
        }
    }

    public void PlayerUpdateKnightHealth(GameObject price)
    {
        if(playerCoins >= 80 && !pKnightHealthUpgrade)
        {
            pKnightHealth += 10;
            price.gameObject.SetActive(false);
            playerCoins -= 80;
            pKnightHealthUpgrade = true;
            playerCoinsText.text = playerCoins.ToString();
        }
    }

    public void PlayerUpdateKnightDamage(GameObject price)
    {
        if (playerCoins >= 100 && !pKnightDamageUpgrade)
        {
            pKnightDamage += 5;
            price.gameObject.SetActive(false);
            playerCoins -= 100;
            pKnightDamageUpgrade = true;
            playerCoinsText.text = playerCoins.ToString();
        }
    }

    public void PlayerUpdateArcherHealth(GameObject price)
    {
        if (playerCoins >= 100 && !pArcherHealthUpgrade)
        {
            pArcherHealth += 10;
            price.gameObject.SetActive(false);
            playerCoins -= 100;
            pArcherHealthUpgrade = true;
            playerCoinsText.text = playerCoins.ToString();
        }
    }

    public void PlayerUpdateArcherDamage(GameObject price)
    {
        if (playerCoins >= 120 && !pArcherDamageUpgrade)
        {
            pArcherDamage += 5;
            price.gameObject.SetActive(false);
            playerCoins -= 120;
            pArcherDamageUpgrade = true;
            playerCoinsText.text = playerCoins.ToString();
        }
    }

    public void PlayerUpdateCavalryHealth(GameObject price)
    {
        if (playerCoins >= 150 && !pCavalryHealthUpgrade)
        {
            pCavalryHealth += 10;
            price.gameObject.SetActive(false);
            playerCoins -= 150;
            pCavalryHealthUpgrade = true;
            playerCoinsText.text = playerCoins.ToString();
        }
    }

    public void PlayerUpdateCavalryDamage(GameObject price)
    {
        if (playerCoins >= 200 && !pCavalryDamageUpgrade)
        {
            pCavalryDamage += 5;
            price.gameObject.SetActive(false);
            playerCoins -= 200;
            pCavalryDamageUpgrade = true;
            playerCoinsText.text = playerCoins.ToString();
        }
    }

    public void EnemyUpdateKnightHealth()
    {
        if (enemyCoins >= 80 && !eKnightHealthUpgrade)
        {
            eKnightHealth += 10;
            enemyCoins -= 80;
            eKnightHealthUpgrade = true;
        }
    }

    public void EnemyUpdateKnightDamage()
    {
        if (enemyCoins >= 100 && !eKnightDamageUpgrade)
        {
            eKnightDamage += 5;
            enemyCoins -= 100;
            eKnightDamageUpgrade = true;
        }
    }

    public void EnemyUpdateArcherHealth()
    {
        if (enemyCoins >= 100 && !eArcherHealthUpgrade)
        {
            eKnightHealth += 10;
            enemyCoins -= 100;
            eArcherHealthUpgrade = true;
        }
    }

    public void EnemyUpdateArcherDamage()
    {
        if (enemyCoins >= 120 && !eArcherDamageUpgrade)
        {
            eArcherDamage += 5;
            enemyCoins -= 120;
            eArcherDamageUpgrade = true;
        }
    }

    public void EnemyUpdateCavalryHealth()
    {
        if (enemyCoins >= 150 && !eCavalryHealthUpgrade)
        {
            eCavalryHealth += 10;
            enemyCoins -= 150;
            eCavalryHealthUpgrade = true;
        }
    }

    public void EnemyUpdateCavalryDamage()
    {
        if (enemyCoins >= 200 && !eCavalryDamageUpgrade)
        {
            eCavalryDamage += 5;
            enemyCoins -= 200;
            eCavalryDamageUpgrade = true;
        }
    }
}
