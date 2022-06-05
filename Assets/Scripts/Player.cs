using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    private const float MinHealth = 0;
    private const float MaxHealth = 100;

    private float _health;

    public UnityAction<float> HealthRatioChanged;

    private void Start()
    {
        _health = MaxHealth;
    }

    public void TakeDamage(int value)
    {
        if (value <= 0)
        {
            return;
        }

        _health = Mathf.Clamp(_health - value, MinHealth, MaxHealth);
        HealthRatioChanged?.Invoke(_health / MaxHealth);
    }

    public void TakeHeal(int value)
    {
        if (value <= 0)
        {
            return;
        }

        _health = Mathf.Clamp(_health + value, MinHealth, MaxHealth);
        HealthRatioChanged?.Invoke(_health / MaxHealth);
    }
}
