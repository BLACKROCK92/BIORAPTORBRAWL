using UnityEngine;
using System.Collections;

public class Player_Attak_Chabona : MonoBehaviour {

    private bool attacking = false;
    private float attackTimer = 0;
    private float attackCd = 0.3f;
    public Collider2D attackTrigger;
    public Animator anim;

    public string attackButton = "Fire1_P1";

    void Awake() {
        anim = gameObject.GetComponent<Animator>();
        attackTrigger.enabled = false;
    }

    void Update() { 
       
        if(Input.GetButtonDown(attackButton) && !attacking){

            attacking = true;
            attackTimer = attackCd;
            attackTrigger.enabled = true;
            anim.SetBool("Attack", true);
        }

        if(attacking){
            if (attackTimer > 0)
            {
                attackTimer -= Time.deltaTime;
               
            }
            else {
                attacking = false;
                attackTrigger.enabled = false;
                anim.SetBool("Attack", false);
            }
        }
             
    }
}
