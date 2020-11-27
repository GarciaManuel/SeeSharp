using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RestartGame : MonoBehaviour
{
	public void Start()
	{
		StartCoroutine(Restart());
	}


	public IEnumerator Restart()
    {
		yield return new WaitForSeconds(3.0f);
		SceneManager.LoadScene(0, LoadSceneMode.Single);
	}
}