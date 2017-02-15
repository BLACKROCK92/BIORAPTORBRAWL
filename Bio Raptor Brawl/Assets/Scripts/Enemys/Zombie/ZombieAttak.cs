using UnityEngine;
using System.Collections;

public class ZombieAttak : MonoBehaviour {

    public Collider2D attackTrigger;
    private Animator _anim;

    void Awake()
    {
        _anim = gameObject.GetComponent<Animator>();
        attackTrigger.enabled = false;
    }

    public void EnableColliderAtak() {
        StartCoroutine("Boxenable");
    }

    IEnumerator Boxenable() {
     attackTrigger.enabled = true;
     yield return new WaitForSeconds(0.5f);
     attackTrigger.enabled = false;
    }
}
