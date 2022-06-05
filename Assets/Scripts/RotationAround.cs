using UnityEngine;

public class RotationAround : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private Vector3 _positionOffset;
    [SerializeField] private Vector3 _rotationOffset;
    [SerializeField] private float _speed;

    private void Start()
    {
        transform.position = _target.position + _positionOffset;
        transform.rotation = Quaternion.Euler(_rotationOffset);
    }

    private void Update()
    {
        transform.RotateAround(_target.position, Vector3.up, _speed * Time.deltaTime);
    }
}
