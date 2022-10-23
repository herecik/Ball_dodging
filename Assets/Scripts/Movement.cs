using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Movement : MonoBehaviour
{
    float movement_speed = 10f;
    float time_to_move;
    bool in_movement = false;
    int direction;
    Vector3 destination;
    public Camera player_cam;
    RaycastHit hit_info;

    
    // Start is called before the first frame update
    void Start()
    {
        Plane_sc skript_plane_sc = GameObject.FindObjectOfType(typeof(Plane_sc)) as Plane_sc;
        transform.position = new Vector3(skript_plane_sc.scale_x * 5, 0.5f, 0);
        
        player_cam.transform.position = transform.position;
    }

    bool hit(string dir){
        

        switch(dir){
            case "r":
                return Physics.Raycast(transform.position, transform.right, out hit_info, 1f);
            case "l":
                return Physics.Raycast(transform.position, -transform.right, out hit_info, 1f);
            case "f":
                return Physics.Raycast(transform.position, transform.forward, out hit_info, 1f);
            
        }
            
       
        return false;
    }
    // Update is called once per frame
    void Update()
    {
        if(hit("f")){
            GameObject infront = hit_info.collider.gameObject;
            infront.SetActive(false);
            //todo new types of balls doing somthing;
            Plane_sc skript_plane_sc = GameObject.FindObjectOfType(typeof(Plane_sc)) as Plane_sc;
            skript_plane_sc.increase_score(-20f);
           // Debug.Log("GameOver");
        }

        while(true){
            if(in_movement){
                time_to_move -= Time.deltaTime;
                if(time_to_move <= 0){
                        transform.position = destination;
                        in_movement = false;
                                      
                }
                else{
                    transform.position += Time.deltaTime * transform.right * movement_speed * direction;
                    break;
                }
            }


            if(Input.GetKey("d")){
                if(!hit("r")){
                    destination = transform.position +  transform.right;
                    in_movement = true;
                    time_to_move = 1f/movement_speed;
                    direction = 1;
                }
                else
                    Debug.Log("HitR");
            }
            if(Input.GetKey("a")){
                if(!hit("l")){
                    destination = transform.position - transform.right;
                    in_movement = true;
                    time_to_move = 1f/movement_speed;
                    direction = -1;
                }
                else
                    Debug.Log("HitL");
            }
        break;
        }
       //Camera sync with player
        player_cam.transform.position = transform.position + Vector3.up;

    }
}
