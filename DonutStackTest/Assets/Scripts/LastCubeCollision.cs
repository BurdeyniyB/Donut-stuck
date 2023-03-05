using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LastCubeCollision : MonoBehaviour
{
     public GameObject _gameObject;

     [SerializeField] private LineTrajectory _lineTrajectory;

     void Update()
     {
       if(_gameObject == null)
       {
          _lineTrajectory.FullFalse();
       }
     }

     void OnCollisionEnter(Collision col)
     {
       if (col.gameObject.tag == "PushYes")
         {
           _gameObject = col.gameObject;

           _lineTrajectory.FullTrue();
         }
     }
}
