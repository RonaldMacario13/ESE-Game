using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private EnemyObject enemySettings;

    private string _name;

    private float _speed = 3.5f;
    private Vector2 _direction;
    private Rigidbody2D _rigidbody;

    [SerializeField] private DetectionController _detectionArea;
    
    private float _health;
    private float _attack;

    private Animator animator;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();

        animator = GetComponent<Animator>();

        animator.runtimeAnimatorController = enemySettings.animatorController;

        _name = enemySettings.enemyName;
        _health = enemySettings.health;
        _speed = enemySettings.speed;
        _attack = enemySettings.attack;

    }

    void Update()
    {
        _direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
    }

    void FixedUpdate()
    {
        if(_detectionArea.detectedObjs.Count > 0)
        {
            _direction = (_detectionArea.detectedObjs[0].transform.position - transform.position).normalized;

            _rigidbody.MovePosition(_rigidbody.position + _direction * _speed * Time.fixedDeltaTime);
        }
    }

}
