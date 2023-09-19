using UnityEngine;

public abstract class PowerUp : ScriptableObject
{
    public abstract void Awake();
    public abstract void Apply(GameObject target);
}
