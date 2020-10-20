using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetOutliner : MonoBehaviour
{
    [SerializeField]
    private Material firstMaterial;

    [SerializeField]
    private Material secondMaterial;
    // Update is called once per frame
    void Update()
    {
        Debug.Log('1');
     if(Input.GetKey(KeyCode.A)){
        Debug.Log("Pressed");
        gameObject.GetComponent<Renderer>().sharedMaterial.SetFloat("_Thickness", 2);
        gameObject.GetComponent<Renderer>().material = secondMaterial;
     }
    }
    private void Start() {
        secondMaterial = Resources.Load<Material>("Materials/whiteOutliner");
        MeshRenderer meshRenderer = GetComponent<MeshRenderer>();
        firstMaterial = meshRenderer.material;
    }

    private void setOutline (string color, int mode, bool precomputed, float width){
        var outline = gameObject.AddComponent<Outline>();
        // outline.PrecomputeOutline = true;
        outline.OutlineMode = Outline.Mode.OutlineAll;
        outline.OutlineColor = Color.yellow;
        outline.OutlineWidth = 5f;
    }
}
