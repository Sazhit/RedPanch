using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float _maxHealth;
    [SerializeField] private float _currentHeath;
   
    [SerializeField] private float _lifeReductionTime;
    [SerializeField] private HealthBar _healthBar;

    [SerializeField] private PlayerDied _playerDied;
    [SerializeField] private Ultimate _ultimate;

    private PlayerControl _playerControl;

    public float MaxHealth { get => _maxHealth; set => _maxHealth = value; }
    public float CurrentHeath { get => _currentHeath; set => _currentHeath = value; }

    private void Start()
    {
        _playerControl = gameObject.GetComponent<PlayerControl>();
        _currentHeath = _maxHealth;
        _healthBar.SetMaxHealth(_maxHealth);
    }

    private void Update()
    {
        _healthBar.SetHealth(_currentHeath);
        _currentHeath -= 1 / _lifeReductionTime * Time.deltaTime;
        CurrentAmountOfLife();
    }

    public void ApplyDamage(float damage)
    {
        CurrentIsCooldawn(damage);
        CurrentMaxHealt();
    }

    private void CurrentAmountOfLife()
    {
        if (_currentHeath <= 0)
        {
            _playerDied.Death();
        }
    }

    private void CurrentIsCooldawn(float damage)
    {
        if (_playerControl.CheckUltimate == true)
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
