using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float _maxHealth;
    [SerializeField] private float _currentHeath;
   
    [SerializeField] private float _lifeReductionTime;
    [SerializeField] private HealthBar _healthBar;

    [SerializeField] private Ultimate _ultimate;

    public float MaxHealth { get => _maxHealth; set => _maxHealth = value; }

    private void Start()
    {
        _currentHeath = _maxHealth;
        _healthBar.SetMaxHealth(_maxHealth);
    }

    private void Update()
    {
        _healthBar.SetHealth(_currentHeath);
        _currentHeath -= 1 / _lifeReductionTime * Time.deltaTime;
    }

    public void ApplyDamage(float damage)
    {
        CurrentIsCooldawn(damage);

        CurrentMaxHealt();
    }

    private void CurrentIsCooldawn(float damage)
    {
        if (_ultimate.IsCooldown == false)
        {
            _healthBar.SetHealth(_currentHeath -= damage);
        }
    }

    private void CurrentMaxHealt()
    {
        if (_currentHeath >= _maxHealth)
        {
            _currentHeath = _maxHealth;
        }
    }
}
