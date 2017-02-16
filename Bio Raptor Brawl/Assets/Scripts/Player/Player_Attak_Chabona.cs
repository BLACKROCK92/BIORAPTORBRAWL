using UnityEngine;
using System.Collections;

public class Player_Attak_Chabona : MonoBehaviour
{

    private bool attacking = false;
    private bool attackingRanged = false;
    private float attackTimer = 0;
    private float attackCd = 0.3f;
    public Collider2D attackTrigger;
    public Animator anim;
    public GameObject bulletPrefab;
    public float nextFire = 1;
    public float fireRate = 0.5f;

    public string attackButton = "Fire1_P1";
    public string attackButton2 = "Fire2_P1";

    void Awake()
    {
        anim = gameObject.GetComponent<Animator>();
        attackTrigger.enabled = false;
    }

    void Update()
    {

        if (Input.GetButtonDown(attackButton) && !attacking)
        {

            attacking = true;
            attackTimer = attackCd;
            attackTrigger.enabled = true;
            if (anim.GetBool("attack_melee") != true)
            {
                anim.SetBool("attack_melee", true);
            }
        }

        if (Input.GetButtonDown(attackButton2) && !attackingRanged)
        {
            attackTimer = attackCd;
            attackingRanged = true;
            Fire();
            if (anim.GetBool("attack_ranged") != true)
            {
                anim.SetBool("attack_ranged", true);
            }
        }

        if (attacking || attackingRanged)
        {
            if (attackTimer > 0)
            {
                attackTimer -= Time.deltaTime;

            }
            else
            {
                attacking = false;
                attackingRanged = false;
                attackTrigger.enabled = false;
                anim.SetBool("attack_melee", false);
                anim.SetBool("attack_ranged", false);
            }
        }
    }

    void Fire()
    {
        if (GetComponent<Characte2D_Chabona>().facingRight)
        {
            var bullet = Instantiate(bulletPrefab, transform.position + new Vector3(2, 0, 0), Quaternion.identity);
            bullet.GetComponent<BulletScript>().direction = new Vector3(0.5f, 0, 0);
        }
        else
        {
            var bullet = Instantiate(bulletPrefab, transform.position + new Vector3(-2, 0, 0), Quaternion.identity);
            bullet.GetComponent<BulletScript>().direction = new Vector3(-0.5f, 0, 0);
        }
    }

    public IEnumerator stopAttackAnim(string animstring)
    {
        yield return new WaitForSeconds(0.5f);
        anim.SetBool(animstring, false);
    }
}
