using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CylinderPush : MonoBehaviour
{
    public static CylinderPush instance;
    private Rigidbody _rigidbody;
    private Transform _transform;
    public float force;
    public Vector3 direction;
    bool push;

    private HashSet<GameObject> touchingObjects = new HashSet<GameObject>();

	void Awake () {
        if (instance == null)
            instance = this;
	}

    void Update()
    {
        if(push)
        {
           _rigidbody.velocity = new Vector3(0, 0, force);
        }
    }

    void Start()
    {
      _rigidbody = GetComponent<Rigidbody>();
      _transform = GetComponent<Transform>();
    }

   public void Push(Transform _Point)
   {
    if(this.gameObject.tag != "PushYes")
    {
      Debug.Log("forse");

      _transform.position = _Point.position;
      push = true;

      this.gameObject.tag = "PushYes";
      Spawn.instance.startCoroutineFound();
    }

   }

//       void OnCollisionEnter(Collision col)
//       {
//           if (col.gameObject.tag == "Pos")
//           {
//              Debug.Log("push = false");
//              push = false;
//              touchingObjects.Add(col.gameObject);
//           }
//       }
//
//       void OnCollisionExit(Collision col)
//       {
//              Debug.Log("push = true");
//              push = true;
//              touchingObjects.Remove(col.gameObject);
//       }
}
