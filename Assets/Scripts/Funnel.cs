using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Funnel : MonoBehaviour
{
    FigureType type;

    public SpriteRenderer spriteRenderer;
    public FigureType Type { get => type; set => type = value; }
    public bool isTouch { get; private set; }


    Animator animator;
    BoxCollider2D boxCollider;

    public void Awake()
    {
        animator = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    public void SetType(FigureType type)
    {
        this.type = type;

        spriteRenderer.sprite = FiguresController.Instance.GetSpriteToType(type);
    }

    public void OnTouchFigure()
    {
        isTouch = true;
        boxCollider.enabled = false;
        StartCoroutine(Reload());
        animator.SetTrigger("Touch");

        SetType((FigureType)Random.Range(0, 5));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GetComponent<Figure>().Type == this.type)
        {
            var collisionPoint = new Vector3(collision.transform.position.x, collision.transform.position.y, -6);
            GameManager.Instance.IncScore(collisionPoint);
            OnTouchFigure();
            FunnelsController.Instance.SpawnRandomFunnels();
        }
        else
        {
            FunnelsController.Instance.MissFigure();
            GameManager.Instance.LoseGame();
        }
        Destroy(collision.gameObject);
    }

    IEnumerator Reload()
    {
        yield return new WaitForSeconds(1f);
        boxCollider.enabled = true;
        isTouch = false;
    }
}
