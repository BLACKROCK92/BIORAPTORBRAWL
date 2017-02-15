using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleporterEnemy : MonoBehaviour
{

    public GameObject Destination;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            other.transform.position = Destination.transform.position - new Vector3(2, 0, 0);
            other.GetComponent<Rigidbody2D>().AddForce(new Vector2(-4,0));
            foreach(Teleporter t in GameObject.FindObjectsOfType<Teleporter>())
            {
                t.cooldown = 2;
            }
        }
    }
}
