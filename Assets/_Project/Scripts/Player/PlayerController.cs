using UnityEngine;
using static UnityEngine.EventSystems.StandaloneInputModule;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _speed = 6.0f;
    [SerializeField] private float _smooth = 10f;
    [SerializeField] private float _jumpForce = 5f;
    
    [SerializeField] private float _mouseSensitivityX = 180f; 

    private float _mouseX;

    private Rigidbody _rb;
    private Mover _mover;
    private Rotator _rotator;
    private PlayerShootController _shooter;
    
    private Camera _cam;
    private Ray _ray;

    private float v, h;

    private Vector3 move;

    private bool isJump = false;
    private bool isDoubleJump = false;
    private bool isDoubleJumpUsed = false;

    private bool isAlive = true;
    public bool isGrounded = false;

    private bool isRunning = false;

    private void Awake()
    {
        if (_mover == null) _mover = GetComponent<Mover>();
        if (_rotator == null) _rotator = GetComponent<Rotator>();
        if (_shooter == null) _shooter = GetComponent<PlayerShootController>();
        if (_rb == null) _rb = GetComponent<Rigidbody>();

        _cam = Camera.main;
    }
    private void Update()
    {
        CheckInput();
        CheckRun();
        CheckJump();
        CheckFire();

        CheckMouseLook();

        if (isGrounded)
        {
            isDoubleJump = false;
            isDoubleJumpUsed = false;
        }
    }

    private void FixedUpdate()
    {
        Move();
        Rotation();

        if (isJump) Jump();
        if (isDoubleJump) Jump();
    }

    private void CheckInput()
    {
        if (!isAlive) return;

        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");

        Vector3 inputMove = new Vector3(h, 0, v);
        move = Vector3.Lerp(move, inputMove, _smooth * Time.deltaTime);
        
        //Vector3 inputMove = transform.forward * v + transform.right * h;
       
        move = Vector3.Lerp(move, inputMove, _smooth * Time.deltaTime);

    }

    private void CheckRun()
    {
        if (!isAlive) return;

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            isRunning = true;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            isRunning = false;
        }
    }

    private void CheckJump()
    {
        if (!isAlive) return;

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            isJump = true;
        }
        if (Input.GetButtonDown("Jump") && !isGrounded)
        {
            if (!isDoubleJumpUsed)
            {
                isDoubleJump = true;
                isDoubleJumpUsed = true;
            }
        }
    }

    private void CheckFire()
    {
        if (!isAlive) return;

        //if (_shooter != null)
        //{
        //    if (Input.GetButtonDown("Fire1"))
        //    {
        //        Vector3 mouseScreenPosition = Input.mousePosition;
        //        mouseScreenPosition.z = -_cam.transform.position.z;
        //        Vector3 mouseWorldPosition = _cam.ScreenToWorldPoint(mouseScreenPosition);
        //        Vector3 shootDirection = mouseWorldPosition - transform.position;
        //        if (shootDirection != Vector3.zero) shootDirection.Normalize();
        //        _shooter.TryToShoot(shootDirection);
        //    }
        //}

        if (_shooter != null)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                Ray _ray = _cam.ScreenPointToRay(Input.mousePosition);
                _shooter.TryToShootRay(_ray);
            }
        }
    }

    private void CheckMouseLook()
    {
        if (!isAlive) return;

        _mouseX = Input.GetAxis("Mouse X");
        float yaw = _mouseX * _mouseSensitivityX * Time.deltaTime;

        transform.Rotate(0f, yaw, 0f, Space.World);
    }

    private void Move()
    {
        if (!isAlive) return;

        if (_mover != null)
        {
            if (isRunning)
            {
                _mover.SetSpeed(_speed * 2);
                _mover.SetAndNormalizeInput(move);
            }
            else
            {
                _mover.SetSpeed(_speed);
                _mover.SetAndNormalizeInput(move);
            }
        }
    }

    private void Rotation()
    {
        if (!isAlive) return;

        if (_rotator != null) _rotator.SetRotation(move);
    }

    private void Jump()
    {
        if (!isAlive) return;

        isJump = false;
        isDoubleJump = false;
        if (isRunning) isRunning = false;
        _rb.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
    }

}
