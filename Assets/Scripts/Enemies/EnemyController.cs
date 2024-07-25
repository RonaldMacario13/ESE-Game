using UnityEngine;

public class EnemyController : MonoBehaviour
{

  // Enemies Characteristics
  [SerializeField] private EnemyObject enemySettings;
  [HideInInspector] public int _health;
  private float _speed;
  private int _damage;

  // Components
  private Vector2 _direction;
  private Rigidbody2D _rigidbody;
  [SerializeField] private DetectionController _detectionArea;
  private SpriteRenderer _spriteRenderer;
  public AudioSource audioSourceMosquito;
  public float stepInterval = 3f;
  private float nextStepTime = 0f;

  // Events
  private bool isDamage;

  private Animator animator;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();

    _health = enemySettings._health;
    _speed = enemySettings._speed;
    _damage = enemySettings._damage;

    animator = GetComponent<Animator>();
    animator.runtimeAnimatorController = enemySettings._animatorController;
  }

  void Update()
  {
    _direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

    if (_health <= 0)
    {
      Death();
    }
  }

  void FixedUpdate()
  {
    if(_detectionArea.detectedObjs.Count > 0)
    {
            if (Time.time >= nextStepTime)
            {
                audioSourceMosquito.Play();
                nextStepTime = Time.time + stepInterval;
            } 
      _direction = (_detectionArea.detectedObjs[0].transform.position - transform.position).normalized;

      _rigidbody.MovePosition(_rigidbody.position + _speed * Time.fixedDeltaTime * _direction);

      if (_direction.x > 0)
            {
                _spriteRenderer.flipX = false;
            } else if(_direction.x < 0) {
                _spriteRenderer.flipX = true;
            }
    } else {
            audioSourceMosquito.Stop();
  }
  }

  void OnTriggerEnter2D(Collider2D other) {
    if(other.CompareTag("Weapon") & isDamage == false)
    {
      isDamage = true;
      _health -= 1;
      Debug.Log("Vida inimigo:" + _health);
    }
  }

  void OnTriggerExit2D(Collider2D other) {
    if(other.CompareTag("Weapon"))
    {
      isDamage = false;
    }
  }

  void Death()
  {
    Destroy(gameObject);
  }
}
