using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{

    public GameObject Destination;
    public float cooldown;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player" && cooldown <= 0)
        {
            other.transform.position = Destination.transform.position - new Vector3(2, 0, 0);
            other.GetComponent<Rigidbody2D>().AddForce(new Vector2(-4,0));
            foreach(Teleporter t in GameObject.FindObjectsOfType<Teleporter>())
            {
                t.cooldown = 2;
            }
        }
        else if (other.tag == "Player" && cooldown > 0)
        {
            print("Teleporter on Cooldown! (" + cooldown + "s)");
        }
    }

    private void FixedUpdate()
    {
        if (cooldown > 0)
        {
            cooldown = cooldown - 0.1f;
        }
        else if (cooldown <= 0)
        {
            cooldown = 0;
        }

    }
}
