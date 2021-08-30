using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RayFire;

public class DemolishControl : MonoBehaviour
{
    public GameObject bomb;//сылка на бомбу
    private Camera cam;
    private RayfireBomb bym;//функция бомба
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        bym = bomb.GetComponent<RayfireBomb>();//получаем компнонент бомбы
    }
    // Update is called once per frame
    void Update()
    {
        
        
        if (Input.GetKeyDown(KeyCode.Mouse0))//если нажали мышь
        {
            RaycastHit hit;
            Ray ray=cam.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))//выпускаем луч из камеры в точку нажатия
            {
                Debug.Log("Name:" + hit.collider.name);
                Debug.Log("Pos:" + hit.point);
              bomb.transform.position = hit.point;//если попали по объекту, то передвигаем туда бомбу
              bym.Explode(0);//взрываем бомбу
            }
        }
    }
}
