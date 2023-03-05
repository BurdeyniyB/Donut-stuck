using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DonutsCreate : MonoBehaviour
{
    [SerializeField] private GameObject _prefab;
    [SerializeField] public List<GameObject> createDonuts = new List<GameObject>();
    [SerializeField] private Material[] _material;

    [SerializeField] private GameObject[] enemy;

    [SerializeField] public GameObject nearestObj1;
    [SerializeField] public GameObject nearestObj2;

    private DonutsCreate nearestObj1DonutsCreate;
    private DonutsCreate nearestObj2DonutsCreate;

    public float distance;

    public int CountDonuts;
    bool x = true;

    void Start()
    {
         CountDonuts = Random.Range(1, 4);
         Debug.Log("CountDonuts = " + CountDonuts);
         for(int i = 0; i < CountDonuts; i++)
         {
           createDonuts.Add(Instantiate(_prefab));

           createDonuts[i].transform.parent = this.gameObject.transform;
           createDonuts[i].transform.position = new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y + (0.09f + 0.3f * i), this.gameObject.transform.position.z);

           createDonuts[i].GetComponent<Renderer>().material = _material[Random.Range(0, 4)];
         }
    }

    void TransfomrDonuts()
    {
         for(int i = 0; i < CountDonuts; i++)
         {
          createDonuts[i].transform.parent = this.gameObject.transform;
          createDonuts[i].transform.position = new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y + (0.09f + 0.3f * i), this.gameObject.transform.position.z);
         }
    }

    void Update()
    {
        enemy = GameObject.FindGameObjectsWithTag("PushYes");
        Distance();
        TransfomrDonuts();
        Algoritm();
        Life();
    }

    void Distance()
    {
        distance = Mathf.Infinity;
        float distance1 = Mathf.Infinity;
        Vector3 positionS = transform.position;
          foreach(GameObject go in enemy)
          {
              float curDistance = Vector3.Distance(go.transform.position, positionS);
              if(curDistance < distance1 && curDistance != 0 && curDistance < 1.9f)
              {
                  distance1 = curDistance;
                  nearestObj2 = go;
                    if(distance1 < distance)
                    {
                     distance1 = distance;
                     distance = curDistance;

                     Debug.Log("nearestObj1 != null");
                     nearestObj2 = nearestObj1;

                     nearestObj1 = go;

                     if(nearestObj1 == nearestObj2)
                     {
                       nearestObj2 = null;
                     }
                    }
              }
          }
    }

    void Algoritm()
    {
    while(x)
    {
       Debug.Log("Algoritm(0)");
       nearestObj1DonutsCreate = nearestObj1.GetComponent<DonutsCreate>();
      if(nearestObj1DonutsCreate.CountDonuts <= 2)
      {
      Debug.Log("Algoritm(1)");
         if(CountDonuts == 1)
         {
         Debug.Log("Algoritm(2)");
          if(nearestObj1DonutsCreate.CountDonuts == 1)
          {
          Debug.Log("Algoritm(3)");
          string m1 = nearestObj1DonutsCreate.createDonuts[0].GetComponent<Renderer>().material.ToString();
          Debug.Log("Material m1" + m1);
          string m2 = createDonuts[0].GetComponent<Renderer>().material.ToString();
          Debug.Log("Material m2" + m2);
           if(m1 == m2)
           {
             Debug.Log("Algoritm(4)");
             //yield return new WaitForSeconds(0.3f);
             nearestObj1DonutsCreate.createDonuts.Add(createDonuts[0]);
             //yield return new WaitForSeconds(0.3f);
             CountDonuts = 0;
             nearestObj1DonutsCreate.CountDonuts = 2;
           }
          }
         }
      }
     }
     //yield return new WaitForSeconds(0.3f);
    }

    void Life()
    {
     if(CountDonuts == 0)
     {
      Destroy(this.gameObject);
     }
    }
}
