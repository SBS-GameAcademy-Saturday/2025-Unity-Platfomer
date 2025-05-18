using UnityEngine;

public class Attack : MonoBehaviour
{
    [SerializeField] private int attackDamage = 10;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Damagable damagable = collision.GetComponent<Damagable>();
        if(damagable is not null)
        {
            damagable.GetHit(attackDamage);
        }
    }
}
