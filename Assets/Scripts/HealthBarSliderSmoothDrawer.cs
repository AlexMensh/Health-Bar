using System.Collections;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Player))]
public class HealthBarSliderSmoothDrawer : MonoBehaviour
{
    [SerializeField] private Slider _healthBarSliderSmooth;
    [SerializeField] private float _changingDelay;
    private Player _player;

    private void Awake()
    {
        _player = GetComponent<Player>();
    }
    private void OnEnable()
    {
        _player.HealthChanged += DrawUI;
    }

    private void OnDisable()
    {
        _player.HealthChanged -= DrawUI;
    }

    public void DrawUI(float health, float maxHealth)
    {
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
