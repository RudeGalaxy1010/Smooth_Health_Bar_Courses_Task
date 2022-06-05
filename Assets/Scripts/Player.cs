using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    public UnityAction<float> HealthRatioChanged;

    [SerializeField] private float _maxHealth;

    private float _health;

    private void Start()
    {
        _health = _maxHealth;
    }

    public void TakeDamage(int value)
    {
        if (value <= 0)
        {
            return;
        }

        _health = Mathf.Clamp(_health - value, 0, _maxHealth);
        HealthRatioChanged?.Invoke(_health / _maxHealth);
    }

    public void TakeHeal(int value)
    {
        if (value <= 0)
        {
            return;
        }

        _health = Mathf.Clamp(_health + value, 0, _maxHealth);
        HealthRatioChanged?.Invoke(_health / _maxHealth);
    }
}
