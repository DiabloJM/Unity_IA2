using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IAController : MonoBehaviour
{
    [Header("Properties and References")]
    public int IALevel;
    public GameController game;

    [HideInInspector]
    public bool unitsInPlayerArea;
    [HideInInspector]
    public bool unitsInEnemyArea;

    [HideInInspector]
    public int playerKnightCount;
    [HideInInspector]
    public int playerArcherCount;
    [HideInInspector]
    public int playerCavalryCount;

    private bool spawningEnemy;
    private int lastUnitSpawn;
    
    private void Awake()
    {
        game = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        IALevel = IAData.Level;
        playerKnightCount = IAData.Knights;
        playerArcherCount = IAData.Archers;
        playerCavalryCount = IAData.Cavalrys;
    }
  
    private void Start()
    {
        if(IALevel < 2)
            IALevel = 1;
        unitsInPlayerArea = false;
        unitsInEnemyArea = false;
        spawningEnemy = false;
    }
    private void Update()
    {
        if (IALevel == 1 && !spawningEnemy)
        {
            spawningEnemy = true;
            StartCoroutine(SpawnRandomEnemy());
        }
        else if(IALevel > 1 && !spawningEnemy)
        {
            spawningEnemy = true;
            StartCoroutine(AdvanceCorutine());
        }
    }

    public void UpdateIA()
    {
        IAData.Level++;
        IAData.Knights = game.knightCount;
        IAData.Archers = game.archerCount;
        IAData.Cavalrys = game.cavalryCount;
    }

    IEnumerator SpawnRandomEnemy()
    {
        int num = Random.Range(1, 4);
        if(num == 1)
        {
            game.EnemySpawnKnight();
            lastUnitSpawn = 1;
        }
        if (num == 2)
        {
            game.EnemySpawnArcher();
            lastUnitSpawn = 2;
        }
        if (num == 3)
        {
            game.EnemySpawnCavalry();
            lastUnitSpawn = 3;
        }
        yield return new WaitForSeconds(4.0f);
        spawningEnemy = false;
    }

    IEnumerator AdvanceCorutine()
    {
        if(unitsInPlayerArea && !spawningEnemy)
        {
            if(lastUnitSpawn == 1)
            {
                game.EnemySpawnArcher();
                lastUnitSpawn = 2;
            }
            else if(lastUnitSpawn == 2)
            {
                int random = Random.Range(1, 3);
                if(random == 1)
                {
                    game.EnemySpawnKnight();
                    lastUnitSpawn = 1;
                }
                else
                {
                    game.EnemySpawnCavalry();
                    lastUnitSpawn = 3;
                }
            }
            else
            {
                game.EnemySpawnArcher();
                lastUnitSpawn = 2;
            }
            spawningEnemy = true;
        }

        else if(unitsInEnemyArea && !spawningEnemy)
        {
            int random = Random.Range(1, 7);
            if(random > 0 && random < 4)
            {
                game.EnemySpawnCavalry();
                lastUnitSpawn = 3;
            }
            else if(random > 3 && random < 6)
            {
                game.EnemySpawnArcher();
                lastUnitSpawn = 2;
            }
            else
            {
                game.EnemySpawnKnight();
                lastUnitSpawn = 1;
            }
            spawningEnemy = true;
        }

        else if(!spawningEnemy)
        {
            int randomAction = Random.Range(1, 3);

            if(randomAction == 1)
            {
                if (playerKnightCount >= playerArcherCount && playerKnightCount >= playerCavalryCount)
                {
                    int randomUnit = Random.Range(1, 3);
                    if(randomUnit == 1)
                    {
                        game.EnemySpawnArcher();
                        lastUnitSpawn = 2;
                    }
                    else
                    {
                        game.EnemySpawnCavalry();
                        lastUnitSpawn = 3;
                    }
                }
                else if (playerArcherCount >= playerKnightCount && playerArcherCount >= playerCavalryCount)
                {
                    int randomUnit = Random.Range(1, 3);
                    if (randomUnit == 1)
                    {
                        game.EnemySpawnKnight();
                        lastUnitSpawn = 1;
                    }
                    else
                    {
                        game.EnemySpawnCavalry();
                        lastUnitSpawn = 3;
                    }
                }
                else
                {
                    int randomUnit = Random.Range(1, 3);
                    if (randomUnit == 1)
                    {
                        game.EnemySpawnKnight();
                        lastUnitSpawn = 1;
                    }
                    else
                    {
                        game.EnemySpawnArcher();
                        lastUnitSpawn = 2;
                    }
                }
            }

            else
            {
                if(!game.eKnightHealthUpgrade)
                {
                    game.EnemyUpdateKnightHealth();
                }
                else if(!game.eArcherDamageUpgrade)
                {
                    game.EnemyUpdateArcherDamage();
                }
                else if(!game.eCavalryHealthUpgrade)
                {
                    game.EnemyUpdateCavalryHealth();
                }
                else if(!game.eKnightDamageUpgrade)
                {
                    game.EnemyUpdateKnightDamage();
                }
                else if(!game.eArcherHealthUpgrade)
                {
                    game.EnemyUpdateArcherHealth();
                }
                else
                {
                    game.EnemyUpdateCavalryDamage();
                }
            }
        }

        yield return new WaitForSeconds(4.0f);
        spawningEnemy = false;
    }
}
