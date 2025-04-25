using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Player : BaseCounter
{
    // Start is called before the first frame update
    public static Player Instance { private set; get; } 
    [SerializeField] private float speed;
    [SerializeField] private PlayerInputes playerInputes;
    BaseCounter selectedCounter;

    private bool isWalking;
    bool canMove;
    Vector3 lastPosition;
    Vector3 moveDir;
    public event EventHandler<OnSelectedCounterEventArgs> OnSelectedCounter;
    public class OnSelectedCounterEventArgs
    {
        public BaseCounter selectedCounter;
    }
    private void Awake()
    {
        if (Instance != null)
        {
            Instance = null;
        }
        Instance = this;
    }


    void Start()
    {
        playerInputes.onInteract += PlayerInputes_onInteract;
        playerInputes.onAltInteract += PlayerInputes_onAltInteract;
    }

    private void PlayerInputes_onAltInteract(object sender, EventArgs e)
    {
        if (selectedCounter != null)
        {
            selectedCounter.AltInteract(this);
        }
    }

    private void PlayerInputes_onInteract(object sender, System.EventArgs e)
    {
        if (selectedCounter != null)
        {
            selectedCounter.Interact(this);
        }
    }

    private void HandleIntractions()
    {
        if (Physics.Raycast(transform.position + 0.2f * Vector3.up, lastPosition, out RaycastHit hitInfo, 2f))
        {
            if (hitInfo.transform.TryGetComponent(out BaseCounter baseCounter))
            {
                if (baseCounter != selectedCounter)
                {

                    HandleSelectedCounter(baseCounter);
                }
            }
            else
            {
                HandleSelectedCounter(null);
            }
        }
        else
        {
            HandleSelectedCounter(null);
        }
    }

    // Update is called once per frame
    void Update()
    {
        HandleMovement();
        HandleIntractions();
    }

    private void HandleMovement()
    {
        Vector2 movement = playerInputes.Movement();
        moveDir = new Vector3(movement.x, 0, movement.y);
        isWalking = moveDir != Vector3.zero;
        transform.forward = Vector3.Slerp(transform.forward, moveDir, speed * Time.deltaTime);
        canMove = !Physics.CapsuleCast(transform.position, transform.position + 2f * Vector3.up, 0.7f, moveDir, speed * Time.deltaTime);
        if (moveDir != Vector3.zero)
        {
            lastPosition = moveDir;
        }
        if (!canMove)
        {
            Vector3 moveDirX = new Vector3(moveDir.x, 0, 0);
            canMove = !Physics.CapsuleCast(transform.position, transform.position + 2f * Vector3.up, 0.7f, moveDirX, speed * Time.deltaTime);
            if (canMove)
            {
                moveDir = moveDirX;
            }
            else
            {
                Vector3 moveDirY = new Vector3(0, 0, moveDir.y);
                canMove = !Physics.CapsuleCast(transform.position, transform.position + 2f * Vector3.up, 0.7f, moveDirY, speed * Time.deltaTime);
                if (canMove)
                {
                    moveDir = moveDirY;
                }
            }


        }

        if (canMove)
        {
            transform.position += moveDir * Time.deltaTime * speed;
        }
    }

    public bool IsWalking()
    {
        return isWalking;
    }
    private void HandleSelectedCounter(BaseCounter baseCounter)
    {
        selectedCounter = baseCounter;
        OnSelectedCounter?.Invoke(this, new OnSelectedCounterEventArgs()
        {
            selectedCounter = selectedCounter,
        });


    }
    


}
