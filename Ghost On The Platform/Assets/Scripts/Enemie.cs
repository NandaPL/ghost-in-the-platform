using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemie : MonoBehaviour
{
    [SerializeField] float _speed = 3;

    Vector2 _startPosition;
    SpriteRenderer _spriteRenderer;
    Rigidbody2D _rigidbody2D;

    bool moveLeft = true;
    bool _hasDied;
    bool enemie = true;


    // Start is called before the first frame update
    void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _startPosition = _rigidbody2D.position;
    }

    // Update is called once per frame
    void Update()
    { 

    }

    void FixedUpdate()
    {
        if (enemie)
        {
            if (transform.position.x < -0.528f)
            {
                moveLeft = false;
                _spriteRenderer.flipX = true;
            }
            else if (transform.position.x > 5.57f)
            {
                moveLeft = true;
                _spriteRenderer.flipX = false;
            }

            if (moveLeft)
            {
                transform.Translate(Vector2.right * -_speed * Time.deltaTime);
            }
            else
            {
                transform.Translate(Vector2.right * _speed * Time.deltaTime);
            }
        }
    }

}
