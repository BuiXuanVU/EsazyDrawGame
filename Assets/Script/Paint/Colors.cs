using System;
using System.Collections.Generic;
using UnityEngine;
[Serializable]
public class Colors
{
    public List<Color> colors = new List<Color>(4);
}
[Serializable]
public class ColorsList
{
    public List<Colors> colorslist;
}