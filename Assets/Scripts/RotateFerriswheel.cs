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
            this.transform.Rotate(this.transform.localRotation.x, this.transform.localRotation.y,
                -Rotatecabin.Speed);
        }
    }
    #endregion
}
