using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class FunctionTimer
{
    private Action action;
    private float timer;
    private bool isVisiblel;

    public FunctionTimer(Action action, float time)
    {
        this.action = action;
        this.timer = time;
    }

    public void Update()
    {
        timer -= Time.deltaTime;
        if (timer < 0)
        {
            action();
        }
    }
}
