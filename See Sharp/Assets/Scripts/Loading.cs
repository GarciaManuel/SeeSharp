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
            PlayerData.Instance.NewLevel(2 , 4, 90, 2);
        }
        else if (previousScene == 1)
        {
            PlayerData.Instance.NewLevel(6, 10, 180, 3);
        } else if (previousScene == 2)
        {
            Debug.Log("Pantalla de victoria");
            SceneManager.LoadScene(5, LoadSceneMode.Single);
        }

    }

}
