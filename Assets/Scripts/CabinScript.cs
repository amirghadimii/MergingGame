using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class CabinScript : MonoBehaviour
{
    [SerializeField] public SpriteRenderer _spriteRenderer;// always use [SerializeField] with private variables

//deete unnecessary comments
    // Start is called before the first frame update
    public int LevelCabin = 0;
    [SerializeField] ColorScriptbleObj colorScriptble;
    
    //try to place same type of definition togater - i mean don't use public between to [SerializeField]

    private void OnEnable()
    {
        LevelCabin = 0;
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _spriteRenderer.DOFade(1, 1);
        _spriteRenderer.DOColor(Color.white, 0);
    }

    public void LevelUpMerging()
    {
        LevelCabin++;
        var DataCenter = colorScriptble.Colors.Colorss[LevelCabin];
        _spriteRenderer.DOColor(DataCenter, 1f);
    }
}
