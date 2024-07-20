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
