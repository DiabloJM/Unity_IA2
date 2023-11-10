using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyUnitController : MonoBehaviour
{
    [Header("Game Controller")]
    public GameController game;

    [Header("Attributes")]
    public int health;
    public int damage;
    public float recoil;
    public float speed;
    public int value;

    [HideInInspector]
    public PlayerUnitController enemy;
    [HideInInspector]
    public Animator animator;
    [HideInInspector]
    public bool isWalking;
    [HideInInspector]
    public bool isAttacking;
    [HideInInspector]
    public bool isAttackingTower;
    [HideInInspector]
    public Rigidbody2D rb;

    private bool isAlive;
    private bool isRecoilTime;

    private Vector2 direction;

    private void Awake()
    {
        game = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        animator = gameObject.GetComponent<Animator>();
        rb = gameObject.GetComponent<Rigidbody2D>();
        direction = new Vector2(-1.0f, 0.0f);
    }

    private void Start()
    {
        isWalking = true;
        isAttacking = false;
        isAttackingTower = false;
        isAlive = true;
        isRecoilTime = false;
    }

    private void Update()
    {
        if (health <= 0 && isAlive)
            StartCoroutine(DeadCoroutine());

        if (isAttacking && !isRecoilTime && isAlive)
        {
            if (isAttackingTower)
                StartCoroutine(AttackTowerCoroutine());
            else
                StartCoroutine(AttackCoroutine());
        }
    }

    private void FixedUpdate()
    {
        if (isWalking)
            rb.velocity = direction * speed;
    }

    public void TakeDamage(int enemyDamage)
    {
        health -= enemyDamage;
    }

    //Agregar monedas visuales
    IEnumerator DeadCoroutine()
    {
        isAlive = false;
        isWalking = false;
        animator.SetBool("IsDead", true);
        game.playerCoins += value;
        game.playerCoinsText.text = game.playerCoins.ToString();
        yield return new WaitForSeconds(1);
        Destroy(gameObject);
    }

    IEnumerator AttackCoroutine()
    {
        enemy.TakeDamage(damage);
        isRecoilTime = true;
        yield return new WaitForSeconds(recoil);
        isRecoilTime = false;
    }

    IEnumerator AttackTowerCoroutine()
    {
        game.PlayerDamage(damage);
        isRecoilTime = true;
        yield return new WaitForSeconds(recoil);
        isRecoilTime = false;
    }
}
