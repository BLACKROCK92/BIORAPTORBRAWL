using UnityEngine;
using System.Collections;
using System;

public class Turret : MonoBehaviour
{
    public GameObject BulletRef;
    public float timeLeft;
    public float fireRate;
    public int damage;
    public float range;
    public int cost;
    float nextFire = 0f;


    void Update()
    {

    }
    public void Start()
    {
        range = gameObject.GetComponent<BoxCollider2D>().size.x;
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
            GameObject shot = Instantiate(BulletRef, transform.position, Quaternion.identity) as GameObject;
            shot.GetComponent<TurretBullet>().FindTargetTransform = other.transform;
            print("Turret Shooting!");
            print(other.name);
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
