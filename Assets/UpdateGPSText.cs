using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UpdateGPSText : MonoBehaviour
{
    public TextMeshProUGUI coordinates;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        coordinates.text = "Lat: " + GPS.Instance.latitude.ToString() + "Long: " + GPS.Instance.longitude.ToString();
    }
}
