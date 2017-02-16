using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Characte2D_Chabona : MonoBehaviour {
    
    public float speed = 50f;
    public float jumpForce = 1000f;
    public float maxSpeed = 30f;

    public float curHealth;
    public float maxHealth = 100;

    public bool grounded;
    public bool robot = false;
    public bool air;
    public bool canDobleJumping;
    public bool facingRight  = true;

    private Rigidbody2D _rb;
    private Animator _anim;

    public bool wallSliding;
    public Transform wallCheckPoint;
    public bool wallCheck;
    public LayerMask wallLayerMask;

    public string jumpButton = "Jump_P1";
    public string horizontalCtrl = "Horizontal_P1";
    public string robotButton = "Robot_P1";


	void Awake () {
        _rb = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
        curHealth = maxHealth;
	}

    void Update() {

        _anim.SetFloat("run", Mathf.Abs(_rb.velocity.x));

        if (gameObject.tag == "Player1")
        {
            if (Input.GetKey(KeyCode.A))
            {
                transform.localScale = new Vector3(-0.25f, 0.25f, 1);
                facingRight = false;

            }

            if (Input.GetKey(KeyCode.D))
            {
                transform.localScale = new Vector3(0.25f, 0.25f, 1);
                facingRight = true;
            }
        }
        else if (gameObject.tag == "Player2") {

            if (Input.GetKey(KeyCode.J))
            {
                transform.localScale = new Vector3(-0.57f, 0.57f, 1);
                facingRight = false;

            }

            if (Input.GetKey(KeyCode.L))
            {
                transform.localScale = new Vector3(0.57f, 0.57f, 1);
                facingRight = true;
            }

        }

        //if(grounded)
        //    _anim.SetBool("air", false);
        //else
        //    _anim.SetBool("air", true);


        if (Input.GetButtonDown(jumpButton) && !wallSliding) {
            if (grounded)
            {
                _rb.AddForce(Vector2.up * jumpForce);
                canDobleJumping = true;
            }
            else {
                if (canDobleJumping) {
                    canDobleJumping = false;
                    _rb.velocity = new Vector2(_rb.velocity.x, 0);
                    //ajustar para mejorar el doble salto
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

            if (facingRight && Input.GetAxis(horizontalCtrl) > 0.1f || !facingRight && Input.GetAxis(horizontalCtrl) < 0.1f)
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

        if (Input.GetButtonDown(jumpButton)) {
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
        float h = Input.GetAxis(horizontalCtrl);
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

        if (Input.GetButtonDown(horizontalCtrl))
        {
            _rb.AddForce(Vector2.left * speed);
        }

        if (Input.GetButtonDown(horizontalCtrl))
        {
            _rb.AddForce(Vector2.right * speed);
        }

        if (Input.GetButtonDown(robotButton))
        {
            robot = !robot;
            _anim.SetBool("robot", robot);
        }

    }

    void Die() {
        SceneManager.LoadScene("MainScene");
    }

    public void Damage(int dmg) {
        curHealth -= dmg;
        print(curHealth);
       // GetComponent<Animation>().Play("redFlash");

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
