using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyArea : MonoBehaviour
{
    public IAController IA;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "PlayerUnit")
        {
            IA.unitsInEnemyArea = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "PlayerUnit")
        {
            IA.unitsInEnemyArea = false;
        }
    }
}
