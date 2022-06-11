using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float _speed = 1;
    [SerializeField] float _force = 200;
    [SerializeField] bool isGround;
    [SerializeField] Sprite _alivedSprite;
    [SerializeField] Sprite _diedSprite;
    [SerializeField] Animator _animWalk, _animJump;

    Vector2 _startPosition;
    Rigidbody2D _rigidbody2D;
    SpriteRenderer _spriteRenderer;

    bool _hasDied;
    float delay;

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
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            transform.position += new Vector3(0.5f * _speed, 0, 0);
            _spriteRenderer.flipX = false;

            _animWalk.SetBool("isWalk", true);
            _animJump.SetBool("isJump", false);
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            transform.position -= new Vector3(0.5f * _speed, 0, 0);
            _spriteRenderer.flipX = true;

            _animWalk.SetBool("isWalk", true);
            _animJump.SetBool("isJump", false);
        }

        if (Input.GetKeyUp(KeyCode.RightArrow) || Input.GetKeyUp(KeyCode.LeftArrow))
        {
            _animWalk.SetBool("isWalk", false);
        }

        if (Input.GetKeyDown(KeyCode.Space) && isGround)
        {         
            _rigidbody2D.AddForce(transform.up * _force);
            isGround = false;

            if (isGround == false)
            {
                _animJump.SetBool("isJump", true);
            }
          
        }

        if (isGround)
        {
            _animJump.SetBool("isJump", false);
        }
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(ShouldDieFromCollision(collision))
        {
            delay = 0.50f;
            StartCoroutine(Die(delay));
        }

        if (collision.gameObject.tag == "Buraco")
        {
            delay = 0f;
            StartCoroutine(Die(delay));
        }

        if (collision.gameObject.tag == "Ground")
        {
            isGround = true;
        }

    }

    IEnumerator Die(float delay)
    {
        _hasDied = true;
        GetComponent<SpriteRenderer>().sprite = _diedSprite;
        yield return new WaitForSeconds(delay);

        _hasDied = false;
        GetComponent<SpriteRenderer>().sprite = _alivedSprite;
        _rigidbody2D.position = _startPosition;

        _rigidbody2D.velocity = Vector2.zero;
        
    }

    bool ShouldDieFromCollision(Collision2D collision)
    {
        if (_hasDied)
            return false;

        if (collision.gameObject.tag == "Spike")
            return true;

        Enemie enemie = collision.gameObject.GetComponent<Enemie>();

        if (enemie != null)
            return true;

        return false;
    }
}
