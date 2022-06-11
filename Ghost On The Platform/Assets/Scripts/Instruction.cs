using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instruction : MonoBehaviour
{
    Vector2 _startPosition;
    Rigidbody2D _rigidbody2D;

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _startPosition = _rigidbody2D.position;
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(HideInstruction());
    }

    IEnumerator HideInstruction()
    {
        yield return new WaitForSeconds(4);
        gameObject.SetActive(false);
    }
}
