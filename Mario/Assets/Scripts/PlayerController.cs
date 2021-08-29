using System;
using System.Collections;
using UnityEngine;

namespace DefaultNamespace
{
    public class PlayerController : MonoBehaviour
    {
            public int maxJumps = 1;
            
            [Range(1, 10f)] 
            public float MaxSpeed = 1;
        
            [Range(10, 1000f)] 
            public float MaxJump = 250;
        
            [Range(0.1f, 10f)] 
            public float Acceleration = 1;
            
            [Range(0f, 1)]
            public float AirControlMultiplier = 0.1f;
            
            private float _speed;
            private Collider2D _col;
            private Rigidbody2D _body;
            private Animator _animator;
            private int _jumpCount;

            public void Start()
            {
                _animator = GetComponent<Animator>();
                _col = GetComponent<Collider2D>();
                _body = GetComponent<Rigidbody2D>();
                if (_col == null)
                    Debug.LogError("Player has no collider");

                _speed = Acceleration;
            }

            private void Update()
            {
                if(_body.velocity.y > 0)
                    SetFalling();
            }

            public void SetAirControl(bool inAir)
            {
                if (inAir)
                    _speed = Acceleration * AirControlMultiplier;
                else
                    _speed = Acceleration;
            
            }

            public void Move(float horVel)
            {
                
                if(horVel == 0)
                {
                    _animator.SetBool("IsRunning", false);
                }
                else
                {
                    _animator.SetBool("IsRunning", true);
                    if (Mathf.Abs(_body.velocity.x) > MaxSpeed)
                    {
                        var velocity = _body.velocity;
                        float dir = velocity.x > 0 ? 1 : velocity.x < 0 ? -1 : 0;
                        velocity.x = dir * MaxSpeed;
                        _body.velocity = velocity;
 
                    }
                    _body.AddForce(new Vector2( horVel * Acceleration, 0), ForceMode2D.Force);
                }
            }
            
            public void Jump()
            {
                if( _jumpCount < maxJumps)
                {
                    _body.AddForce(new Vector2(0, MaxJump * _body.gravityScale * _body.mass));

                    _jumpCount++;
                }
            }
            
            public void SetFalling()
            {
                _animator.SetBool("InAir", false);
                _animator.SetBool("IsJumping", false);
            }

            public void Hit()
            {
                _animator.ResetTrigger("IsHit");
                _animator.SetTrigger("IsHit");
            }

            private void OnCollisionEnter2D(Collision2D other)
            {
                if(other.gameObject.layer == LayerMask.NameToLayer("Floor"))
                {
                    _jumpCount = 0;
                    _animator.SetBool("InAir", false);
                    _animator.SetBool("IsJumping", false);
                    SetAirControl(false);
                    print("Has landed");
                }
            }

            private void OnCollisionExit2D(Collision2D other)
            {
                if(other.gameObject.layer == LayerMask.NameToLayer("Floor"))
                {
                    _animator.SetBool("InAir", true);
                    SetAirControl(true);
                    print("In air");
                }
            }
    }
}