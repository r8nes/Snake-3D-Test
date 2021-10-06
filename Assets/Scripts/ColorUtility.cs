using System;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

// TODO
public static class ColorUtility 
{
   public enum ColorVariant
   {
        Red,
        Green,
        Blue
   }

    public static void SetColor(GameObject obj, ColorVariant color) {

        Color currentColor = new Color();
        
        switch (color)
        {
            case ColorVariant.Red:
                currentColor = Color.red;
                break;
            case ColorVariant.Green:
                currentColor = Color.green;
                break;
            case ColorVariant.Blue:
                currentColor = Color.blue;
                break;
        }

        obj.GetComponent<MeshRenderer>().material.color = currentColor;
    }

    public static ColorVariant GetRandomColor() 
    {
        ColorVariant[] enumList = Enum.GetValues(typeof(ColorVariant)).Cast<ColorVariant>().ToArray();

        int randomColor = Random.Range(0, enumList.Length);

        return enumList[randomColor];
    }

    /// <summary>
    /// Use this method to change color of material randomly.
    /// </summary>
    /// <param name="obj">Object that change the material's color.</param>
    public static void ApplyColor(GameObject obj)
    {
        ColorVariant[] enumList = Enum.GetValues(typeof(ColorVariant)).Cast<ColorVariant>().ToArray();

        int randomColor = Random.Range(0, enumList.Length);

        SetColor(obj, enumList[randomColor]);
    }
    /// <summary>
    /// Use this method to change color of material (not randomly).
    /// </summary>
    /// <param name="obj">Object that change the material's color</param>
    /// <param name="variant">Parametr that using to set a color from ColorVariant enum.</param>
    public static void ApplyColor(GameObject obj, ColorVariant variant)
    {
        SetColor(obj, variant);
    }
}