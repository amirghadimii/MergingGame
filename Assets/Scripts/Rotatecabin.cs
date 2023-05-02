using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Rotatecabin : MonoBehaviour
{
    // Start is called before the first frame update
    public static bool IsStop=false;
    public static float Speed=0.15f;
    [SerializeField] private BaseManage _baseManage;
  
    // Update is called once per frame

    void Update()
    {
        if (!IsStop)
        {
        //you don't need to .gameObject and again cache transform in a variable
            this.gameObject.transform.Rotate(new Vector3(0, 0, Speed));
        }
   
    }
}
