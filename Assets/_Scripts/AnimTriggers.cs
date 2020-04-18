using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimTriggers : MonoBehaviour
{
    
  public void AttackToggle()
    {
        foreach (var attackPoint in this.GetComponentsInChildren<DamageDealer>())
        {
            attackPoint.enabled = !attackPoint.enabled;
        }
    }
}
