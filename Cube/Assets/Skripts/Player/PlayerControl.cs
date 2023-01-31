using UnityEngine;

[RequireComponent(typeof(Health))]

public class PlayerControl : MonoBehaviour
{
    [SerializeField] private ShopsItem _shopsItem;

    [SerializeField] private float _distanceLazer;
    [SerializeField] protected float _gravityForce;

    [SerializeField] private Ultimate ultimate;

    private Rigidbody2D _rigidbody2D;
    public float GravityForce { get => _gravityForce; set => _gravityForce = value; }

    public bool CheckUltimate { get; set; }
    

    //private void Awake()
    //{
    //    _shopsItem.LoadPlayer();
    //}

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    public void OnButtonDown()
    {
        _rigidbody2D.gravityScale = _gravityForce;
        CheckUltimate = true;
    }

    public void OnGround()
    {
        Physics2D.queriesStartInColliders = false;

        var hit = Physics2D.Raycast(transform.position, Vector2.down, _distanceLazer);

        Debug.DrawRay(transform.position, Vector2.down * _distanceLazer, Color.red);

        if (hit.transform != null && hit.transform.CompareTag("Ground"))
        {
            _rigidbody2D.gravityScale = -_gravityForce;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            OnGround();
        }
    }
}
