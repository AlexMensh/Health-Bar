using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Player))]
public class HelathBarSliderDrawer : MonoBehaviour
{
    [SerializeField] private Slider _healthBarSlider;
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
        _healthBarSlider.value = health / maxHealth;
    }
}
