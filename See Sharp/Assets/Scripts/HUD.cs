using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    [SerializeField]
    private Text eco;

    [SerializeField]
    private Text memo;

    [SerializeField]
    private Text inventory;

    [SerializeField]
    private Text timeLeft;

    // Start is called before the first frame update
    void Start()
    {
        eco.text = $"Rango de ecolocalización: {PlayerData.Instance.ecoRange} mts";
        memo.text =  $"Memoria: {PlayerData.Instance.memoryTime} s";
        PlayerData.Instance.toFind = GetObjects();

    }

    private string[] GetObjects()
    {
        GameObject[] objTagged = GameObject.FindGameObjectsWithTag("Interact");

        string[] objects = new string[objTagged.Length];
        for (int i = 0; i < objTagged.Length; i++)
        {
            objects[i] = objTagged[i].name;
        }
        Debug.Log(objects.Length);
        return objects;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("update");

        PaintInventory();
        timeLeft.text = $"Tiempo restante: { (int)PlayerData.Instance.timeLeft } s";
    }

    void PaintInventory()
    {
        var inventoryText = "Busca: \n";

        if (PlayerData.Instance.toFind.Length == 0)
        {
            inventoryText += "La salida";
        }
        else
        {
            foreach (string el in PlayerData.Instance.toFind)
            {

                var parsedEl = el;
                inventoryText += parsedEl + "\n";
            }
        }
        
        
        inventory.text = inventoryText;
    }
}
