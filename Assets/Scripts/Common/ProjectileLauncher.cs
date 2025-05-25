using UnityEngine;

public class ProjectileLauncher : MonoBehaviour
{
    // 화살 프리팹 오브젝트
    [SerializeField] private GameObject projectilePrefab;
    // 프리팹 생성 위치
    [SerializeField] private Transform lauchPoint;

    [SerializeField] private Pooling pooling;

    public void FireProjectile()
    {
        GameObject projectile = pooling.GetPooledObject();
        projectile.transform.position = lauchPoint.position;

        // 생성된 오브젝트의 방향을 설정한다.
        Vector3 originScale = projectile.transform.localScale;

        if (originScale.x < 0 && transform.localScale.x > 0)
        {
            Vector3 newScale = new Vector3(originScale.x * -1, originScale.y * -1, originScale.z);
            projectile.transform.localScale = newScale;
        }
        else if(originScale.x > 0 && transform.localScale.x < 0)
        {
            Vector3 newScale = new Vector3(originScale.x * -1, originScale.y * -1, originScale.z);
            projectile.transform.localScale = newScale;
        }

        Vector2 moveDirection = transform.localScale.x > 0 ? Vector2.right : Vector2.left;
        projectile.GetComponent<Projectile>().StartMove(moveDirection);

    }
}
