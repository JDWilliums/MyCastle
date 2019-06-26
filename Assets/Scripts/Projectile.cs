using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour
{
    public float damage = 5;
    public float attackSpeed = 1;

    public void OnHit()
    {
        Destroy(gameObject);
    }
}
