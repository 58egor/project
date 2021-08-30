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
    bool destroyActive = false;
    public CameraRotate rotate;
    public GameObject obj;
    public GameObject newObj;
    public DemolishControl demolish;
    private RayfireShatter shatter;
    public DestroyControl destroy;
    Vector3 pos;
    public void Start()
    {
        shatter = obj.GetComponent<RayfireShatter>();//получаем ссылку на скрипт объекта
        slice.enabled = sliceActive;//активируем функции в соответсвии с начальной настройкой
        rotate.enabled = cameraActive;
        demolish.enabled = demolishActive;
        destroy.enabled = destroyActive;
        pos = obj.transform.position;//запоминаем позицию объекта
    }
    // Start is called before the first frame update
    public void Restart()//кнопка reset
    {
        GameObject parts = GameObject.Find(obj.name + "_root");//находим объект с именем объекта,над которым мы делаем операции, с припиской _root и удаляем его
        Destroy(parts);//и удаляем его
        obj.GetComponent<RayfireShatter>().DeleteFragmentsAll();//удаляем все фрагменты которые сделали с помощью скрипта RayfireShatter
        obj.GetComponent<RayfireRigid>().ResetRigid();//перезапускаем RayfireRigid, что бы удалить детали
        Destroy(obj);//уничтожаем объект
        obj=Instantiate(newObj, pos, Quaternion.identity);//создаем новый
        destroy.GetObj(obj);//передаем скрипту ссылку на новый объект
        rotate.GetObj(obj.transform);//передаем скрипту ссылку на новый объект
        parts = GameObject.Find("RayFireMan");//находим объект с указанным именем
        Destroy(parts);//и удаляем, что бы избавиться от оставшихся деталей
        Debug.Log(obj.name);
    }
    public void SliceControl()//скрипт для кнопки Cut,управляющая функцием порезки объекта
    {
        sliceActive = !sliceActive;
        slice.enabled = sliceActive;
    }
    public void CameraControl()//скрипт для кнопки Rotate, управляющая поворотом камеры
    {
        cameraActive = !cameraActive;
        rotate.enabled = cameraActive;
    }
    public void DemolishControl()//скрипт для кнопки Bricks, управляющая  точненым уничтожением объекта
    {
        demolishActive = !demolishActive;
        demolish.enabled = demolishActive;
    }
    public void DestroyControl()// скрипт для кнопки Destroy,которая режит объект на кубы
    {
        destroyActive = !destroyActive;
        destroy.enabled = destroyActive;
    }

}
