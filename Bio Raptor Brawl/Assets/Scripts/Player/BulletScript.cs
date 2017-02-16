using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour {

    public int damage;
    public Vector3 direction;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Player1" || collision.transform.tag == "Player2" || collision.transform.tag == "Player3" || collision.transform.tag == "Player4")
        {
            collision.transform.transform.GetComponent<Characte2D_Chabona>().curHealth -= damage;
            Destroy(this.gameObject);
        }
    }

    private void Start()
    {
        Destroy(this.gameObject, 1f);
    }

    private void Update()
    {
        transform.Translate(direction*0.3f);
    }
}
