using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private int moveSpeed = 10;
    [SerializeField] private float leftBoundPadding;
    [SerializeField] private float rightBoundPadding;
    [SerializeField] private float topBoundPadding;
    [SerializeField] private float bottomBoundPadding;
    
    private InputAction _moveAction;
    private InputAction _fireAction;
    private Vector3 _moveVector;
    private Vector2 _minBounds;
    private Vector2 _maxBounds;
    private Shooter _playerShooter;
    
    private void Start()
    {
        _playerShooter = GetComponent<Shooter>();
        _moveAction = InputSystem.actions["Move"];
        _fireAction = InputSystem.actions["Fire"];
        InitBounds();
    }

    private void Update()
    {
        MovePlayer();
        Fire();
    }

    private void InitBounds()
    {
        var mainCamera = Camera.main;
        _minBounds = mainCamera.ViewportToWorldPoint(new Vector3(0, 0, mainCamera.nearClipPlane));
        _maxBounds = mainCamera.ViewportToWorldPoint(new Vector3(1, 1, mainCamera.nearClipPlane));
    }

    private void MovePlayer()
    {
        _moveVector = _moveAction.ReadValue<Vector2>();
        var newPosition = transform.position + _moveVector * (moveSpeed * Time.deltaTime);
        newPosition.x = Mathf.Clamp(newPosition.x, _minBounds.x + leftBoundPadding, _maxBounds.x - rightBoundPadding);
        newPosition.y = Mathf.Clamp(newPosition.y, _minBounds.y + bottomBoundPadding, _maxBounds.y - topBoundPadding);
        transform.position = newPosition;
    }

    private void Fire()
    {
        _playerShooter.IsFiring = _fireAction.IsPressed();
    }
}
