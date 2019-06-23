using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectiles : MonoBehaviour
{
    public float contactDamage = 10f;
    public float hitTime = 1f;

    public Transform launchFromPoint;
    public Transform target;
    public GameObject projectile;

    private void Start()
    {
        Launch();
    }

    void Launch()
    {
        float xdist;
        float ydist;

        xdist = target.position.x - launchFromPoint.position.x;
        ydist = target.position.y - launchFromPoint.position.y;

        float launchAngle;

        launchAngle = Mathf.Atan((ydist + 4.905f) / xdist);

        float totalVelo = xdist / Mathf.Cos(launchAngle);

        float xVelo, yVelo;
        xVelo = totalVelo * Mathf.Cos(launchAngle);
        yVelo = totalVelo * Mathf.Sin(launchAngle);

        GameObject projectileInst = Instantiate(projectile, launchFromPoint.position, Quaternion.Euler(new Vector3(0, 0, 0))) as GameObject;
        Rigidbody2D rigid;
        rigid = projectileInst.GetComponent<Rigidbody2D>();

        rigid.velocity = new Vector2(xVelo, yVelo);
    }
}
