using TMPro;
using UnityEngine;

public abstract class BaseText : MonoBehaviour
{
    [SerializeField] protected TextMeshProUGUI _text;

    private void OnEnable()
    {
        Subscribe();
        UpdateUI();
    }

    private void OnDisable()
    {
        Unsubscribe();
    }

    protected virtual void Subscribe() { }

    protected virtual void Unsubscribe() { }

    protected virtual void UpdateUI() { }
}