using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ally : MonoBehaviour
{
    public float health = 10;
    public float speed = 10;
    public float attackSpeed = 1;
    public float damage = 10;
    private bool atEnemy = false;
    public bool isDead = false;

    GameObject [] enemy;
    public Collider2D myCollider;

    private void Start()
    {
        myCollider = gameObject.GetComponent<Collider2D>();
    }

    private void Update()
    {
        Move();
        enemy = GameObject.FindGameObjectsWithTag("Enemy");
    }
    

    private void Move()
    {
        if (atEnemy == false)
        {
            transform.position += Vector3.right * speed * Time.deltaTime;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            atEnemy = true;
            StartCoroutine(Attack(collision));
        }
    }

    private IEnumerator Attack(Collider2D collision)
    {
        while(true)
        {
            yield return new WaitForSeconds(attackSpeed);
            if (collision.gameObject.GetComponent<Enemy>().isDead == false && isDead == false && atEnemy == true)
            {
                collision.gameObject.GetComponent<Enemy>().health -= damage;
                collision.gameObject.GetComponent<Enemy>().Damaged();
                Debug.Log("attacked");
            } else
            {
                atEnemy = false;
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
