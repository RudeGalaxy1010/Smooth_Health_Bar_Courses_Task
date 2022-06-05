using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class HealthBar : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private float _updateSpeed;

    private Image _image;
    private float _targetValue;

    private void Start()
    {
        _image = GetComponent<Image>();
        OnHealthRatioChanged(1);
    }

    private void OnEnable()
    {
        _player.HealthRatioChanged += OnHealthRatioChanged;
    }

    private void OnDisable()
    {
        _player.HealthRatioChanged -= OnHealthRatioChanged;
    }

    private void Update()
    {
        _image.fillAmount = Mathf.MoveTowards(_image.fillAmount, _targetValue, _updateSpeed * Time.deltaTime);
    }

    private void OnHealthRatioChanged(float value)
    {
        _targetValue = value;
    }
}
