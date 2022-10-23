using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Movement : MonoBehaviour
{
    float movement_speed = 10f;
    float time_to_move;
    bool in_movement = false;
    bool on_the_edge = false;
    int direction;
    Vector3 destination;
    public Camera player_cam;

    
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(0, 0.5f, 0);
        player_cam.transform.position = transform.position;
    }

    bool hit(string dir){
        RaycastHit hit_info;

        if(dir == "r")
            return Physics.Raycast(transform.position, transform.right, out hit_info, 1f);
        else if(dir == "l")
            return Physics.Raycast(transform.position, -transform.right, out hit_info, 1f);
        else
            return false;
    }
    // Update is called once per frame
    void Update()
    {
        Plane_sc skript_plane_sc = GameObject.FindObjectOfType(typeof(Plane_sc)) as Plane_sc;
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
