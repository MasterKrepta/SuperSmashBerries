using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    Animator anim;
    bool canAttack = true;
    public float attackDelay = .5f;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && canAttack){
        {
                anim.SetTrigger("Attack");
                StartCoroutine(ToggleAttack());
        }
    }
}

    private IEnumerator ToggleAttack()
    {
        canAttack = false;
        yield return new WaitForSeconds(attackDelay);
        canAttack = true;
    }
}
