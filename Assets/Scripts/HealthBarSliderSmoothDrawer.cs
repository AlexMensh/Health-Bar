using System.Collections;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Health))]
public class HealthBarSliderSmoothDrawer : HealthBar
{
    [SerializeField] private Slider _healthBarSliderSmooth;
    [SerializeField] private float _changingDelay;

    public override void DrawUI(float health, float maxHealth)
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
