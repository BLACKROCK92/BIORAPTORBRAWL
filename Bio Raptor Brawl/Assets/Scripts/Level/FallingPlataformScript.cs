using UnityEngine;
using System.Collections;

public class FallingPlataformScript : MonoBehaviour {

    private Rigidbody2D _rb;
    public float fallDelay;

    void Awake() {
        _rb = GetComponent<Rigidbody2D>();
    }

    void OnCollisionEnter2D(Collision2D other) {

        if (other.gameObject.CompareTag("Player")) {
            StartCoroutine(FallC());
        }
    }

    IEnumerator FallC() {

        yield return new WaitForSeconds(fallDelay);

        _rb.isKinematic = false;
    }
}
