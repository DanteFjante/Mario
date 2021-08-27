using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerInput : MonoBehaviour
{

    [Range(1, 10f)] 
    public float MaxSpeed = 1;
    
    [Range(10, 1000f)] 
    public float MaxJump = 250;
    
    [Range(0.1f, 10f)] 
    public float Acceleration = 1;
    
    public int maxJumps = 1;

    [Range(0f, 1)]
    public float AirControlMultiplier = 0.1f;
    
    private Collider2D _col;
    private Rigidbody2D _body;

    private int _jumpCount;
    
    // Start is called before the first frame update
    void Start()
    {
        _col = GetComponent<Collider2D>();
        _body = GetComponent<Rigidbody2D>();
        if (_col == null)
            Debug.LogError("Player has no collider");
        
    }

    // Update is called once per frame
    void Update()
    {
        float hor = Input.GetAxis("Horizontal");

        if (!_col.IsTouchingLayers(LayerMask.GetMask("Floor")))
            hor *= AirControlMultiplier;
        
        if(hor != 0)
        {
            _body.AddForce(new Vector2( hor * Acceleration, 0), ForceMode2D.Force);

            if (Mathf.Abs(_body.velocity.x) > MaxSpeed)
            {
                var velocity = _body.velocity;
                float dir = velocity.x > 0 ? 1 : velocity.x < 0 ? -1 : 0;
                velocity.x = dir * MaxSpeed;
                _body.velocity = velocity;
            }
        }
        if(Input.GetButtonDown("Jump") && _jumpCount < maxJumps)
        {
            _body.AddForce(new Vector2(0, MaxJump * _body.gravityScale * _body.mass));
            _jumpCount++;
        }
            
    }


    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.layer == LayerMask.NameToLayer("Floor"))
            _jumpCount = 0;
    }
}
