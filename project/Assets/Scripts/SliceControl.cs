using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliceControl : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject knife;//нож,которы режет наш объект
    private Camera cam;
    private bool cut = false;
    private bool cutCut = false;
    private Vector3 mouseStart;//координата нажатия мыши
    private Vector3 mouseEnd;//координата отпускания мыши
    public float speed=20;//скорость ножа
    public LineRenderer line;//линия показывающая траекторию нарезки
    void Start()
    {
        cam = Camera.main;
        line.positionCount = 2;
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (cutCut)//если пуь был выбран
        {
            Debug.Log("Move");
            if (Vector3.Distance(knife.transform.position, mouseEnd) > 0.1f)//то передвигаем нож пока не достигнем цели
            {
                knife.transform.position = Vector3.MoveTowards(knife.transform.position, mouseEnd, Time.deltaTime * speed);
            }
            else
            {
                cutCut = false;
            }
        }
    }
    void Update()
    {
        Vector3 pointStart = new Vector3();
        Vector3 point2 = new Vector3();
        if(Input.GetKeyDown(KeyCode.Mouse0) && !cut && !cutCut)//если нажали кнопку мыши и не передвигаем нож
        {
            line.enabled = true;
            Debug.Log("Start");
            mouseStart = Input.mousePosition;//запоминаем позицию мыши
            cut = true;//помечаем, что ждем отпусакния мыши 
            point2 = cam.WorldToScreenPoint(knife.transform.position);//переводим кординаты ножа в экранные из мировых,что бы получить z
            line.SetPosition(0, cam.ScreenToWorldPoint(new Vector3(mouseStart.x, mouseStart.y, point2.z)));//перводим координаты мыши в мировые и устанавливаем первую точку линии
           
        }
        if (Input.GetKey(KeyCode.Mouse0))//пока мышь нажата
        {
            point2 = cam.WorldToScreenPoint(knife.transform.position);
            line.SetPosition(1, cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, point2.z)));//изменяем вторую точку линии
        }
        if(Input.GetKeyUp(KeyCode.Mouse0) && cut && !cutCut)//когда кнопку мыши отпустили после нажатия
        {
            line.enabled = false;//прячем линию
            Debug.Log("end");
            mouseEnd = Input.mousePosition;//считываем координату отпускания
            cut = false;
            cutCut = true;
            point2 = cam.WorldToScreenPoint(knife.transform.position);
            pointStart = cam.ScreenToWorldPoint(new Vector3(mouseStart.x, mouseStart.y, point2.z));//переводим координаты нажатия мыши в мировые
            mouseEnd = cam.ScreenToWorldPoint(new Vector3(mouseEnd.x, mouseEnd.y, point2.z));//переводим координаты отпускания мыши в мировые
            knife.transform.position = pointStart;//передвыигаем нож в точку нажатия
            float rotx = 0;
            knife.transform.LookAt(mouseEnd);//нож смотрит на точку отпускания
            if (pointStart.x < mouseEnd.x)//корректируем поворт ножа по оси у
            {
                rotx = knife.transform.rotation.eulerAngles.x;
            }
            else
            {
                rotx = -knife.transform.rotation.eulerAngles.x;
            }
            float koeff = 1;
            if ((180f > cam.transform.rotation.eulerAngles.y && cam.transform.rotation.eulerAngles.y > 90f) || (-90f > cam.transform.rotation.eulerAngles.y && cam.transform.rotation.eulerAngles.y >-180f))
            {
                Debug.Log("chage koeff");
                koeff = -1;
            }
            knife.transform.rotation = Quaternion.Euler( new Vector3((rotx+90)*koeff, 90f+cam.transform.rotation.eulerAngles.y, -90f));//корректируем координаты ножа
        }
    }
    private void OnDisable()
    {
        knife.SetActive(false);//когда скрипт выключается,прячем нож
        cut = false;
        cutCut = false;
    }
    private void OnEnable()
    {
        knife.SetActive(true);//когда скрипт включается,включается и нож
    }
  
}
