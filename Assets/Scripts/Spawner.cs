using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using Random = UnityEngine.Random;

public class Spawner : MonoBehaviour
{
    public Transform startPos;

    public Location spawnloc;
    public GameObject[] allPossibleFuckigObjects;

    private void Awake()
    {
        PlayerStatus.OnPlayerChangeLocation += Inlocation;

    }

    private void Start()
    {
    }

    private void OnDestroy()
    {
        PlayerStatus.OnPlayerChangeLocation -= Inlocation;
    }

    private Coroutine spawningCor;


    private void Inlocation(Location location)
    {
        
        Debug.Log(location + " is now spawning");
        if (location == spawnloc)
        {
          spawningCor =  StartCoroutine(Kapps());
        }
        else
        {
            if(spawningCor != null)
           
                StopCoroutine(spawningCor);
            
        }
    }
    IEnumerator Kapps()
    {
        while (true)
        {
            int fromX = (int) startPos.position.x;
            int fromY = (int) startPos.position.y;


            int randomX = Random.Range(1, 10);
            int randomY = Random.Range(1, 15);

            int addX = randomX + fromX;
            int addY = randomY + fromY;


            Vector3 pos = new Vector3(addX, addY, 0);

            int randomFuckingObject = Random.Range(0, allPossibleFuckigObjects.Length );
            Instantiate(allPossibleFuckigObjects[randomFuckingObject], pos, Quaternion.identity);
            yield return new WaitForSeconds(2f);
        }
      


      
        
    }
}
