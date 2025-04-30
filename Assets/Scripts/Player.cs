using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Mover _mover;
    [SerializeField] private Rotator _rotator;
    [SerializeField] private HealthPoints _healthPoints;
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _rotateSpeed;
    [SerializeField] private int _health;

    private string _xAxisName = "Horizontal";
    private string _zAxisName = "Vertical";
    private float _deadZone = 0.1f;
    private Quaternion _startRotation = Quaternion.Euler(0, 180, 0);

    public Quaternion StartRotation => _startRotation;

    private void Awake()
    {
        transform.rotation = _startRotation;

        _mover.Initialize(_moveSpeed);
        _rotator.Initialize(_rotateSpeed);
        _healthPoints.Initialize(_health);
    }

    private void Update()
    {
        Vector3 input = new Vector3(Input.GetAxisRaw(_xAxisName), 0, Input.GetAxisRaw(_zAxisName));

        if (input.magnitude <= _deadZone)
        {
            return;
        }
        else
        {
            Vector3 NormalizedInput = input.normalized;

            _mover.ProcessMoveTo(NormalizedInput);
            _rotator.ProcessRotateTo(NormalizedInput);
        }
    }
}
