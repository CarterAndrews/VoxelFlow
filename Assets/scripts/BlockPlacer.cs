using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class BlockPlacer : MonoBehaviour
{
    public Camera cam;
    public GameObject SolidPrefab;
    public GameObject FluidPrefab;

    public  Type placing;
    // Start is called before the first frame update
    void Start()
    {
        placing=typeof(Solid);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1)){
            placing=typeof(Solid);
        }
        if(Input.GetKeyDown(KeyCode.Alpha2)){
            placing=typeof(Fluid);
        }
        if(Input.GetMouseButtonDown(0)){
            Ray ray=cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if(Physics.Raycast(ray,out hit)){
                Vector3Int pos=Vector3Int.RoundToInt(hit.collider.transform.position+hit.normal);
                if(placing==typeof(Solid)){
                    GameObject gm=Instantiate(SolidPrefab,pos,SolidPrefab.transform.rotation);
                    FluidManager.addBlock(pos,gm.GetComponent<Solid>());
                }
                else{
                    GameObject gm=Instantiate(FluidPrefab,pos,SolidPrefab.transform.rotation);
                    FluidManager.addBlock(pos,gm.GetComponent<Fluid>());
                }
            }
        }
    }
}
