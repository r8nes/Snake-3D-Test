using UnityEngine;

public class ColorChanger : MonoBehaviour
{
    [System.Obsolete]
    private void Start()
    {
        ColorUtility.ApplyColor(gameObject);
        ParticleSystem[] children = transform.GetComponentsInChildren<ParticleSystem>();

        foreach (var particle in children)
        {
            particle.startColor = gameObject.GetComponent<MeshRenderer>().material.color;       
        }
    }
}
