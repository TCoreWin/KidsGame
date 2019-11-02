using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Figure : MonoBehaviour
{
    FigureType type;
    public Sprite sprite;

    private void Awake()
    {
        sprite = GetComponent<SpriteRenderer>().sprite;
    }

    public Sprite Sprite { get { return sprite; } private set { } }
    public FigureType Type { get {return type;} private set { } }
}
