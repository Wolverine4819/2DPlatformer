using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Rigidbody2D), typeof(Animator))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;
    private float moveInput;

    private Rigidbody2D rb;

    private bool facingRight = true;

    [SerializeField] private bool isGrounded;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float chekRadius;
    [SerializeField] private LayerMask whatIsGround;

    private int extraJumps;
    [SerializeField] private int extraJumpsValue;

    private Animator _playerAnimator;

    [SerializeField] Collider2D _headCollider;
    [SerializeField] Transform _cellChek;
    bool _crawling;
    bool _canStand;

    [Header("Casting")]
    [SerializeField] private GameObject _fireBall;
    [SerializeField] private Transform _firePoint;
    [SerializeField] private float _fireSpeed;
    private bool _isCasting;

    [Header("Strike")]
    [SerializeField] private Transform _strikePoint;
    [SerializeField] private int _damage;
    [SerializeField] private float _strikeRange;
    [SerializeField] private LayerMask _enemies;
    private bool _isSriking;
    [SerializeField] public int _countKunai;
    [SerializeField] Text _countTextKunai;

    private void Start()
    {
        extraJumps = extraJumpsValue;
        rb = GetComponent<Rigidbody2D>();

        _playerAnimator = GetComponent<Animator>();
        RefreshTextCountKunai();
    }

    private void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, chekRadius, whatIsGround);
        _canStand = !Physics2D.OverlapCircle(_cellChek.position, chekRadius, whatIsGround);

        moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);

        if(facingRight == false && moveInput > 0)
        {
            Flip();
        } else if(facingRight == true && moveInput < 0)
        {
            Flip();
        }

        if (_crawling)
        {
            _headCollider.enabled = false;
            _playerAnimator.SetBool("Seet", !_headCollider.enabled);
        }
        else if (!_crawling && _canStand)
        {
            _headCollider.enabled = true;
            _playerAnimator.SetBool("Seet", !_headCollider.enabled);
        }
        
    }

    private void Update()
    {
        if(isGrounded == true)
        {
            extraJumps = extraJumpsValue;
        }

        if(Input.GetKeyDown(KeyCode.UpArrow) && extraJumps > 0)
        {
            rb.velocity = Vector2.up * jumpForce;
            extraJumps--;
        } else if(Input.GetKeyDown(KeyCode.UpArrow) && extraJumps == 0 && isGrounded == true)
        {
            rb.velocity = Vector2.up * jumpForce;
        }

        _playerAnimator.SetBool("Jump", !isGrounded);
        _playerAnimator.SetFloat("Run", Mathf.Abs(moveInput));

        _crawling = Input.GetKey(KeyCode.C);

        if (Input.GetKey(KeyCode.Z))
            StartCasting();

        if (Input.GetKey(KeyCode.X))
            StartStrike();
    }

    void Flip()
    {
        facingRight = !facingRight;
        transform.Rotate(0, 180, 0);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(_cellChek.position, chekRadius);
        Gizmos.color = Color.black;
        Gizmos.DrawWireSphere(_strikePoint.position, _strikeRange);
    }

    public void StartCasting()
    {
        if (_countKunai != 0)
        {
            if (_isCasting)
                return;
            _isCasting = true;
            _playerAnimator.SetBool("Casting", true);
            _countKunai--;
            RefreshTextCountKunai();
        }
    }
    public void KunaiPlus(int value)
    {
        _countKunai += value;
        
    }

    public void RefreshTextCountKunai()
    {
        string textCountKunai = _countKunai.ToString();
        _countTextKunai.text = textCountKunai;
    }

    private void CastFire()
    {
        GameObject fireBall = Instantiate(_fireBall, _firePoint.position, Quaternion.identity);
        fireBall.GetComponent<Rigidbody2D>().velocity = transform.right * _fireSpeed;
        fireBall.GetComponent<SpriteRenderer>().flipX = !facingRight;
        Destroy(fireBall, 1);
    }

    private void EndCasting()
    {
        _isCasting = false;
        _playerAnimator.SetBool("Casting", false);
    }

    public void StartStrike()
    {
        if (_isSriking)
            return;
        _playerAnimator.SetBool("Strike", true);
        _isSriking = true;
    }

    public void Strike()
    {
        Collider2D[] enemies = Physics2D.OverlapCircleAll(_strikePoint.position, _strikeRange, _enemies);
        for(int i=0; i < enemies.Length; i ++)
        {
            EnemiesController enemy = enemies[i].GetComponent<EnemiesController>();
            enemy.TakeDamage(_damage);
        }
    }

    public void EndStrike()
    {
        _playerAnimator.SetBool("Strike", false);
        _isSriking = false;
    }

    public void Hurt()
    {
        _playerAnimator.SetBool("Hurt", true);
    }

    public void Hurt2()
    {
        _playerAnimator.SetBool("Hurt", false);
    }

}
