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
        _player.OnHealthRatioChanged += UpdateTargetValue;
        UpdateTargetValue(1);
    }

    private void OnDestroy()
    {
        _player.OnHealthRatioChanged -= UpdateTargetValue;
    }

    private void Update()
    {
        if (_image.fillAmount != _targetValue)
        {
            _image.fillAmount = Mathf.MoveTowards(_image.fillAmount, _targetValue, _updateSpeed * Time.deltaTime);
        }
    }

    private void UpdateTargetValue(float value)
    {
        _targetValue = value;
    }
}
