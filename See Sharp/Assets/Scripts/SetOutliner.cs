using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetOutliner : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
    
    }

    private void setOutline (string color, int mode, bool precomputed, float width){
        var outline = gameObject.AddComponent<Outline>();
        // outline.PrecomputeOutline = true;
        outline.OutlineMode = Outline.Mode.OutlineAll;
        outline.OutlineColor = Color.yellow;
        outline.OutlineWidth = 5f;
    }
}
