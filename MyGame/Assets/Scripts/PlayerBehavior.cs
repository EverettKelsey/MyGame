using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class PlayerBehavior : MonoBehaviour
{
    public float moveSpeed = 10f;
    public float sensitivity = 2f;
    public float jumpVelocity = 5f;
    public float distanceToGround = 0.1f;
    public LayerMask groundLayer;
    public GameObject bullet;
    public float bulletSpeed = 100f;
    public float SpeedIncrease = 40f;
    public Vector2 turn;

    private Rigidbody _rb;
    private CapsuleCollider _col;
    private bool doJump = false;
    private bool doShoot = false;
    private float speedMultiplier;
    private GameBehavior _gameManager;
    [SerializeField] AudioClip[] clip;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _col = GetComponent<CapsuleCollider>();
        _gameManager = GameObject.Find("Game Manager").GetComponent<GameBehavior>();
    }
    // Update is called once per frame
    void Update()
    {
        turn.x += Input.GetAxis("Mouse X") * sensitivity;
        turn.y += Input.GetAxis("Mouse Y") * sensitivity;
        transform.localRotation = Quaternion.Euler(-turn.y, turn.x, 0);
        if (IsGrounded() && Input.GetKeyDown(KeyCode.Space))
        {
            doJump = true;
        }

        if (Input.GetMouseButtonDown(0))
        {
            doShoot = true;
            GetComponent<AudioSource>().PlayOneShot(clip[0]);
        }

        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed);
        }
        if (Input.GetKey(KeyCode.S))
        { 
            transform.Translate(-1 * Vector3.forward * Time.deltaTime * moveSpeed);
        }
        if (Input.GetKey(KeyCode.A)) { 
            transform.Translate(Vector3.left * Time.deltaTime * moveSpeed);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * Time.deltaTime * moveSpeed);
        }

    }

    void FixedUpdate()
    {
        if (doJump)
        {
            _rb.AddForce(Vector3.up * jumpVelocity, ForceMode.Impulse);
            doJump = false;
        }

        if (doShoot)
        {
            GameObject newBullet = Instantiate(bullet, this.transform.position + this.transform.right, this.transform.rotation) as GameObject;
            Rigidbody bulletRb = newBullet.GetComponent<Rigidbody>();
            bulletRb.velocity = this.transform.forward * bulletSpeed;
            doShoot = false;
        }
    }

    private bool IsGrounded()
    {
        Vector3 capsuleBottom = new Vector3(_col.bounds.center.x, _col.bounds.min.y, _col.bounds.center.z);
        bool grounded = Physics.CheckCapsule(_col.bounds.center, capsuleBottom, distanceToGround, groundLayer, QueryTriggerInteraction.Ignore);
        return grounded;
    }

    public void BoostSpeed(float multiplier, float seconds)
    {
        speedMultiplier = multiplier;
        moveSpeed *= multiplier;
        Invoke("endSpeedBoost", seconds);
    }

    private void endSpeedBoost()
    {
        moveSpeed /= speedMultiplier;
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "Enemy" || collision.gameObject.name == "Enemy 2" || collision.gameObject.name == "Enemy 3")
        {
            _gameManager.HP -= 1;
            GetComponent<AudioSource>().PlayOneShot(clip[1]);
        }
    }
}
