using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plane_sc : MonoBehaviour
{
    public GameObject ball_prefab;
    public GameObject border_prefab;
    public int scale_x = 2;
    public int scale_z = 5;
    // Start is called before the first frame update
    void Start()
    {
        transform.localScale = new Vector3(scale_x, 1, scale_z);
        transform.position = new Vector3(0, 0, scale_z * 5);
        Instantiate(border_prefab, new Vector3((-scale_x * 5), 0.5f, 2), Quaternion.identity);
        Instantiate(border_prefab, new Vector3((scale_x * 5), 0.5f, 2), Quaternion.identity);
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("m")){
            GameObject new_ball = Instantiate(ball_prefab, new Vector3(Random.Range((-scale_x * 5) + 1 ,(scale_x * 5) - 1), 0.5f, scale_z * 5), Quaternion.identity);

            
            Debug.Log("Spwned ball: " + new_ball);
        }
        
    }
}
