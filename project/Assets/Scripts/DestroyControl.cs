using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RayFire;
public class DestroyControl : MonoBehaviour
{
    // Start is called before the first frame update
    private RayfireShatter shatter;
    public GameObject cube;//объект над которым проводим операции
    void Start()
    {
        shatter = cube.GetComponent<RayfireShatter>();//получаем доступ к элемента объекта
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))//если нажали на мышь
        {
            if (cube.activeSelf)
            {
                shatter.Fragment();//то режим объект на кубики
                cube.SetActive(false);//прячем изначальный объект
            }
            
        }
    }
    public void GetObj(GameObject obj) {//получаем информацию о новом объектк после перезапуска
        cube = obj;
        shatter = cube.GetComponent<RayfireShatter>();
    }
}
