/**** 
 * Created by: Sammy Ricketts
 * Date Created: April 6, 2022
 * 
 * Last Edited by: Krieger
 * Last Edited: April 25, 2022
 * 
 * Description: Pool of ojects for reuse
****/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{




    #region Pool Singleton
    static public ObjectPool POOL;

    void CheckPOOLIsInScene()
    {
        if (POOL == null)
        {
            POOL = this;
        }
        else
        {
            Debug.LogError("POOL.Awake() - Attempted to assign a second ObjectPool.POOL");

        }
    }
    #endregion


    private Queue<GameObject> projectiles = new Queue<GameObject>();

    [Header("Pool Settings")]
    public GameObject projectilePrefab;
    public int poolStartSize = 5;




    public void Awake()
    {
        CheckPOOLIsInScene();
    }


    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < poolStartSize; i++)
        {
            GameObject gObject = Instantiate(projectilePrefab);
            projectiles.Enqueue(gObject);
            gObject.SetActive(false);

        }
    }

    public GameObject GetObject()
    {
        if (projectiles.Count > 0)
        {
            GameObject gObject = projectiles.Dequeue();
            gObject.SetActive(true);
            return gObject;
        }
        else
        {
            Debug.LogWarning("Out of projectiles, reloading...");
            return null;
        }
    }


    public void ReturnObjects(GameObject gObject)
    {
        projectiles.Enqueue(gObject);
        gObject.SetActive(false);

    }
    // Update is called once per frame
    
}