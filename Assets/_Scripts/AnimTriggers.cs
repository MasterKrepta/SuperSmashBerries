using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimTriggers : MonoBehaviour
{
    
  public void AttackToggle()
    {
        foreach (var attackPoint in this.GetComponentsInChildren<DamageDealer>())
        {
            var col = attackPoint.GetComponent<Collider>();
            col.enabled = !col.enabled;
            //attackPoint.enabled = !attackPoint.enabled;
        }
    }
}
