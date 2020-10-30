using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateEco : MonoBehaviour
{
    // Start is called before the first frame update
    private Vector3 scaled;

    public float maxRadius;
    private SphereCollider myCollider;
    void Start()
    {
        scaled = new Vector3(5f,5f,5f);
        myCollider = gameObject.GetComponent<SphereCollider>();
        myCollider.radius = 0.5f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
           StartCoroutine(CreatingEco()); 
        }
    }

    IEnumerator CreatingEco(){
        myCollider.radius += maxRadius;
        yield return new WaitForSeconds(1);
        myCollider.radius -= maxRadius;
    }
}
