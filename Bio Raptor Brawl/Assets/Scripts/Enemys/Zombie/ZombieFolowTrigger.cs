using UnityEngine;
using System.Collections;

public class ZombieFolowTrigger : MonoBehaviour {
    public bool isLeft;
    public ZombieScript zombieScript;

    
    void Start () {
	
	}
	

	void Update () {
	
	}

    void OnTriggerStay2D(Collider2D other)
    {

        if (other.CompareTag("Player"))
        {

            if (isLeft)
            {
                zombieScript.Folow(false,other.transform);
            }
            else
            {
                zombieScript.Folow(true, other.transform);
            }
        }
    }
}
