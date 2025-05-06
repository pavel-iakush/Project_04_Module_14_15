using UnityEngine;

public class Example : MonoBehaviour
{
}

public class ProjectileEx : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbodyEx;
    [SerializeField] private ParticleSystem _launchEffectEx;

    public void LaunchEx(Vector3 directionEx)
    {
        _launchEffectEx.Play();
        transform.rotation = Quaternion.LookRotation(directionEx);
        _rigidbodyEx.AddForce(directionEx);
    }
}

public class ItemShootEx : ItemEx
{
    [SerializeField] private ProjectileEx _projectilePrefabEx;
    [SerializeField] private float _shootForceEx;

    public override bool CanUse(GameObject ownerEx)
    {
        return ownerEx.GetComponentInChildren<ProjectileSlotEx>() != null;
    }

    public override void Use(GameObject ownerEx)
    {
        ProjectileSlotEx projectileSlotEx = ownerEx.GetComponentInChildren<ProjectileSlotEx>();

        ProjectileEx projectileEx = Instantiate(_projectilePrefabEx, projectileSlotEx.transform.position, Quaternion.identity, null);
        projectileEx.LaunchEx(Vector3.forward * _shootForceEx);
    }
}

public class ItemHealEx : ItemEx
{
    [SerializeField] private float _healAmountEx;

    public override bool CanUse(GameObject ownerEx)
    {
        return ownerEx.GetComponent<HealthPointsEx>() != null;
    }

    public override void Use(GameObject ownerEx)
    {
        ownerEx.GetComponent<HealthPointsEx>().ValueEx += _healAmountEx;
    }
}

public abstract class ItemEx : MonoBehaviour
{
    public abstract bool CanUse(GameObject ownerEx);

    public abstract void Use(GameObject ownerEx);
}

public class ProjectileSlotEx : MonoBehaviour
{

}

public class HealthPointsEx : MonoBehaviour
{
    private float _valueEx;

    public float ValueEx
    {
        get
        {
            return _valueEx;
        }
        set
        {
            if (value < 0)
            {
                Debug.Log("Negative health");
                return;
            }
            
            _valueEx = value;
        }
    }
}

public class ItemCollectorEx : MonoBehaviour
{
    private ItemEx _itemEx;

    [SerializeField] private Transform _armSlotEx;
    [SerializeField] private GameObject _ownerEx;

    private void OnTriggerEnter(Collider otherEx)
    {
        if (_itemEx == null)
            return;

        ItemEx itemEx = otherEx.GetComponent<ItemEx>();

        if (itemEx != null)
        {
            if (itemEx.CanUse(_ownerEx) == false)
            {
                Debug.Log("You are not able to use this item");
                return;
            }

            _itemEx = itemEx;
            _itemEx.transform.SetParent(_armSlotEx);
            _itemEx.transform.localPosition = Vector3.zero;
        }
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.F))
        {
            _itemEx.Use(_ownerEx);
            //play particle effect
            Destroy(_itemEx.gameObject);
            _itemEx = null;
        }
    }
}