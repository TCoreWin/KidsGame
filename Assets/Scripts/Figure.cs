using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Figure : MonoBehaviour
{
    [SerializeField]
    FigureType type;

    public Sprite sprite;

    public Sprite Sprite { get { return sprite; } private set { } }
    public FigureType Type { get {return type;} private set { } }
}
