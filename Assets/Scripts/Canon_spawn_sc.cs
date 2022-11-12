using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Canon_spawn_sc : MonoBehaviour
{
    // Start is called before the first frame update
    int scz;
    int scx;
    public GameObject canon_prefab;
    
    void Start()
    {
        Plane_sc skript_plane_sc = GameObject.FindObjectOfType(typeof(Plane_sc)) as Plane_sc;
        scz = skript_plane_sc.scale_z;
        scx = skript_plane_sc.scale_x;
        Debug.Log(skript_plane_sc.scale_x);
        for(int x = 1; x < (scx * 10) - 1 ; x++){
            Instantiate(canon_prefab, new Vector3(x, 5f, scz * 10 + 1.5f), Quaternion.Euler(new Vector3(90,0,0)));
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
