using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GPS : MonoBehaviour
{
    public static GPS Instance { set; get; }

    public float latitude;
    public float longitude;

    public float currentLatitude;
    public float currentLongitude;


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
    // Start is called before the first frame update
    void Start()
    {

        StartCoroutine(StartLocationService());
    }

    private IEnumerator StartLocationService()
    {
        if (!Input.location.isEnabledByUser)
        {
            Debug.Log("User has not enabled GPS");
            yield break;
        }

        Input.location.Start();
        int maxWait = 20;
        while (Input.location.status == LocationServiceStatus.Initializing && maxWait > 0)
        {
            yield return new WaitForSeconds(1);
            maxWait--;

        }

        if (maxWait <= 0)
        {
            Debug.Log("Timed out");
            yield break;
        }

        if (Input.location.status == LocationServiceStatus.Failed)
        {
            Debug.Log("Unable to determin device location");
            yield break;
        }

        latitude = Input.location.lastData.latitude;
        longitude = Input.location.lastData.longitude;
        //StartCoroutine(UpdateLocation());
    }
    /*private IEnumerator UpdateLocation()
    {
        currentLatitude = Input.location.lastData.latitude;
        currentLongitude = Input.location.lastData.longitude;
        yield return 0;
    }*/
}
