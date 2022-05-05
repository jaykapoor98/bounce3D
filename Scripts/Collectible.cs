using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Collectible : MonoBehaviour
{
    public float degreesPerSecond = 30.0f;
    Collider m_objectCollider;
    public Text scoreText;
    // Start is called before the first frame update
    void Start()
    {
        m_objectCollider = GetComponent<Collider>();
    }
    
    // Update is called once per frame
    void Update()
    {
        gameObject.transform.Rotate(degreesPerSecond * Time.deltaTime * 10, degreesPerSecond * Time.deltaTime * 10, 0.0f);
        
    }

    private void OnTriggerEnter()
    {
        Score.instance.AddPoint();
        Destroy(gameObject);
    }
}
