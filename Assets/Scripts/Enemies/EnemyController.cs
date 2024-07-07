using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private EnemyObject enemySettings;
    [SerializeField] private DetectionController _detectionArea;

    private float _speed;
    private Vector2 _direction;
    private Rigidbody2D _rigidbody;

    
    private Animator animator;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();

        _speed = enemySettings.speed;

        animator = GetComponent<Animator>();
        animator.runtimeAnimatorController = enemySettings.animatorController;
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
