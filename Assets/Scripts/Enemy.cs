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
    private bool atAlly = false;
    public bool isDead = false;

    private 

    GameObject castle;
    GameObject [] projectile;
    GameObject [] ally;
    public Collider2D myCollider;

    // Start is called before the first frame update
    void Start()
    {
        castle = GameObject.FindGameObjectWithTag("Castle");
        myCollider = gameObject.GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        projectile = GameObject.FindGameObjectsWithTag("Projectile");
        ally = GameObject.FindGameObjectsWithTag("Ally");
    }

    private void Move()
    {
        if (atCastle == false && atAlly == false)
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
            StartCoroutine(AttackCastle());
        } else if (other.gameObject.tag == "Projectile")
        {
            health -= other.GetComponent<ProjectileSpawner>().contactDamage;
            Damaged();
        } else if (other.gameObject.tag == "Ally")
        {
            atAlly = true;
            StartCoroutine(AttackAlly(other));
        }

    }

    private IEnumerator AttackCastle()
    {
        while(true)
        {
            yield return new WaitForSeconds(attackSpeed);
            Castle.health -= damage;
            castle.GetComponent<Castle>().Damaged();
        }
    }
    private IEnumerator AttackAlly(Collider2D collision)
    {
        while(true)
        {
            yield return new WaitForSeconds(attackSpeed);
            if (isDead == false && collision.GetComponent<Ally>().isDead == false && atAlly == true)
            {
                collision.gameObject.GetComponent<Ally>().health -= damage;
                collision.gameObject.GetComponent<Ally>().Damaged();
            } else
            {
                atAlly = false;
            }
            

        }
    }
    public void Damaged()
    {
        if (health <= 0)
        {
            isDead = true;
            myCollider.enabled = false;
            StartCoroutine(Dying());
        }
    }

    IEnumerator Dying()
    {
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        yield return new WaitForSeconds(5f);
        
    }
}
