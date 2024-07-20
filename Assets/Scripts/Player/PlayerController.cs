using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Player Characteristics
    private int _health;
    [SerializeField] private float _playerSpeed = 7;
    private float _playerInitialSpeed;
    [HideInInspector] public Vector2 _playerDirection;

    // Components
    private Rigidbody2D _playerRigidbody;

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
        _health = GetComponent<Health>()._health;

        if (_health <= 0)
        {
            Death
    ();
        }

        OnAttack();
    }

    // Esse método é chamado a cada 0.2 segundos (Para um melhor controle da física do jogo deve ser feita aqui 
    // dentro.)
    void FixedUpdate()
    {
        _playerRigidbody.MovePosition(_playerRigidbody.position + _playerSpeed * Time.fixedDeltaTime * _playerDirection.normalized);
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

    void Death()
    {
        Debug.Log("Morreu");
        Destroy(GameObject.FindGameObjectWithTag("Player"));
    }
}
