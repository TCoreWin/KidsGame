using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FiguresController : Singleton<FiguresController>
{
    public Figure[] figures;

    private void Start()
    {
        
    }

    public Figure GetRandomFigure()
    {
        var value = Random.Range(0, figures.Length);
        return figures[value];
    }
}
