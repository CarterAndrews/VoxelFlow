using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FluidManager : MonoBehaviour
{
    public static Block[,,] blocks;
    public static List<Fluid> fluids;
    // Start is called before the first frame update
    void Start()
    {
        blocks=new Block[1000,1000,1000];
        for(int i=0;i<1000;i++){
            for(int j=0;j<1000;j++){
                for(int k=0;k<1000;k++){
                    blocks[i,j,k]=null;
                }
            }
        }
    }
    public static void addBlock(Vector3Int pos,Block block){
        blocks[pos.x,pos.y,pos.z]=block;
        if(block is Fluid){
            fluids.Add((Fluid) block);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
