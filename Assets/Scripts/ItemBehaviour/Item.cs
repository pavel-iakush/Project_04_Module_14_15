using UnityEngine;

public abstract class Item : MonoBehaviour
{
    public abstract bool CanUse(GameObject owner);

    public abstract void Use(GameObject owner);

    public abstract void Remove();
}