using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Loading : MonoBehaviour
{
    private int previousScene = 0;
    // Start is called before the first frame update
    void Start()
    {
        previousScene = PlayerPrefs.GetInt("Scene");
        Debug.Log(previousScene);
        StartCoroutine(NextScene());
    }

    IEnumerator NextScene()
    {
        yield return new WaitForSeconds(0.5f);
        if (previousScene == 0)
        {
            string[] objects = { "Bed_COL", "DiningTable_COL" };
            PlayerData.Instance.NewLevel(10 , 10, 100, objects, 2);
        }
        else
        {
            string[] objects = { "Tres"};
            PlayerData.Instance.NewLevel(100, 100, 10, objects, 3);

        }
    }
}
