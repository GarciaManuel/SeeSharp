using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerInput : MonoBehaviour, IInput
{
    public Action<Vector2> OnMovementInput { get; set; }
    public Action<Vector3> OnMovementDirectionInput { get; set; }
    CharacterController controller;
    bool hurt = false;
    public AudioSource stepSound;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
    private void Update()
    {
        Debug.Log(hurt);

            GetMovementInput();
            GetMovementDirection();


    }
    private IEnumerator StayStill()
    {
        Debug.Log("Entro a strill");
        yield return new WaitForSeconds(2.0f);
        Debug.Log("cambio hurt");

        this.hurt = false;
    }
    private void GetMovementDirection()
    {
        var cameraForewardDirection = Camera.main.transform.forward;
        Debug.DrawRay(Camera.main.transform.position, cameraForewardDirection * 10, Color.red);
        var directionToMoveIn = Vector3.Scale(cameraForewardDirection, (Vector3.right + Vector3.forward));
        Debug.DrawRay(Camera.main.transform.position, directionToMoveIn * 10, Color.blue);
        OnMovementDirectionInput?.Invoke(directionToMoveIn);
    }
    private void PlaySounds(bool moving)
    {
        if (moving)
        {
            stepSound.enabled = true;
            stepSound.loop = true;
        }

        if (!moving)
        {
            stepSound.enabled = false;
            stepSound.loop = false;
        }
    }
    private void GetMovementInput()
    {

        float horizontal = 0;
        float vertical = 0;
        if (this.hurt == false)
        {
            horizontal = Input.GetAxis("Horizontal");
            vertical = Input.GetAxis("Vertical");
        }

        if (horizontal != 0 || vertical != 0)
        {
            PlaySounds(true);
        }
        else
        {
            PlaySounds(false);
        }

        Vector2 input = new Vector2(horizontal, vertical);
        OnMovementInput?.Invoke(input);
    }
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        switch (hit.gameObject.tag)
        {
            case "Good":
                Debug.Log("Colisión con GOOD");
                if (PlayerData.Instance.toFind == null || PlayerData.Instance.toFind.Length == 0)
                {
                    Debug.Log("Entró a good");

                    PlayerPrefs.SetInt("Scene", 1);
                    SceneManager.LoadScene(1, LoadSceneMode.Single);
                }
                break;

            case "Bad":
                Debug.Log("Colisión con BAD");
                PlayerData.Instance.Hurt(10);
                this.hurt = true;
                controller = GetComponent<CharacterController>();
                controller.Move(-transform.forward * 3.0f);
                StartCoroutine(StayStill());

                break;

            case "Interact":
                if (PlayerData.Instance.toFind != null && PlayerData.Instance.toFind.Length >= 0)
                {
                    if(PlayerData.Instance.PickElement(hit.gameObject.name)) {
                        hit.gameObject.SetActive(false);
                    }
                }
                break;
        }
    }

}
