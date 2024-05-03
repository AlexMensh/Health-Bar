using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthChanger : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _healthBarText;
    [SerializeField] private Slider _healthBarSlider;
    [SerializeField] private Slider _healthBarSliderSmooth;

    [SerializeField] private float _health;
    [SerializeField] private float _maxHealth;
    [SerializeField] private float _minHealt;
    [SerializeField] private float _healAmount;
    [SerializeField] private float _damage;
    [SerializeField] private float _changingDelay;

    private void Start()
    {
        DrawUI();
    }

    public void RestoreHealth()
    {
        if (_health < _maxHealth)
        {
            _health += _healAmount;

            if (_health > _maxHealth)
                _health = _maxHealth;
        }
        DrawUI();
    }

    public void TakeDamage()
    {
        _health -= _damage;

        if (_health <= 0)
            _health = _minHealt;

        DrawUI();
    }

    private void DrawUI()
    {
        _healthBarText.text = $"{_health}/{_maxHealth}";
        _healthBarSlider.value = _health / _maxHealth;

        StartCoroutine(SmoothHealthBarDraw());
    }

    private IEnumerator SmoothHealthBarDraw()
    {
        float timeStart = 0f;
        float timerEnd = 1f;

        while (timeStart < timerEnd)
        {
            timeStart += Time.deltaTime;
            _healthBarSliderSmooth.value = Mathf.MoveTowards(_healthBarSliderSmooth.value, _health / _maxHealth, Time.deltaTime * _changingDelay);
            yield return null;
        }
    }
}