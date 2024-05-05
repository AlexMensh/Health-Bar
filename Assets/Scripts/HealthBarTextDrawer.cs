using TMPro;
using UnityEngine;

[RequireComponent(typeof(Player))]
public class HealthBarTextDrawer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _healthBarText;
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
        _healthBarText.text = $"{health}/{maxHealth}";
    }
}
