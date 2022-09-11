using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickDropThrow : MonoBehaviour
{
    private Transform HotldSpot;
    private Transform player;
    public float pickupdistance;
    public float forceMulti;

    public bool readToThrow;
    public bool itemIsPicked;
    private Rigidbody o_Rb;
    // Start is called before the first frame update
    void Start()
    {
        o_Rb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player").transform;
        HotldSpot = GameObject.Find("HotldSpot").transform;
    }
    
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.E) && itemIsPicked == true && readToThrow && forceMulti < 2000)
        {
            forceMulti += 2000 ;
        }
        pickupdistance = Vector3.Distance(player.position, transform.position);

  

        if(pickupdistance <= 2)
        {
            if (Input.GetKeyDown(KeyCode.E) && itemIsPicked == false && HotldSpot.childCount < 1)
            {
                GetComponent<Rigidbody>().isKinematic = true;
                GetComponent<BoxCollider>().isTrigger = true;
                GetComponent<Rigidbody>().useGravity = false;
                GetComponent<BoxCollider>().enabled = true;
                o_Rb.transform.position = HotldSpot.position;
                o_Rb.transform.parent = GameObject.Find("HotldSpot").transform;

                itemIsPicked = true;
                forceMulti = 0;
            }
        }
        if (Input.GetKeyUp(KeyCode.E) && itemIsPicked == true)
        {
            readToThrow = true;
            if(forceMulti > 150)
            {
                GetComponent<Rigidbody>().isKinematic = false;
                o_Rb.AddForce(player.transform.forward * forceMulti);
                this.transform.parent = null;
                GetComponent<Rigidbody>().useGravity = true;
                GetComponent<BoxCollider>().enabled = true;
                GetComponent<BoxCollider>().isTrigger = false;
                itemIsPicked = false;
                forceMulti = 0;
                readToThrow = false;
            }
            forceMulti = 0;
        }
        if (Input.GetKeyUp(KeyCode.Q) && itemIsPicked == true)
        {
            readToThrow = true;
            if (forceMulti > 10)
            {
                GetComponent<Rigidbody>().isKinematic = false;
                o_Rb.AddForce(player.transform.forward * 0);
                this.transform.parent = null;
                GetComponent<Rigidbody>().useGravity = true;
                GetComponent<BoxCollider>().enabled = true;
                itemIsPicked = false;
                forceMulti = 0;
                readToThrow = false;
            }
            forceMulti = 0;
        }




    }
}
