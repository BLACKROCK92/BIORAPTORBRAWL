using UnityEngine;
using System.Collections;

public class ZombieAttakTrigger : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.isTrigger)
        {
            if (other.CompareTag("Player"))
            {
                other.GetComponent<Characte2D>().Demage(3);
            }
        }
    }
}
