using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.SceneManagement;

public class PlayerData : Singleton<PlayerData>
{

    public float memoryTime;
    public float ecoRange;
    public float timeLeft;
    public string[] toFind;

    public void NewLevel(float levelMemoryTime, float levelEcoRange, int levelTimeLeft, string[] levelToFind, int sceneIndex )
    {
        this.memoryTime = levelMemoryTime;
        this.ecoRange = levelEcoRange;
        this.timeLeft = levelTimeLeft;
        this.toFind = levelToFind;

        SceneManager.LoadScene(sceneIndex, LoadSceneMode.Single);
    }

    private void Update()
    {
        this.timeLeft -= Time.deltaTime;
        if(this.timeLeft <= 0)
        {
            if(SceneManager.GetActiveScene().buildIndex != 4)
                SceneManager.LoadScene(4, LoadSceneMode.Single);
        }
    }

    public void Hurt(int decreaseTime)
    {
        this.timeLeft -= decreaseTime;
        Debug.Log("Hurt, lose time");


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
}
