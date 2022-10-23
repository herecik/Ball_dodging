using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ball_sc : MonoBehaviour
{

    Rigidbody ball_rigidbody;
    public float force_added = 20f;
    // Start is called before the first frame update
    void Start()
    {
        ball_rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        ball_rigidbody.AddForce(-transform.forward * force_added);
        ball_rigidbody.transform.eulerAngles = new Vector3(0, ball_rigidbody.transform.eulerAngles.y, ball_rigidbody.transform.eulerAngles.z);
        
        if(transform.position.y < 0){
            Debug.Log("Deleting");
            gameObject.SetActive(false);
        }
            
    
    }
}
