using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Funnel : MonoBehaviour
{
    FigureType type;

    public SpriteRenderer spriteRenderer;
    public FigureType Type { get => type; set => type = value; }

    public void SetType(FigureType type)
    {
        this.type = type;

        spriteRenderer.sprite = FiguresController.Instance.GetSpriteToType(type);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GetComponent<Figure>().Type == this.type)
        {
            var collisionPoint = new Vector3(collision.transform.position.x, collision.transform.position.y, -6);
            GameManager.Instance.IncScore(collisionPoint);
        }
        else
        {
            GameManager.Instance.LoseGame();
        }
        FunnelsController.Instance.SpawnRandomFunnels();
        Destroy(collision.gameObject);
    }
}
