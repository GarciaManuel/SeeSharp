using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Loading : MonoBehaviour
{
    private int previousScene = 0;

    void Start()
    {
        previousScene = PlayerPrefs.GetInt("Scene");
        StartCoroutine(NextScene());
    }

    IEnumerator NextScene()
    {
        yield return new WaitForSeconds(0.5f);
        if (previousScene == 0)
        {
            string[] objects = { "Cama", "Mesa de noche","Botella" };
            PlayerData.Instance.NewLevel(10 , 10, 10000, objects, 2);
        }
        else if (previousScene == 1)
        {
            string[] objects = { "Tres" };
            PlayerData.Instance.NewLevel(100, 100, 200, objects, 3);

        } else if (previousScene == 2)
        {
            Debug.Log("Pantalla de victoria");
        }
    }
}
