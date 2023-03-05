using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Control : MonoBehaviour
{
    [System.Serializable]
    public class masive{
       public List<GameObject> setMasive = new List<GameObject>();
    }
    public List<masive> _masive = new List<masive>();
    public static Control instance;

	void Awake () {
        if (instance == null)
            instance = this;
	}

    void Start()
    {
    
    }

    public void masiveTrue(int x, int y)
    {
        _masive[x].setMasive[y].SetActive(true);
    }

    public void masiveFalse(int x, int y)
    {
        for(int i = y; y < 6; i++)
        {
         if(_masive[x].setMasive[i] != null)
         {
           _masive[x].setMasive[i].SetActive(false);
         }
        }
    }
}
