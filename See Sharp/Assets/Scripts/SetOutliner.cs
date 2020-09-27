using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetOutliner : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
    var outline = gameObject.AddComponent<Outline>();
    outline.OutlineMode = Outline.Mode.OutlineAll;
    outline.OutlineColor = Color.yellow;
    outline.OutlineWidth = 5f;
    }
}
