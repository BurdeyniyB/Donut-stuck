using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeCollision : MonoBehaviour
{
     public GameObject _gameObject;
     public int x, y;

     void Update()
     {
       if(_gameObject == null)
       {
         Control.instance.masiveFalse(x, y);
       }
     }

     void OnCollisionEnter(Collision col)
     {
       if (col.gameObject.tag == "PushYes")
         {
           _gameObject = col.gameObject;
           Control.instance.masiveTrue(x, y);
         }
     }

}
