using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RayFire;

public class Buttons : MonoBehaviour
{
    public RayfireRigid cube;
    
    // Start is called before the first frame update
public void Restart()
    {
        GameObject parts = GameObject.Find("Cube_root");
        if (parts != null)
        {
            Destroy(parts);
        }
        cube.ResetRigid();
    }
    
}
