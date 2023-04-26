
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public struct ColorClass
{
    
    public List<Color> Colorss;
}

[CreateAssetMenu]
public class ColorScriptbleObj : ScriptableObject
{
    public ColorClass Colors;
}