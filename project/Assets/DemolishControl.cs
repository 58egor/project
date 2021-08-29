using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RayFire;

public class DemolishControl : MonoBehaviour
{
    public GameObject bomb;
    private Camera cam;
    private RayfireBomb bym;
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        bym = bomb.GetComponent<RayfireBomb>();
    }
    // Update is called once per frame
    void Update()
    {
        
        
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            RaycastHit hit;
            Vector3 pos2= cam.WorldToScreenPoint(cam.transform.position);
            //Debug.Log(cam.transform.position);
            //Debug.Log(Input.mousePosition);
            //Vector3 pos= cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,Input.mousePosition.y, pointStart.z));
            //point.transform.position = pos;
            //Ray ray = new Ray(pos, cam.transform.forward);
            Ray ray=cam.ScreenPointToRay(Input.mousePosition);
            //Debug.Log(pos);

            if (Physics.Raycast(ray, out hit))
            {
                //Debug.DrawRay(ray.origin, hit.point, Color.green,30);
                //point.transform.position = hit.point;
                Debug.Log("Name:" + hit.collider.name);
                Debug.Log("Pos:" + hit.point);
              bomb.transform.position = hit.point;
              bym.Explode(0);
            }
        }
    }
}
