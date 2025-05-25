using UnityEngine;

public class Projectile : MonoBehaviour
{
    // 데미지
    public int attackDamage = 10;

    // 이동속도
    public float moveSpeed = 6;

    // Knockback
    public Vector2 knockback;

    public float lifeTime = 5;

    Rigidbody2D _rd;

    private float timer = 0;

    private void Awake()
    {
        _rd = GetComponent<Rigidbody2D>();
    }

    public void StartMove(Vector2 moveDirection)
    {
        timer = 0;
        _rd.linearVelocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y);
    }

    private void Update()
    {
        timer += Time.deltaTime;
        if (timer > lifeTime)
        {
            gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Damagable damagable = collision.GetComponent<Damagable>();
        if (damagable != null)
        {
            Vector2 deliverdKnockback = transform.localScale.x > 0 ?
                knockback : new Vector2(-knockback.x, knockback.y);

            if (damagable.GetHit(attackDamage, deliverdKnockback))
            {
                gameObject.SetActive(false);
            }
        }
    }
}
