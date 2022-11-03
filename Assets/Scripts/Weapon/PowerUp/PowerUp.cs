using UnityEngine;

public abstract class PowerUp : ScriptableObject
{
    public abstract void Start();
    public abstract void Apply(GameObject target);
}
