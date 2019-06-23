using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Castle : MonoBehaviour
{
    public static float health = 100;
    public static float maxHealth = 100;
    public bool isDead = false;
    public static float healthNormalized = health / maxHealth;

    [SerializeField] private HealthBar healthBar;
    // Start is called before the first frame update
    void Start()
    {
        // healthBar.SetSize(healthNormalized);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Damaged()
    {
        healthNormalized = health / maxHealth;
        healthBar.SetSize(healthNormalized);
        if (health <= 0)
        {
            Destroy(gameObject);
        }
        return;
    }

}