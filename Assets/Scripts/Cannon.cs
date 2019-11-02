using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : Singleton<Cannon>
{
    public Transform muzzleRotatePoint;
    public Transform aimPoint;
    public TrajectoryRenderer tr;
    public SpriteRenderer spriteRendererFigure;

    Rigidbody2D figure;
    Figure figurePrefab;
    float power = 2f;
    Vector3 speed;

    List<GameObject> allFigures = new List<GameObject>();

    private void Start()
    {
        CreateFigure();
    }

    private void CreateFigure()
    {
        figurePrefab = FiguresController.Instance.GetRandomFigure();
        figure = Instantiate(figurePrefab).GetComponent<Rigidbody2D>();
        spriteRendererFigure.sprite = figure.GetComponent<Figure>().sprite;
        figure.gameObject.SetActive(false);

        allFigures.Add(figure.gameObject);
    }

    void Update()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //угол между вектором от объекта к мыше и осью х
        var angle = Vector2.Angle(Vector2.right, mousePos - (Vector2)muzzleRotatePoint.position);
        muzzleRotatePoint.eulerAngles = new Vector3(0, 0, muzzleRotatePoint.position.y<mousePos.y?angle:-angle);

        
        if (Input.GetMouseButton(0))
        {
            speed = (mousePos - (Vector2)aimPoint.position) * power;
            tr.ShowTrajectory(aimPoint.position, speed);
        }
        if (Input.GetMouseButtonUp(0))
        {
            //Rigidbody2D figure = Instantiate(figurePrefab, aimPoint.position, Quaternion.identity).GetComponent<Rigidbody2D>();
            figure.gameObject.SetActive(true);
            figure.transform.position = aimPoint.position;
            figure.AddForce(figure.mass * speed / Time.fixedDeltaTime);
            tr.ClearTrajectory();
            RefreshFigurePrefab();
        }        
    }

    void RefreshFigurePrefab()
    {
        CreateFigure();
    }

    public void ClearAllPref()
    {
        for (int i = 0; i < allFigures.Count; i++)
        {
            Destroy(allFigures[i]);
        }

        allFigures.Clear();
    }
}
