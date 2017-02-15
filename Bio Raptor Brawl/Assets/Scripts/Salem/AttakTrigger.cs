using UnityEngine;
using System.Collections;

public class AttakTrigger : MonoBehaviour {

    public int dmg = 20;

    void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Enemy")) {
            other.GetComponentInParent<TurretIA>().Demage(dmg);
        }
    }
}
