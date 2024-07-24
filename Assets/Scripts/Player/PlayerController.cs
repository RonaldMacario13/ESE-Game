using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private Rigidbody2D playerRigidbody;
    [SerializeField] private float playerSpeed = 7;
    private Animator _playerAnimator;
    private float playerInitialSpeed;
    private Vector2 playerDirection;
    private SpriteRenderer _spriteRenderer;

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
    }

    // Update is called once per frame
    void Update()
    {
        playerDirection = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        OnAttack();

        if (playerDirection.sqrMagnitude > 0)
        {
            _playerAnimator.SetBool("isWalking", true); 
        } else {
            _playerAnimator.SetBool("isWalking", false);
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
            _playerAnimator.SetBool("racket", true);
            _playerAnimator.SetTrigger("isAttacking");
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
