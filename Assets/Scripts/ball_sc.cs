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

        if(transform.position.z <= 0){
            Plane_sc skript_plane_sc = GameObject.FindObjectOfType(typeof(Plane_sc)) as Plane_sc;
            skript_plane_sc.increase_score(1f);
            Debug.Log("Deleting");
            gameObject.SetActive(false);
        }
        
        
            
    
    }
}
