using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private EnemyObject enemySettings;
    [SerializeField] private DetectionController _detectionArea;

    // Enemies Characteristics
    private int _life;
    private float _speed;

    // Transform
    private Vector2 _direction;
    private Rigidbody2D _rigidbody;
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

        _life = enemySettings._life;
        _speed = enemySettings._speed;

        animator = GetComponent<Animator>();
        animator.runtimeAnimatorController = enemySettings._animatorController;
    }

    void Update()
    {
        _direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
    }

    void FixedUpdate()
    {
        if(_detectionArea.detectedObjs.Count > 0)
        {
            // print("Era para rodar o som");
            if (Time.time >= nextStepTime)
            {
                audioSourceMosquito.Play();
                nextStepTime = Time.time + stepInterval;
            } 
            _direction = (_detectionArea.detectedObjs[0].transform.position - transform.position).normalized;

            
            _rigidbody.MovePosition(_rigidbody.position + _direction * _speed * Time.fixedDeltaTime);

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

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Weapon") & isDamage == false)
        {
            isDamage = true;
            _life -= 1;
            Debug.Log("Vida inimigo:" + _life);
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if(other.CompareTag("Weapon"))
        {
            isDamage = false;
        }
    }
}
