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
    public bool GetHit(int damage, Vector2 knockback)
    {
        if(IsAlive)
        {
            _health -= damage;

            // Velocity 이동 로직에 따른 velocity 연산을 막도록 한다.
            // SetBoolBehaviour는 애니메이션이 전환 될때 실행되기 때문에
            // 데이지를 입는 순간부터 멈춰야 한다.
            _animator.SetBool(AnimationStrings.LockVelocity, true);

            // Hit 트리거
            _animator.SetTrigger(AnimationStrings.Hit);

            if (_health <= 0)
            {
                IsAlive = false;
            }
            return true;
        }
        return false;
    }

    // Heal를 받는 함수
    public bool Heal(int healAmount)
    {
        _health += healAmount;
        return true;
    }
}
