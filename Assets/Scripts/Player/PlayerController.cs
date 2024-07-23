using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private Rigidbody2D playerRigidbody;
    [SerializeField] private float playerSpeed = 7;
    private Animator _playerAnimator;
    private float playerInitialSpeed;
    private Vector2 playerDirection;
    private SpriteRenderer _spriteRenderer;

    private bool isAttack = false;

    // Start is called before the first frame update
    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();

        _playerAnimator = GetComponent<Animator>();

        _spriteRenderer = GetComponent<SpriteRenderer>();

        playerInitialSpeed = playerSpeed;
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
        if (Input.GetKeyDown(KeyCode.LeftControl) || Input.GetMouseButtonDown(0))
        {
            _playerAnimator.SetBool("racket", true);
            _playerAnimator.SetTrigger("isAttacking");
            Debug.Log("Atacando!");
            isAttack = true;
            playerSpeed = 0;
        }

        if (Input.GetKeyUp(KeyCode.LeftControl) || Input.GetMouseButtonUp(0))
        {
            Debug.Log("Parou o ataque!");
            isAttack = false;
            playerSpeed = playerInitialSpeed;
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
