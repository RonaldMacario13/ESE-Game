using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private Rigidbody2D _playerRigidbody;
    [SerializeField] private float _playerSpeed = 7;
    private float _playerInitialSpeed;
    [HideInInspector] public Vector2 _playerDirection;

    // Attack
    [SerializeField] private GameObject _weapon;
    private bool _isAttack = false;

    void Start()
    {
        _playerRigidbody = GetComponent<Rigidbody2D>();

        _playerInitialSpeed = _playerSpeed;

        _weapon.GetComponent<BoxCollider2D>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        _playerDirection = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        // Debug.Log(_playerDirection);

        OnAttack();
    }

    // Esse método é chamado a cada 0.2 segundos (Para um melhor controle da física do jogo deve ser feita aqui 
    // dentro.)
    void FixedUpdate()
    {
        _playerRigidbody.MovePosition(_playerRigidbody.position + _playerDirection.normalized * _playerSpeed * Time.fixedDeltaTime);
    }

    void OnAttack()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            // Debug.Log("Atacando!");
            _isAttack = true;
            _playerSpeed = 0;
            // _weapon.SetActive(true);
            _weapon.GetComponent<BoxCollider2D>().enabled = true;
        }

        if (Input.GetKeyUp(KeyCode.Space) || Input.GetMouseButtonUp(0))
        {
            // Debug.Log("Parou o ataque!");
            _isAttack = false;
            _playerSpeed = _playerInitialSpeed;
            // _weapon.SetActive(false);
            _weapon.GetComponent<BoxCollider2D>().enabled = false;
        }
    }

}
