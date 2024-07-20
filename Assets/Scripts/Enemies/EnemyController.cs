using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private EnemyObject enemySettings;
    [SerializeField] private DetectionController _detectionArea;

    // Enemies Characteristics
    [HideInInspector] public int _health;
    private float _speed;

    // Transform
    private Vector2 _direction;
    private Rigidbody2D _rigidbody;

    // Events
    private bool isDamage;

    private Animator animator;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();

        _health = enemySettings._health;
        _speed = enemySettings._speed;

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
            _direction = (_detectionArea.detectedObjs[0].transform.position - transform.position).normalized;

            _rigidbody.MovePosition(_rigidbody.position + _direction * _speed * Time.fixedDeltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Weapon") & isDamage == false)
        {
            isDamage = true;
            _health -= 1;
            Debug.Log("Vida inimigo:" + _health);
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if(other.CompareTag("Weapon"))
        {
            isDamage = false;
        }
    }

    private void Death()
    {
        Destroy(gameObject);
    }
}
