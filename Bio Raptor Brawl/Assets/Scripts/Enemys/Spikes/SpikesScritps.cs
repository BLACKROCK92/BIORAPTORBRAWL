using UnityEngine;
using System.Collections;

public class SpikesScritps : MonoBehaviour {
   
    public Characte2D Player;

    void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player"))
        {
            Player.Demage(10);
            StartCoroutine(Player.Knockback(0.02f,450,Player.transform.position));
        }
    }

}
