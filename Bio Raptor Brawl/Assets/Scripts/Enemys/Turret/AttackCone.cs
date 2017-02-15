using UnityEngine;
using System.Collections;

public class AttackCone : MonoBehaviour {
    
    public TurretIA turretIA;

    public bool isLeft = false;

    void Awake() {
        turretIA = gameObject.GetComponentInParent<TurretIA>();
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player")){
            if (isLeft)
            {
                turretIA.Attack(false);
            }
            else {
                turretIA.Attack(true);
            }
        }
    }

}

