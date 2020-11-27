using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.SceneManagement;

public class PlayerData : Singleton<PlayerData>
{

    public float memoryTime= 10;
    public float ecoRange = 10;
    public float timeLeft = 100;
    public string[] toFind;
    public bool isHurt = false;

    public void NewLevel(float levelMemoryTime, float levelEcoRange, int levelTimeLeft, int sceneIndex )
    {
        this.memoryTime = levelMemoryTime;
        this.ecoRange = levelEcoRange;
        this.timeLeft = levelTimeLeft;

        SceneManager.LoadScene(sceneIndex, LoadSceneMode.Single);
    }

    private void Update()
    {
        this.timeLeft -= Time.deltaTime;
    }

    public void Hurt()
    {
        this.timeLeft -= 10;
        isHurt = true;
        StartCoroutine(Healing());
    }

    public bool PickElement(string el)
    {
        int index = Array.IndexOf(this.toFind, el);
        if(index >= 0)
        {
            this.toFind = this.toFind.Where((val, idx) => idx != index).ToArray();

            return true;
        }

        return false;
    }

    IEnumerator Healing()
    {
        yield return new WaitForSeconds(2.0f);
        isHurt = false;
    }
}
