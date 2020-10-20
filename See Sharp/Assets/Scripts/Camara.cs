using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camara : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnPreRender() {
        GL.wireframe = true;
    }

    private void OnPostRender() {
        GL.wireframe = false;
    }
}
