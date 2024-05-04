using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Player))]
public class UIDrawer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _healthBarText;
    [SerializeField] private Slider _healthBarSlider;
    [SerializeField] private Slider _healthBarSliderSmooth;
    [SerializeField] private float _changingDelay;

    private Player _player;

    private void Awake()
    {
        _player = GetComponent<Player>();
    }

    private void OnEnable()
    {
        _player.OnHealthChanged += DrawUI;
    }

    private void OnDisable()
    {
        _player.OnHealthChanged -= DrawUI;
    }

    public void DrawUI(float health, float maxHealth)
    {
        _healthBarText.text = $"{health}/{maxHealth}";
        _healthBarSlider.value = health / maxHealth;

        StartCoroutine(SmoothHealthBarDraw(health, maxHealth));
    }

    private IEnumerator SmoothHealthBarDraw(float health, float maxHealth)
    {
        float timeStart = 0f;
        float timerEnd = 1f;

        while (timeStart < timerEnd)
        {
            timeStart += Time.deltaTime;
            _healthBarSliderSmooth.value = Mathf.MoveTowards(_healthBarSliderSmooth.value, health / maxHealth, Time.deltaTime * _changingDelay);
            yield return null;
        }
    }
}