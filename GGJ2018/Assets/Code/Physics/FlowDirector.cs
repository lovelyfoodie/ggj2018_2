//------------------------------------------------------------------------------
// Copyright © 2018 alchemedium LLC. All Rights Reserved.
// Author: Ryan Brolley
//------------------------------------------------------------------------------

using System.Collections.Generic;
using UnityEngine;

public class FlowDirector : MonoBehaviour
{
    private static FlowDirector _instance = null;
    public static FlowDirector Instance { get { return _instance; } }

    public GameObject prefab;

    public Flow start;
    public Flow end;
    public List<Flow> list;
    public int iter = 1;


    private void OnValidate()
    {
        _instance = this;
    }

    public void Add(Flow flow, Flow newFlow)
    {
        iter++;
        list.Add(newFlow);

        if (!end)
            end = newFlow;

        if (!start)
            start = newFlow;

        if (end.Equals(flow))
            end = newFlow;
    }

    public void Remove(Flow flow)
    {
        list.Remove(flow);

        if (end.Equals(flow))
            end = flow.prev;

        if (start.Equals(flow))
            start = flow.next[0];
    }
}
