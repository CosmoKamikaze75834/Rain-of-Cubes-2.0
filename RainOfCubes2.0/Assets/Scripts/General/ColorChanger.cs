using UnityEngine;

[RequireComponent(typeof(Renderer))]
public class ColorChanger : MonoBehaviour
{
    private Color _startColor;
    private Renderer _renderer;
    private float _minValue = 1f;

    private void Awake()
    {
        _renderer = GetComponent<Renderer>();
    }

    public void Apply()
    {
        _renderer.material.color = Color.blue;
    }

    public void Reset()
    {
        _renderer.material.color = Color.white;
    }

    public void ResetTransparency()
    {
        SetAlpha(_startColor.a);
    }

    public void EstablishTransparency(float amount)
    {
        SetAlpha(_minValue - amount);
    }

    private void SetAlpha(float alpha)
    {
        Color color = _renderer.material.color;
        color.a = alpha;
        _renderer.material.color = color;
    }
}