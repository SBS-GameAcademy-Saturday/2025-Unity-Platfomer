using UnityEngine;
using UnityEngine.UI;

public class HPBar : MonoBehaviour
{
    [SerializeField] private Slider hpBar;
    [SerializeField] private Damagable damagable;

    private void Start()
    {
        damagable.OnHealthChange.AddListener(OnHealthChanged);

    }

    private void OnHealthChanged(int currentHealth, int maxHealth)
    {
        float value = (float)currentHealth / maxHealth;
        hpBar.value = value;
    }
}
