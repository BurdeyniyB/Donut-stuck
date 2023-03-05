using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineTrajectory : MonoBehaviour
{
    private Transform _Point;
    bool full = false;

    public void Line()
    {
     if(full == false)
      {
        _Point = GetComponent<Transform>();

        Spawn.instance.pushSpawnObj(_Point);
      }
    }

    public void FullTrue()
    {
      full = true;
    }

    public void FullFalse()
    {
      full = false;
    }
}
