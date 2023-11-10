using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerArea : MonoBehaviour
{
    public IAController IA;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "EnemyUnit")
        {
            IA.unitsInPlayerArea = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "EnemyUnit")
        {
            IA.unitsInPlayerArea = false;
        }
    }
}
