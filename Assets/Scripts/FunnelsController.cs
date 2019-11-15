using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FunnelsController : Singleton<FunnelsController>
{
    public Funnel[] allFunnels;

    List<int> checkedRepeat = new List<int>();

    private void Start()
    {
        SpawnRandomFunnels();
    }

    public void MissFigure()
    {
        SpawnRandomFunnels();
        for (int i = 0; i < allFunnels.Length; i++)
        {
            allFunnels[i].OnTouchFigure();
        }
    }

    public void SpawnRandomFunnels()
    {
        FigureType value;
        bool notHaveFigure = false;

        for (int i = 0; i < allFunnels.Length; i++)
        {
            value = (FigureType)Random.Range(0, 5);
            checkedRepeat.Add((int)value);
            allFunnels[i].SetType(value);
        }

        int typeValue = (int)Cannon.Instance.FigurePrefab.Type;
        for (int i = 0; i < checkedRepeat.Count; i++)
        {
            if(checkedRepeat[i] == typeValue)
            {
                notHaveFigure = true;
                break;
            }
        }

        if (!notHaveFigure)
        {
            allFunnels[Random.Range(0, allFunnels.Length)].SetType((FigureType)typeValue);
            Debug.Log((FigureType)typeValue);
        }

        checkedRepeat.Clear();
    }
    

    public void RefreshFunnels(int count)
    {
        if (count > allFunnels.Length) return;

        
    }
}
