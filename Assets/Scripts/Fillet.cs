using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fillet : MonoBehaviour
{
    public Material[] materials;

    public GameObject[] filletParts;
    public GameObject center;

    public float timer = 5;

    public GameObject filletPrefab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        //Debug.Log(transform.rotation.x + "    " + transform.rotation.y + "    " + transform.rotation.z);
    }
    private void OnCollisionStay(Collision col)
    {
        if (col.gameObject.tag == "Sarten")
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                NextState();
                timer = 5;
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        print(other.gameObject.name);
    }
    private void NextState()
    {
        foreach(GameObject g in filletParts)
        {
            if (g.transform.position.y <= center.transform.position.y)
            {
                
                SpriteRenderer sr = g.GetComponent<SpriteRenderer>();
                print(sr.material);
                //MeshRenderer mr = g.GetComponent<MeshRenderer>();
                if (sr.material == materials[materials.Length-1])
                {
                    Debug.Log("MUY HECHO");
                    OnDestroy();
                }
                for (int i = 0; i < materials.Length - 1; i++)
                {
                    if (sr.material == materials[i])
                    {
                        sr.material = materials[i+1];
                    }
                } 
            }
        }
        Vibration.Vibrate(1000);
    }
    private void OnDestroy()
    {
        //FilletSpawner.Instance.Spawn(filletPrefab, transform.position + Vector3.up * 3);
        Destroy(gameObject);
    }
}
