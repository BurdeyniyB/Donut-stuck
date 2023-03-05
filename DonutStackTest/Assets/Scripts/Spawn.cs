using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public static Spawn instance;
    [SerializeField] private GameObject SpawnObjPrefab;
    [SerializeField] private GameObject[] enemy;
    [SerializeField] private GameObject SpawnObj;
    private CylinderPush _cylinderPush;

	void Awake () {
        if (instance == null)
            instance = this;
	}

	void Start()
	{
	 SpawnObject();
	}

	public void startCoroutineFound()
	{
	StartCoroutine(Found());
	}

    IEnumerator Found()
    {
            yield return new WaitForSeconds(0.3f);

            enemy = GameObject.FindGameObjectsWithTag("Player");
            Debug.Log(enemy);
            if(enemy.Length == 0)
             {
               Debug.Log("enemy");
               SpawnObject();
             }
    }

    public void pushSpawnObj(Transform _Point)
    {
        _cylinderPush = SpawnObj.GetComponent<CylinderPush>();
        _cylinderPush.Push(_Point);
    }

    public void SpawnObject()
    {
      SpawnObj = Instantiate(SpawnObjPrefab);
    }
}
