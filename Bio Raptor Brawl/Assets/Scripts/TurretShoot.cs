using UnityEngine;
using System.Collections;
using System;

public class TurretShoot : MonoBehaviour
{
    public GameObject shotRef;
    public float timeLeft;
    public float fireRate = 5f;
    public int damage;
    public float range;
    public int cost;
    public float nextFire = 0f;


    void Update()
    {

    }
    public void Start()
    {
        range = this.gameObject.GetComponent<BoxCollider2D>().size.x;
    }

    public void Die()
    {
        if (timeLeft <= 0)
        {
            Destroy(this, 0.2f);
        }
    }

    public void Fire(Collider2D other)
    {
        if (Time.time > nextFire && other.tag == "Enemy")
        {
            nextFire = Time.time + fireRate;
            var shot = Instantiate(shotRef, transform.position, Quaternion.FromToRotation(transform.position, other.transform.position)) as GameObject;
            shot.GetComponent<TurretBullet>().FindTargetTransform = other.transform;
        }
    }

    public void Ability()
    {

    }

    void OnTriggerStay2D(Collider2D other)
    {
        Fire(other);
    }

}
