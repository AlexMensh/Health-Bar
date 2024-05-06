using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Health))]
public class HelathBarSliderDrawer : HealthBar
{
    [SerializeField] private Slider _healthBarSlider;

    public override void DrawUI(float health, float maxHealth)
    {
        _healthBarSlider.value = health / maxHealth;
    }
}
