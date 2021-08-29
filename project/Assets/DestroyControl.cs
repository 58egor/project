using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RayFire;
public class DestroyControl : MonoBehaviour
{
    // Start is called before the first frame update
    private RayfireShatter shatter;
    public GameObject cube;
    void Start()
    {
        shatter = cube.GetComponent<RayfireShatter>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            shatter.Fragment();
            cube.SetActive(false);
        }
    }
}
