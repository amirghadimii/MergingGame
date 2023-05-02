using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class RotateFerriswheel : MonoBehaviour
{
    #region UpdateFun
// Update is called once per frame
    void Update()
    {
        if (!Rotatecabin.IsStop)
        {
        //cache transform in a variable and use it intead of call this.tranform in every frame - it's a performance killer
            this.transform.Rotate(this.transform.localRotation.x, this.transform.localRotation.y,
                -Rotatecabin.Speed);
        }
    }
    #endregion
}
