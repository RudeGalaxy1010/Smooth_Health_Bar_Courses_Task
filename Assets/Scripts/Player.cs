using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    public UnityAction<float> OnHealthRatioChanged;

    [SerializeField] private float _maxHealth;

    private float _health;

    private void Start()
    {
        _health = _maxHealth;
    }

    public void TakeDamage(int value)
    {
        _health = Mathf.Clamp(_health - value, 0, _maxHealth);
        OnHealthRatioChanged?.Invoke(_health / _maxHealth);
    }
}
