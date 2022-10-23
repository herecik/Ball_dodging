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
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(0, 0.5f, 0);
        player_cam.transform.position = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
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
                destination = transform.position +  transform.right;
                in_movement = true;
                time_to_move = 1f/movement_speed;
                direction = 1;
            }
            if(Input.GetKey("a")){
                destination = transform.position - transform.right;
                in_movement = true;
                time_to_move = 1f/movement_speed;
                direction = -1;
            }
        

        
        break;
        }
       //Camera sync with player
        player_cam.transform.position = transform.position;

    }
}
