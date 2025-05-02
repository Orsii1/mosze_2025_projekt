using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

[SelectionBase]
public class Player_Controller : MonoBehaviour
{
    #region Enums
    private enum Directions { UP, DOWN, LEFT, RIGHT }
    #endregion

    #region Editor Data
    [Header("Movement Attributes")]
    [SerializeField] float _moveSpeed = 50f;

    [Header("Dependencies")]
    [SerializeField] Rigidbody2D _rb;
    [SerializeField] Animator _animator;
    [SerializeField] SpriteRenderer _spriteRenderer;
    #endregion

    #region Internal Data
    private Vector2 _moveDir = Vector2.zero;
    private Directions _faceingDirection = Directions.RIGHT;
    #endregion

    #region Tick
    private void Update()
    {
        GatherInput();
        CalculateFacingDirection();
        UpdateAnimation();
    }

    private void FixedUpdate()
    {
        MovementUpadte();
        
    }
    #endregion

    #region Input Logig
    private void GatherInput()
    {
        _moveDir.x = Input.GetAxisRaw("Horizontal");
        _moveDir.y = Input.GetAxisRaw("Vertical");

    }
    #endregion

    #region Movement Logic
    private void MovementUpadte()
    {
        _rb.linearVelocity = _moveDir.normalized * _moveSpeed * Time.fixedDeltaTime; 
    }
    #endregion

    #region Animation Logic
    private void CalculateFacingDirection()
    {
        if(_moveDir.x != 0)
        {
            if (_moveDir.x > 0)
            {
                _faceingDirection = Directions.RIGHT;
            }
            else if (_moveDir.x < 0)
            {
                _faceingDirection = Directions.LEFT;
            }
        }

        Debug.Log(_faceingDirection);
    }

    private void UpdateAnimation()
    {
        if (_faceingDirection == Directions.LEFT)
        {
            _spriteRenderer.flipX = true;
        }
        else if (_faceingDirection == Directions.RIGHT)
        { 
            _spriteRenderer.flipX = false; 
        }
    }

    #endregion

}
