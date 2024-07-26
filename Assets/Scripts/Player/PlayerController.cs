using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
  // Player Characteristics
  [SerializeField] private int _health;
  [SerializeField] private float _playerSpeed = 7;
  private float _playerInitialSpeed;
  [HideInInspector] public Vector2 _playerDirection;

  // Components
  private Rigidbody2D _playerRigidbody;
  private Animator _playerAnimator;
  private SpriteRenderer _spriteRenderer;

  // Audio

  public AudioSource audioSourceStep;
  public AudioSource audioSourcePoison;
  public AudioSource audioSourceRacket;
  public AudioSource audioSourceShoe;
  public float stepInterval = 0.5f;
  private float nextStepTime = 0f;

  // Attack
  private bool racket = false;
  private bool poison = true;
  private bool shoe = false;
  [SerializeField] private GameObject _weapon;
  private bool _isAttack = false;

  void Start()
  {
    _playerRigidbody = GetComponent<Rigidbody2D>();

    _playerAnimator = GetComponent<Animator>();

    _spriteRenderer = GetComponent<SpriteRenderer>();

    _playerInitialSpeed = _playerSpeed;
    _health = GetComponent<Health>()._health;

    _weapon.GetComponent<BoxCollider2D>().enabled = false;
  }

  void Update()
  {
    _playerDirection = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

    if (_health <= 0)
    {
      Death();
    }

        OnAttack();

                if (_playerDirection.sqrMagnitude > 0)
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
    _playerRigidbody.MovePosition(_playerRigidbody.position + _playerSpeed * Time.fixedDeltaTime * _playerDirection.normalized);

    if (racket) {
      _playerAnimator.SetBool("racket", true);

    } else if (poison) {
      _playerAnimator.SetBool("poison", true);
    } else {
      _playerAnimator.SetBool("shoe", true);
    }
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
      _isAttack = true;
      _playerSpeed = 0;
      _weapon.GetComponent<BoxCollider2D>().enabled = true;
    }

    if (Input.GetKeyUp(KeyCode.Space) || Input.GetMouseButtonUp(0))
    {
      _isAttack = false;
      _playerSpeed = _playerInitialSpeed;
      _weapon.GetComponent<BoxCollider2D>().enabled = false;
    }
  }
  
  void OnCollisionEnter2D(Collision2D other)
  {
    if (other.gameObject.CompareTag("Enemy"))
    {
      _health--;
    }
  }

  void Flip() {
        if (_playerDirection.x > 0)
        {
            _spriteRenderer.flipX = false;
        } else if(_playerDirection.x < 0)
        {
            _spriteRenderer.flipX = true;
        }
    }

  void Death()
  {
    Debug.Log("Morreu");
    SceneManager.LoadScene(5);
    Destroy(GameObject.FindGameObjectWithTag("Player"));
  }
}
