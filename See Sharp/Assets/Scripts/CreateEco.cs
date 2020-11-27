using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateEco : MonoBehaviour
{
    // Start is called before the first frame update
    private Vector3 scaled;
    private bool runningEco = false;

    public float maxRadius;
    private SphereCollider myCollider;
    public AudioSource ecoSound;
    void Start()
    {
        scaled = new Vector3(5f,5f,5f);
        myCollider = gameObject.GetComponent<SphereCollider>();
        myCollider.radius = 0.5f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && (!runningEco))
        {

            runningEco = true;
            ecoSound.enabled = true;
            ecoSound.Play();
           StartCoroutine(CreatingEco()); 
        }
    }

    IEnumerator CreatingEco(){
        yield return new WaitForSeconds(0.2f);
        myCollider.radius = PlayerData.Instance.ecoRange;
        yield return new WaitForSeconds(1);
        myCollider.radius -= PlayerData.Instance.ecoRange;
        runningEco = false;
    }
}
