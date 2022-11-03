using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State
{
    public string name;
    protected EnemyBase enemy;

    public virtual void Initialize(GameObject _enemy, EnemyAnim_Base anim)
    {
        enemy = _enemy.GetComponent<EnemyBase>();
    }
    public abstract void FixedUpdate();
    public abstract void Exit();
}
