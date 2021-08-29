using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RayFire;

public class Buttons : MonoBehaviour
{
    public SliceControl slice;
    bool sliceActive = false;
    bool cameraActive = true;
    bool demolishActive = false;
    public CameraRotate rotate;
    public RayfireRigid cube;
    public GameObject obj;
    public DemolishControl demolish;
    public void Start()
    {
        slice.enabled = sliceActive;
        rotate.enabled = cameraActive;
        demolish.enabled = demolishActive;
    }
    // Start is called before the first frame update
    public void Restart()
    {
        GameObject parts = GameObject.Find("Cube_root");
        if (parts != null)
        {
            Destroy(parts);
        }
        obj.SetActive(true);
        cube.ResetRigid();
    }
    public void SliceControl()
    {
        sliceActive = !sliceActive;
        slice.enabled = sliceActive;
    }
    public void CameraControl()
    {
        cameraActive = !cameraActive;
        rotate.enabled = cameraActive;
    }
    public void DemolishControl()
    {
        demolishActive = !demolishActive;
        demolish.enabled = demolishActive;
    }

}
