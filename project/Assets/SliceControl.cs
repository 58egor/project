using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliceControl : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject knife;
    private Camera cam;
    private bool cut = false;
    private bool cutCut = false;
    private Vector3 mouseStart;
    private Vector3 mouseEnd;
    public float speed=20;
    void Start()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (cutCut)
        {
            Debug.Log("Move");
            if (Vector3.Distance(knife.transform.position, mouseEnd) > 0.1f)
            {
                knife.transform.position = Vector3.MoveTowards(knife.transform.position, mouseEnd, Time.deltaTime * speed);
            }
            else
            {
                cutCut = false;
            }
            //if(knife.transform.position)
        }
    }
    void Update()
    {
        Vector3 pointStart = new Vector3();
        Vector3 point2 = new Vector3();
        if(Input.GetKeyDown(KeyCode.Mouse0) && !cut && !cutCut)
        {
            Debug.Log("Start");
            mouseStart = Input.mousePosition;
            cut = true;
        }
        if(Input.GetKeyUp(KeyCode.Mouse0) && cut && !cutCut)
        {
            Debug.Log("end");
            mouseEnd = Input.mousePosition;
            cut = false;
            cutCut = true;
            point2 = cam.WorldToScreenPoint(knife.transform.position);
            pointStart = cam.ScreenToWorldPoint(new Vector3(mouseStart.x, mouseStart.y, point2.z));
            mouseEnd = cam.ScreenToWorldPoint(new Vector3(mouseEnd.x, mouseEnd.y, point2.z));
            knife.transform.position = pointStart;
            float rotx = 0;
            knife.transform.LookAt(mouseEnd);
            if (pointStart.x < mouseEnd.x)
            {
                rotx = knife.transform.rotation.eulerAngles.x;
            }
            else
            {
                rotx = -knife.transform.rotation.eulerAngles.x;
            }
            knife.transform.rotation = Quaternion.Euler(new Vector3(rotx+90, 90, -90));
        }
        //if (cutCut)
        //{
        //    Debug.Log("Move");
        //    knife.transform.position= Vector3.MoveTowards(knife.transform.position, pointEnd, Time.deltaTime*speed);
        //    //if(knife.transform.position)
        //}
        //if (Input.GetKey(KeyCode.Mouse0))
        //{
        //    mousePos.x = Input.mousePosition.x;
        //    mousePos.y = Input.mousePosition.y;
        //    point2 = cam.WorldToScreenPoint(knife.transform.position);
        //    point = cam.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, point2.z));
        //    knife.transform.position = point;
        //}
    }
    private void OnDisable()
    {
        knife.SetActive(false);
    }
    private void OnEnable()
    {
        knife.SetActive(true);
    }
}
