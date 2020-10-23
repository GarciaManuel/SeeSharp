using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetOutliner : MonoBehaviour
{
    private Renderer render;

    private float thick;
    private bool increase;
    // Update is called once per frame
    void Update()
    {
        Debug.Log('1');
        Debug.Log("Pressed");
        if(thick > 3){
            thick = 3f;
        }
        render.material.SetFloat("_Thickness", thick);
        render.material.SetColor("_Color",new Color(1f,1f,1f,1f));
        // gameObject.GetComponent<Renderer>().material = secondMaterial;
        thick+=0.2f;
     
     if(Input.GetKey(KeyCode.S)){
            render.material.SetFloat("_Thickness", 0.01f);
     }
    }
    private void Start() {
        render = gameObject.GetComponent<Renderer>();
        thick = 0.05f;
    }

    private void setOutline (string color, int mode, bool precomputed, float width){
        var outline = gameObject.AddComponent<Outline>();
        // outline.PrecomputeOutline = true;
        outline.OutlineMode = Outline.Mode.OutlineAll;
        outline.OutlineColor = Color.yellow;
        outline.OutlineWidth = 5f;
    }
}
