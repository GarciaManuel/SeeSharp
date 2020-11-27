using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetOutliner : MonoBehaviour
{
    private Renderer render;

    private float thick;
    private bool increase;

    private Material[] mats;
    // Update is called once per frame
    
    private void OnTriggerEnter(Collider other) {

        if(other.gameObject.CompareTag("Eco"))
        {
            StartCoroutine(ChangeOutline());
        }

    }         
    
    private void Start() {
        render = gameObject.GetComponent<Renderer>();
        mats = render.materials;
        thick = 0.02f;
        render.material.SetFloat("_Thickness", thick);

        foreach (Material m in mats)
        {
            m.SetColor("_Color", new Color(0f, 0f, 0f, 0f));
        }
    }

    IEnumerator ChangeOutline(){
        
        render.material.SetColor("_Color", new Color(1f, 1f, 1f, 1f));
        while (thick < 3)
        {
            thick += 0.06f;
            foreach (Material m in mats)
            {

                if(gameObject.CompareTag("Neutro")){
                     m.SetColor("_Color", new Color(1f, 1f, 1f, 1f));
                }
                if(gameObject.CompareTag("Bad")){
                     m.SetColor("_Color", new Color(0.902f, 0.29f, 0.23437f, 1f));
                }
                if(gameObject.CompareTag("Good")){
                     m.SetColor("_Color", new Color(0f, 1f, 0.25f, 1f));
                }
                if (gameObject.CompareTag("Interact"))
                {
                    m.SetColor("_Color", new Color(0.7843f, 0.8313f, 0f, 1f));
                }

                m.SetFloat("_Thickness", thick);
            }
            yield return new WaitForSeconds(0.05f);
        }
        yield return new WaitForSeconds(PlayerData.Instance.memoryTime);
        while (thick > 0.02)
        {
            thick -= 0.06f;
            foreach (Material m in mats){
                m.SetFloat("_Thickness", thick);
            }
            
            yield return new WaitForSeconds(0.05f);
        }
        foreach (Material m in mats)
        {
            m.SetColor("_Color", new Color(0f, 0f, 0f, 0f));
        }

        render.material.SetColor("_Color", new Color(0f, 0f, 0f, 0f));

    }

    private void Increase(){
        
        render.material.SetColor("_Color", new Color(1f, 1f, 1f, 1f));
        while(thick <3){
            thick += 0.05f;
            render.material.SetFloat("_Thickness", thick);
        }
        return;
    }

    private void Decrease(){
        
        while (thick > 0.05)
        {
            thick -= 0.02f;
            render.material.SetFloat("_Thickness", thick);
        }
        render.material.SetColor("_Color", new Color(0f, 0f, 0f, 0f));
        return;
    }
}
