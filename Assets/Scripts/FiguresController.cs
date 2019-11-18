using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FiguresController : Singleton<FiguresController>
{
    public Figure[] figures;
    public Dictionary<int, Sprite> figuresSprite = new Dictionary<int, Sprite>();

    public int CountFigure {
        get{ return figures.Length; }
        private set { }
    }

    private void Awake()
    {
        InitializeDicType();
    }

    public Figure GetRandomFigure()
    {
        var value = Random.Range(0, figures.Length);
        return figures[value];
    }

    void InitializeDicType()
    {
        for (int i = 0; i < figures.Length; i++)
        {
            figuresSprite.Add((int)figures[i].Type, figures[i].Sprite);
        }
    }

    public Sprite GetSpriteToType(FigureType type)
    {
        Sprite sprite;

        if (figuresSprite.TryGetValue((int)type, out sprite))
            return sprite;
        return null;
    }
}
