using UnityEngine;

public class Attack : MonoBehaviour
{
    [SerializeField] private int attackDamage = 10;
    [SerializeField] private Vector2 knockback = Vector2.zero;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Damagable damagable = collision.GetComponent<Damagable>();
        if(damagable is not null)
        {
            // 캐릭터가 오른쪽을 보고 있으면 오른쪽으로 KnockBack이 설정되고
            // 캐릭터가 왼쪽을 보고 있으면 왼쪽으로 KnockBack이 설정됩니다.
            Vector2 deliverdKnockback = transform.parent.localScale.x > 0 ?
                knockback : new Vector2(-knockback.x, knockback.y);

            damagable.GetHit(attackDamage, deliverdKnockback);
        }
    }
}
