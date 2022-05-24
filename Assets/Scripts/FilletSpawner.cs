using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FilletSpawner : MonoBehaviour
{
    public static FilletSpawner Instance;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = (this);
        }
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }
    public static void Spawn(GameObject prefab, Vector3 pos)
    {
        Instantiate(prefab, pos, Quaternion.identity);
    }
}
