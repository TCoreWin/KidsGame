using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    public Transform muzzleRotatePoint;

    void Update()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //угол между вектором от объекта к мыше и осью х
        var angle = Vector2.Angle(Vector2.right, mousePos - (Vector2)muzzleRotatePoint.position);

        muzzleRotatePoint.eulerAngles = new Vector3(0, 0, muzzleRotatePoint.position.y<mousePos.y?angle:-angle);
    }
}
