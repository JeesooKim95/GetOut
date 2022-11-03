using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class EnemyAnim_Base : MonoBehaviour
{
    protected Animator anim = null;

    // Start is called before the first frame update
    protected virtual void Start()
    {
        anim = gameObject.GetComponent<Animator>();

        if(gameObject.GetComponent<EnemyBase>() != null)
        {
            anim.SetBool("isWalking", true);
        }
    }

    virtual public void Walk(bool walking)
    {
        if(anim)
        {
            anim.SetBool("isWalking", walking);
        }
    }

    virtual public void Attack()
    {
        if (anim)
        {
            anim.SetTrigger("isAttacking");
        }
    }

    virtual public void Death(bool isDead)
    {
        if (anim)
        {
            anim.SetBool("isDead", isDead);
        }
    }
}
