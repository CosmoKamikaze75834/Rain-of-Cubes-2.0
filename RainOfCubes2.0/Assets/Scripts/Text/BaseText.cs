using TMPro;
using UnityEngine;

public abstract class BaseText : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private string _label;
    [SerializeField] protected CounterType _counterType;

    private void OnEnable()
    {
        Subscribe();
    }

    private void OnDisable()
    {
        Unsubscribe();
    }

    public void Change(int amount)
    {
        _text.text = _label + amount.ToString();
    }

    protected virtual void Subscribe() { }
    protected virtual void Unsubscribe() { }
}