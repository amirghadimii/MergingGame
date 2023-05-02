
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public struct ColorClass
{
    
    public List<Color> Colorss;// why using 2s in name? try not use public => it's better to use [SerializeField] private List<Color> _colors; and public List<Color> Colors => _colors;
    // in this type of definition values will become readonly
}

[CreateAssetMenu]
public class ColorScriptbleObj : ScriptableObject
{
    public ColorClass Colors;
}
