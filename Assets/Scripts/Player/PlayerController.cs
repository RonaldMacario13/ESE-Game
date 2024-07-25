using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{

    private Rigidbody2D playerRigidbody;
    [SerializeField] private float playerSpeed = 7;
    private Animator _playerAnimator;
    private float playerInitialSpeed;
    private Vector2 playerDirection;
    private SpriteRenderer _spriteRenderer;
    public AudioSource audioSourceStep;
    public AudioSource audioSourcePoison;
    public AudioSource audioSourceRacket;
    public AudioSource audioSourceShoe;
    public float stepInterval = 0.5f;
    private float nextStepTime = 0f;
    private bool racket = true;
    private bool poison = false;
    private bool shoe = false;

    // Attack
    [SerializeField] private GameObject Weapon;
    private bool isAttack = false;

    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();

        _playerAnimator = GetComponent<Animator>();

        _spriteRenderer = GetComponent<SpriteRenderer>();

        playerInitialSpeed = playerSpeed;

        Weapon.SetActive(false);

        if (racket) {
            _playerAnimator.SetBool("racket", true);
        } else if (poison) {
            _playerAnimator.SetBool("poison", true);
        } else {
            _playerAnimator.SetBool("shoe", true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        playerDirection = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        OnAttack();

        if (playerDirection.sqrMagnitude > 0)
        {
            _playerAnimator.SetBool("isWalking", true);
            if (Time.time >= nextStepTime)
            {
                audioSourceStep.Play();
                nextStepTime = Time.time + stepInterval;
            } 
        } else {
            _playerAnimator.SetBool("isWalking", false);
            audioSourceStep.Stop();
        }

        Flip();
    }

    // Esse método é chamado a cada 0.2 segundos (Para um melhor controle da física do jogo deve ser feita aqui 
    // dentro.)
    void FixedUpdate()
    {
        playerRigidbody.MovePosition(playerRigidbody.position + playerDirection.normalized * playerSpeed * Time.fixedDeltaTime);
    }

    void OnAttack()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            _playerAnimator.SetTrigger("isAttacking");
            if (racket) {
                audioSourceRacket.Play();
            } else if (poison) {
                audioSourcePoison.Play();
            } else {
                audioSourceShoe.Play();
            }
            isAttack = true;
            playerSpeed = 0;
            Weapon.SetActive(true);
        }

        if (Input.GetKeyUp(KeyCode.Space) || Input.GetMouseButtonUp(0))
        {
            // Debug.Log("Parou o ataque!");
            isAttack = false;
            playerSpeed = playerInitialSpeed;
            Weapon.SetActive(false);
        }
    }

    void Flip() {
        if (playerDirection.x > 0)
        {
            _spriteRenderer.flipX = false;
        } else if(playerDirection.x < 0)
        {
            _spriteRenderer.flipX = true;
        }
    }
}
