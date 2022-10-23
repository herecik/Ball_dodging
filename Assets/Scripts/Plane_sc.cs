using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plane_sc : MonoBehaviour
{
    public GameObject ball_prefab;
    public GameObject border_prefab;

    public Canvas my_canvas;
    public int scale_x = 2;
    public int scale_z = 5;
    public int spawn_rate = 200;
    int cnt = 0;
    float score = 0f;
    int[] used_x_spawns;
    // Start is called before the first frame update
    void Start()
    {
        transform.localScale = new Vector3(scale_x, 1, scale_z);
        transform.position = new Vector3(scale_x * 5, 0, scale_z * 5);
        Instantiate(border_prefab, new Vector3(0, 0.5f, 2), Quaternion.identity);
        Instantiate(border_prefab, new Vector3(scale_x * 10, 0.5f, 2), Quaternion.identity);
        used_x_spawns = new int[scale_x * 10];
    }

    int get_quantity_to_spawn(){
        return Random.Range(1, scale_x *5);
    }

    public void increase_score(float multiplier){
        UnityEngine.UI.Text score_output = my_canvas.GetComponent<UnityEngine.UI.Text>();
        score += 10 * multiplier;

        score_output.text = $"Score : {score}";
    }

    // Update is called once per frame
    void Update()
    {   
        //Debug.Log(Time.frameCount);
        if(cnt >= spawn_rate){
            for(int x = 0; x < get_quantity_to_spawn(); x++){
                int random_value_x = Random.Range(1, (scale_x * 10) - 1);
                
                if(used_x_spawns[random_value_x] != 1){
                    GameObject new_ball = Instantiate(ball_prefab, new Vector3(random_value_x, 5f, scale_z * 10), Quaternion.identity);
                    used_x_spawns[random_value_x] = 1;
                }
            }
            used_x_spawns = new int[scale_x * 10];
            cnt = 0;
        }
        cnt++;       
    }
}
