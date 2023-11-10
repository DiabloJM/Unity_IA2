using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAreaController : MonoBehaviour
{
    [Header("Unit to Send")]
    public EnemyUnitController unit;

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.tag == "PlayerUnit" || other.tag == "PlayerTower")
        {
            unit.isWalking = false;
            unit.isAttacking = true;
            unit.animator.SetBool("EnemyTrigger", true);
            unit.rb.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezeRotation;

            if (other.tag == "PlayerUnit")
                unit.enemy = other.GetComponent<PlayerUnitController>();
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
