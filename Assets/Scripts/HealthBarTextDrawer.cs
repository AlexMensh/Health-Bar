using TMPro;
using UnityEngine;

[RequireComponent(typeof(Health))]
public class HealthBarTextDrawer : HealthBar
{
    [SerializeField] private TextMeshProUGUI _healthBarText;

    public override void DrawUI(float health, float maxHealth)
    {
        _healthBarText.text = $"{health}/{maxHealth}";
    }
}
