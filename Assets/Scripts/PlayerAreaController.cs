using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAreaController : MonoBehaviour
{
    [Header("Unit to Send")]
    public PlayerUnitController unit;

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.tag == "EnemyUnit" || other.tag == "EnemyTower")
        {
            unit.isWalking = false;
            unit.isAttacking = true;
            unit.animator.SetBool("EnemyTrigger", true);
            unit.rb.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezeRotation;

            if (other.tag == "EnemyUnit")
                unit.enemy = other.GetComponent<EnemyUnitController>();
            else
                unit.isAttackingTower = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        unit.isWalking = true;
        unit.isAttacking = false;
        unit.isAttackingTower = false;
        unit.animator.SetBool("EnemyTrigger", false);
        unit.rb.constraints = RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezeRotation;
    }
}
