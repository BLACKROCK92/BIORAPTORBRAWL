using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D other) { 
        if(!other.isTrigger){
            if(other.CompareTag("Player")){
                other.GetComponent<Characte2D>().Demage(5);
                Destroy(gameObject);
            }
        }
    }
}
