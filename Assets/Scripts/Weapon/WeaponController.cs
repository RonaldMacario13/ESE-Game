using UnityEngine;

public class WeaponController : MonoBehaviour
{
    // Wearpon Characteristics
    [SerializeField] private int _damage = 1;
    
    // Components
    [SerializeField] private PlayerController _player;
    private Rigidbody2D _weaponRigidbody2D;
    
    // Flip config
    private Vector2 _playerDirection;
    private bool _rightPosition = true;

    void Start()
    {
        _weaponRigidbody2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        _playerDirection = _player._playerDirection;

        if (_playerDirection.x == 1.0f)
        {
            _rightPosition = true;
        }
        else if (_playerDirection.x == -1.0f)
        {
            _rightPosition = false;
        }

        FlipWeaponPosition();
    }

    void FlipWeaponPosition()
    {
        if(_rightPosition)
        {
            _weaponRigidbody2D.MovePosition(_player.transform.position + new Vector3(1.0f, 0.0f));
        }
        else 
        {
            _weaponRigidbody2D.MovePosition(_player.transform.position + new Vector3(-1.0f, 0.0f));
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.Equals(GameObject.FindGameObjectsWithTag("Enemy")))
        {
            other.GetComponent<EnemyController>()._health =- _damage;
        }
    }
}
