using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour, IInput
{
    public Action<Vector2> OnMovementInput { get; set; }
    public Action<Vector3> OnMovementDirectionInput { get; set; }

    public AudioSource step;

    private void Start()
    {
        //To move in the direction of the cinemachine
        Cursor.lockState = CursorLockMode.Locked;
    }
    private void Update()
    {
        GetMovementInput();
        GetMovementDirection();
    }

    private void GetMovementDirection()
    {
        var cameraForewardDirection = Camera.main.transform.forward;
        Debug.DrawRay(Camera.main.transform.position, cameraForewardDirection * 10, Color.red);
        var directionToMoveIn = Vector3.Scale(cameraForewardDirection, (Vector3.right + Vector3.forward));
        Debug.DrawRay(Camera.main.transform.position, directionToMoveIn * 10, Color.blue);
        OnMovementDirectionInput?.Invoke(directionToMoveIn);
    }

    private void GetMovementInput()
    {
        var hori = Input.GetAxis("Horizontal");
        var verti = Input.GetAxis("Vertical");
        Vector2 input = new Vector2(hori, verti);
        if (hori != 0 || verti != 0)
        {
            PlaySounds(true);
            Debug.Log("Caminando");
        }else
        {
            PlaySounds(false);
            Debug.Log("PARADA LA TENGO");
        }

            OnMovementInput?.Invoke(input);
    }
    private void PlaySounds(bool moving)
    {
        if (moving)
        {
            step.enabled = true;
            step.loop = true;
        }

        if (!moving)
        {
            step.enabled = false;
            step.loop = false;
        }
    }
}
