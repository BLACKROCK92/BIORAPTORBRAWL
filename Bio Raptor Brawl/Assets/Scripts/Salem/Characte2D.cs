using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Characte2D : MonoBehaviour {
    
    public float speed = 50f;
    public float jumpForce = 1000f;
    public float maxSpeed = 30f;

    public int curHealth;
    public int maxHealth = 100;

    public bool grounded;
    public bool canDobleJumping;
    public bool facingRight  = true;

    private Rigidbody2D _rb;
    private Animator _anim;

    public bool wallSliding;
    public Transform wallCheckPoint;
    public bool wallCheck;
    public LayerMask wallLayerMask;


	void Awake () {
        _rb = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();

        curHealth = maxHealth;
	}

    void Update() {

        _anim.SetBool("grounded", grounded);
        _anim.SetFloat("speed", Mathf.Abs(_rb.velocity.x));

        if (Input.GetKey(KeyCode.A))
        {
            transform.localScale = new Vector3(-1, 1, 1);
            facingRight = false;

        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.localScale = new Vector3(1, 1, 1);
            facingRight = true;
        }

        if (Input.GetButtonDown("Jump") && !wallSliding) {
            if (grounded)
            {
                _rb.AddForce(Vector2.up * jumpForce);
                canDobleJumping = true;
            }
            else {
                if (canDobleJumping) {
                    canDobleJumping = false;
                    _rb.velocity = new Vector2(_rb.velocity.x, 0);
                    //agustar para mejorar el doble salto
                    _rb.AddForce(Vector2.up * jumpForce / 1.3f);
                }
            }
        }

        if (curHealth > maxHealth) {
            curHealth = maxHealth;
        }

        if (curHealth <= 0) {
            Die();
        }

        if(!grounded){

            wallCheck = Physics2D.OverlapCircle(wallCheckPoint.position, 0.1f, wallLayerMask);

            if (facingRight && Input.GetAxis("Horizontal") > 0.1f || !facingRight && Input.GetAxis("Horizontal") < 0.1f)
            {
                if (wallCheck) {
                    HandleWallSliding();
                }
            }
        }

        if (wallCheck == false || grounded) {
            wallSliding = false;
        }
    }

    void HandleWallSliding() {

        _rb.velocity = new Vector2(_rb.velocity.x, -1f);
        wallSliding = true; 

        if (Input.GetButtonDown("Jump")) {
            if (facingRight)
            {
                _rb.AddForce(new Vector2(-2,1) * jumpForce);
            }
            else {
                _rb.AddForce(new Vector2(2,1) * jumpForce);
            }
        }
    }
	
	void FixedUpdate () {

        Vector3 easeVelocity = _rb.velocity;
        easeVelocity.y = _rb.velocity.y;
        easeVelocity.z = 0.0f;
        float h = Input.GetAxis("Horizontal");
        //print(h);
        //easeVelocity.x se modifica para agregar o sacar friccion en los movimientos del personaje
        easeVelocity.x *= 0.75f;

        if (grounded) {
            _rb.velocity = easeVelocity;
        }

        if (grounded)
        {
            _rb.AddForce((Vector2.right * speed) * h);
        }
        else {
            _rb.AddForce((Vector2.right * speed /2) * h);   
        }

        if (_rb.velocity.x > maxSpeed) {
            _rb.velocity = new Vector2(maxSpeed, _rb.velocity.y);
        }

        if (_rb.velocity.x < -maxSpeed)
        {
            _rb.velocity = new Vector2(-maxSpeed, _rb.velocity.y);
        }

        if (Input.GetKey(KeyCode.A))
        {
            _rb.AddForce(Vector2.left * speed);
        }

        if (Input.GetKey(KeyCode.D))
        {
            _rb.AddForce(Vector2.right * speed);
        }
	
    }

    void Die() {
        SceneManager.LoadScene("MainScene");
    }

    public void Demage(int dmg) {
        curHealth -= dmg;
        GetComponent<Animation>().Play("redFlash");

    }

    public IEnumerator Knockback(float knockDur, float knockbackPwr, Vector3 knockbackDir) {

        float timer = 0;
        _rb.velocity = new Vector2(_rb.velocity.x, 0);
        while(knockDur > timer){
            timer+=Time.deltaTime;
            _rb.AddForce(new Vector3(knockbackDir.x*-100,knockbackDir.y * knockbackPwr, transform.position.z));
        }

        yield return 0;
    }
}
