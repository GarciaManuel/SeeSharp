using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.SceneManagement;

public class PlayerInput : MonoBehaviour, IInput
{
    public Action<Vector2> OnMovementInput { get; set; }
    public Action<Vector3> OnMovementDirectionInput { get; set; }

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
        Vector2 input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        OnMovementInput?.Invoke(input);
    }
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        Debug.Log(hit.gameObject.name + hit.gameObject.tag);


        switch (hit.gameObject.tag)
        {
            case "Good":
                Debug.Log("Entro a geaaeaeaeood");
                if (PlayerData.Instance.toFind == null || PlayerData.Instance.toFind.Length == 0)
                {
                    Debug.Log("Entro a good");

                    PlayerPrefs.SetInt("Scene", 0);
                    SceneManager.LoadScene(1, LoadSceneMode.Single);
                }
                break;

            case "Bad":
                Debug.Log("Entro a adddddd");
                PlayerData.Instance.Hurt(10);
                break;

            case "Interact":
                Debug.Log("Entro a eeaeae");
                if (PlayerData.Instance.toFind != null && PlayerData.Instance.toFind.Length >= 0)
                {
                    Debug.Log("Entro Interact");

                    int index = Array.IndexOf(PlayerData.Instance.toFind, hit.gameObject.name);
                    if (index >= 0)
                    {
                        Debug.Log("Entro a desactivar");

                        PlayerData.Instance.toFind.Where((val, idx) => idx != index).ToArray();
                        hit.gameObject.SetActive(false);

                    }
                }
                break;
        }
    }


   /* private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.tag + collision.gameObject.name);

        switch (collision.gameObject.tag)
        {
            case "Good":
                Debug.Log("Entro a geaaeaeaeood");
                if (PlayerData.Instance.toFind == null || PlayerData.Instance.toFind.Length == 0)
                {
                    Debug.Log("Entro a good");

                    PlayerPrefs.SetInt("Scene", 0);
                    SceneManager.LoadScene(1, LoadSceneMode.Single);
                }
                break;

            case "Bad":
                Debug.Log("Entro a adddddd");
                PlayerData.Instance.Hurt(10);
                break;

            case "Interact":
                Debug.Log("Entro a eeaeae");
                if (PlayerData.Instance.toFind != null && PlayerData.Instance.toFind.Length >= 0)
                {
                    Debug.Log("Entro Interact");

                    int index = Array.IndexOf(PlayerData.Instance.toFind, collision.gameObject.name);
                    if(index >= 0)
                    {
                        Debug.Log("Entro a desactivar");

                        PlayerData.Instance.toFind.Where((val, idx) => idx != index).ToArray();
                        collision.gameObject.SetActive(false);

                    }
                }
                break;
        }
    }*/
}
