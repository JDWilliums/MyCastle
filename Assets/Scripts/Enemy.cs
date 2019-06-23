using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public float speed = 10;
    public float damage = 10;
    public float attackSpeed = 1;
    public float health = 10;
    private bool atCastle = false;

    GameObject castle;
    GameObject [] projectile;

    // Start is called before the first frame update
    void Start()
    {
        castle = GameObject.FindGameObjectWithTag("Castle");
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        projectile = GameObject.FindGameObjectsWithTag("Projectile");
    }

    private void Move()
    {
        if (atCastle == false)
        {
            // Moves enemy left by speed given at all different frame rates
            transform.position += Vector3.left * speed * Time.deltaTime;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Castle")
        {
            atCastle = true;
            StartCoroutine(Attack());
        } else if (other.gameObject.tag == "Projectile")
        {
            health -= projectile[0].gameObject.GetComponent<ProjectileSpawner>().contactDamage;
            Damaged();
        }

    }

    private IEnumerator Attack()
    {
        while(true)
        {
            yield return new WaitForSeconds(attackSpeed);
            Castle.health -= damage;
            castle.GetComponent<Castle>().Damaged();
            Debug.Log("attacked");
        }
    }
    void Damaged()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
