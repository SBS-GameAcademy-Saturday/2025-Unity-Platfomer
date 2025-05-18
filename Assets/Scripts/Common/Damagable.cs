using UnityEngine;

public class Damagable : MonoBehaviour
{
    // 체력
    [SerializeField] private int _health = 100;
    // 최대 체력
    [SerializeField] private int _maxHealth = 100;

    private bool _isAlive = true;

    public bool IsAlive
    {
        get { return _isAlive; }
        set
        {
            _isAlive = value;
            _animator.SetBool(AnimationStrings.IsAlive, _isAlive);
        }
    }

    Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    // Damage를 받는 함수
    public bool GetHit(int damage)
    {
        _health -= damage;
        if(_health <= 0)
        {
            IsAlive = false;
        }
        return true;
    }

    // Heal를 받는 함수
    public bool Heal(int healAmount)
    {
        _health += healAmount;
        return true;
    }
}
