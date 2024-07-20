using UnityEngine;

public class WeaponController : MonoBehaviour
{

    [SerializeField] private PlayerController _player;
    private Rigidbody2D _weaponRigidbody2D;
    private Vector2 _playerDirection;
    private bool _rightPosition = true;

    // Start is called before the first frame update
    void Start()
    {
        _weaponRigidbody2D = GetComponent<Rigidbody2D>();
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
}
