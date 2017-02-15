using UnityEngine;
using System.Collections;

public class AttakTrigger_Chabona : MonoBehaviour {

    public int dmg = 20;

    void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player1") || other.CompareTag("Player2")) {
            other.GetComponentInParent<Characte2D_Chabona>().Damage(dmg);
        }
    }
}
