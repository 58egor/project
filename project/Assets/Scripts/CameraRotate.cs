using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotate : MonoBehaviour
{
	public Transform target;//цель камеры
	public Vector3 offset;
	public float sensitivity = 3; // чувствительность мышки
	private float X;

	void Start()
	{
		X = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * sensitivity;//рассчитываем новый поворт камеры
		transform.localEulerAngles = new Vector3(transform.rotation.eulerAngles.x, X, 0);//поварачиваем камеру
		transform.position = transform.localRotation * offset + target.position;//изменяем позицию камеры
	}

	void Update()
	{

		if (Input.GetKey(KeyCode.Mouse0))
		{
			X = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * sensitivity;//рассчитываем новый поворт камеры
			transform.localEulerAngles = new Vector3(transform.rotation.eulerAngles.x, X, 0);//поварачиваем камеру
			transform.position = transform.localRotation * offset + target.position;//изменяем позицию камеры
		}
	}
	public void GetObj(Transform obj)//получаем заново объект
    {
		target = obj;
    }
}
