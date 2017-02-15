using UnityEngine;
using System.Collections;

public class TurretBullet : MonoBehaviour
{

    public Transform FindTargetTransform;

    void Update()
    {
        if (FindTargetTransform)
        {
            transform.position = Vector3.MoveTowards(transform.position, FindTargetTransform.position, (Time.deltaTime));
            transform.LookAt(FindTargetTransform.position);
        }
        else
        {
            Destroy(gameObject);
        }
        eliminarDisparo();
    }

    void OnTrigger2DEnter(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            eliminarDisparo();
            //other.GetComponent<EnemyController>().EventosVidas(daño);
        }
    }

    void eliminarDisparo()
    {
        Destroy(gameObject, 0.01f);
    }
}