using System.Collections.Generic;
using UnityEngine;

public class AttackBoxZone : MonoBehaviour
{
    public List<Collider2D> detectionColliders = new List<Collider2D>();

    private void OnTriggerEnter2D(Collider2D collision)
    {
        detectionColliders.Add(collision);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        detectionColliders.Remove(collision);
    }
}
