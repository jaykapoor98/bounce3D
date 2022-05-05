using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Speed_PowerUp : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(gameObject.tag);
    }

    private void OnTriggerEnter(Collider other){
        if(other.CompareTag("Player"))
        {
            other.gameObject.GetComponent<Controller>().playerSpeed += 5.0f;
        }
        else{
            Debug.Log("Nacho");
        }
        Destroy(gameObject);
    }

}
