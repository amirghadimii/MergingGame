using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface _ImergeService
{
    public event Action<int, int> MergeValuei_j;
    public void MergeElemet(List<CabinScript> allCabinScripts);
}

public class MergeService : _ImergeService
{
    public event Action<int, int> MergeValuei_j;

    public void MergeElemet(List<CabinScript> allCabinScripts)
    {
        for (int i = 0; i < allCabinScripts.Count - 1; i++)
        {
            for (int j = i + 1; j < allCabinScripts.Count; j++)
            {
                if (allCabinScripts[i] && allCabinScripts[j])
                {
                    bool IsLevelCabinsEqual = allCabinScripts[i].LevelCabin.Equals(allCabinScripts[j].LevelCabin);
                    if (IsLevelCabinsEqual)
                    {
                        MergeValuei_j?.Invoke(i, j);
                        return;
                    }
                }
            }
        }
    }
}

public interface IAddService
{
    public event Action<int> AddAction;
    public void AddListFunc(List<bool> allCabinScripts);
}

public class AddService : IAddService
{
    public event Action<int> AddAction;

    public void AddListFunc(List<bool> AllCabin)
    {
        for (int i = 0; i < AllCabin.Count; i++)
        {
            if (!AllCabin[i])
            {
                AddAction?.Invoke(i);
                return;
            }
        }
    }
}