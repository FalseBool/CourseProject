using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fps : MonoBehaviour
{
    public float updateInterval = 0.5F;
    public int fpsRate = 70;
    private double lastInterval;
    private int frames = 0;
    private float fpsc;
    void Start()
    {
        Application.targetFrameRate = fpsRate;
        lastInterval = Time.realtimeSinceStartup;
        frames = 0;
    }

    void OnGUI()
    {
        GUILayout.Label("" + fpsc.ToString("f2"));
    }

    void Update()
    {
        ++frames;
        float timeNow = Time.realtimeSinceStartup;
        if (timeNow > lastInterval + updateInterval)
        {
            fpsc = (float)(frames / (timeNow - lastInterval));
            frames = 0;
            lastInterval = timeNow;
        }
    }
}