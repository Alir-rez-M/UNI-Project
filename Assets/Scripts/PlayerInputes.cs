using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputes : MonoBehaviour
{
    // Start is called before the first frame update
    Inputes inputActions;
    public event EventHandler onInteract;
    public event EventHandler onAltInteract;
    void Start()
    {
        inputActions = new Inputes();
        inputActions.Player.Enable();
        inputActions.Player.Interact.performed += Interact_performed;
        inputActions.Player.AltInteract.performed += AltInteract_performed;
    }

    private void AltInteract_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        onAltInteract?.Invoke(this, EventArgs.Empty);
    }

    private void Interact_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        onInteract?.Invoke(this , EventArgs.Empty);
    }

    // Update is called once per frame
    public Vector2 Movement()
    {
        Vector2 movement = inputActions.Player.Move.ReadValue<Vector2>();
        return movement;
    }
}
