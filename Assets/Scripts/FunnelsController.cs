using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FunnelsController : Singleton<FunnelsController>
{
    public Funnel[] allFunnels;

    List<int> checkedRepeat = new List<int>();
    List<Funnel> refreshFunnel = new List<Funnel>();
    int RefreshCount { get; set; }

    private void Start()
    {
        SpawnRandomFunnels();
        RefreshCount = 3; 
    }

    public void MissFigure()
    {
        SpawnRandomFunnels();
        for (int i = 0; i < allFunnels.Length; i++)
        {
            allFunnels[i].OnTouchFigure();
        }
    }
    /// <summary>
    /// Меняет тип фигур в воронках
    /// </summary>
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
    /// <summary>
    /// Меняет тип фигур в воронках
    /// </summary>
    /// <param name="funnels">Лист воронок в которых нужно поменять тип фигур</param>
    public void SpawnRandomFunnels(List<Funnel> funnels)
    {
        bool notHaveFigure = false;

        int typeValue = (int)Cannon.Instance.FigurePrefab.Type;
        for (int i = 0; i < checkedRepeat.Count; i++)
        {
            if (checkedRepeat[i] == typeValue)
            {
                notHaveFigure = true;
                break;
            }
        }

        if (!notHaveFigure)
        {
            funnels[Random.Range(0, funnels.Count)].SetType((FigureType)typeValue);
            Debug.Log((FigureType)typeValue);
        }

        checkedRepeat.Clear();
    }

    public void RefreshFunnels(Funnel funnelTouch)
    {
        int count = allFunnels.Length - RefreshCount;

        for (int i = 0; i < allFunnels.Length; i++)
        {
            refreshFunnel.Add(allFunnels[i]);
        }

        while(count > 0)
        {
            int randomValue = Random.Range(0, refreshFunnel.Count);

            if (funnelTouch == refreshFunnel[randomValue]) continue;
            else
            {
                count--;
                refreshFunnel.RemoveAt(randomValue);
            }
        }

        for (int i = 0; i < refreshFunnel.Count; i++)
        {
            refreshFunnel[i].OnTouchFigure();
        }
        SpawnRandomFunnels(refreshFunnel);
        refreshFunnel.Clear();
    }
}
