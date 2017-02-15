using UnityEngine;
using System.Collections;

public class ZombieScript : MonoBehaviour {

    private Animator _anim;
    private Transform _trans;
    public AttackConeZombie coneIzk;
    public AttackConeZombie coneDer;
    public ZombieAttak zombieAttak;
    void Awake () {
        _anim = GetComponent<Animator>();
        _trans = GetComponent<Transform>();
	}
	
    public void Attack(bool attackingRight)
    {
        if (attackingRight)
        {
            coneDer.isLeft = false;
            coneIzk.isLeft = true;

            _trans.localScale = new Vector3(2.5f, 2.5f, 1f);
            _anim.SetBool("atak", true);
            zombieAttak.EnableColliderAtak();
        }
        else {
            coneDer.isLeft = true;
            coneIzk.isLeft = false;

            _trans.localScale = new Vector3(-2.5f,2.5f,1f);
            _anim.SetBool("atak", true);
            zombieAttak.EnableColliderAtak();
        }
    }

    public void EndAttack() {
        _anim.SetBool("atak", false);
    }

    public void Folow(bool folowRight,Transform playerTransform) {

        if (folowRight)
        {
            _trans.Translate(Vector2.right * Time.deltaTime);
        }
        else {
            _trans.Translate(Vector2.left * Time.deltaTime);
        }

    }

}
