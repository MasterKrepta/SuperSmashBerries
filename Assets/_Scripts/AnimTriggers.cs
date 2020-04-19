using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimTriggers : MonoBehaviour
{
    public GameObject Projectile;
    public Transform throwPoint;
    public float moveSpeed = 30f;
    public float throwDelay = 0.75f;
    bool canThrow = true;

    public void AttackToggle()
    {
        foreach (var attackPoint in this.GetComponentsInChildren<DamageDealer>())
        {
            var col = attackPoint.GetComponent<Collider>();
            col.enabled = !col.enabled;
            //attackPoint.enabled = !attackPoint.enabled;
        }
    }

    public void Throw()
    {
        if (canThrow)
        {
            GameObject go = Instantiate(Projectile, throwPoint.position, Quaternion.identity);
            Rigidbody rb = go.GetComponent<Rigidbody>();
            rb.AddForce(throwPoint.forward * moveSpeed, ForceMode.Impulse);
            ThrowDelay();
        }
        
    }


    IEnumerator ThrowDelay()
    {
        yield return new WaitForSeconds(throwDelay);
        canThrow = true;

    }
}
