using System;
using UnityEngine;

public class InputReader : MonoBehaviour
{
    private const string MouseX = "Mouse X";
    private const string MouseY = "Mouse Y";
    private const string VerticalAxis = "Vertical";
    private const string HorizontalAxis = "Horizontal";

    private Vector2 _move;
    private Vector2 _look;

    public event Action Pausing;
    public event Action Jumping;
    public event Action Attacking;
    public event Action<Vector2> Moving;
    public event Action<Vector2> MouseMoving;
    
    private bool _isActive;
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            Pausing?.Invoke();
        
        if (_isActive == false)
            return;
        
        _move = new Vector2(Input.GetAxisRaw(VerticalAxis), Input.GetAxisRaw(HorizontalAxis));
        _look = new Vector2(Input.GetAxis(MouseX), Input.GetAxis(MouseY));

        if (_move != Vector2.zero)
            Moving?.Invoke(_move);

        if (_look != Vector2.zero)
            MouseMoving?.Invoke(_look);

        if (Input.GetKeyDown(KeyCode.Space))
            Jumping?.Invoke();

        if (Input.GetMouseButtonDown(0))
            Attacking?.Invoke();
    }

    public void BlockInput()
    {
        _isActive = false;
    }
    
    public void UnlockInput()
    {
        _isActive = true;
    }
}