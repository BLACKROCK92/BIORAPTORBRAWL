using UnityEngine;
using System.Collections;

public class AttackConeZombie : MonoBehaviour {

    public ZombieScript zombieScript;


    public bool isLeft = false;

    void Awake() {
        zombieScript = gameObject.GetComponentInParent<ZombieScript>();
    }

    void OnTriggerStay2D(Collider2D other)
    {
        
        if (other.CompareTag("Player")){

            if (isLeft)
            {
                zombieScript.Attack(false);
            }
            else {
                zombieScript.Attack(true);
            }
        }
    }


    void OnTriggerExit2D(Collider2D other)
    {

        if (other.CompareTag("Player"))
        {
            zombieScript.EndAttack();
        }
    }
}
