using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class SmoothHealthBar : HealthDisplayer
{
    [SerializeField] private Slider _bar;
    [SerializeField] private float _speed;

    private Coroutine _displaying;

    protected override void Display(float health)
    {
        if(_displaying != null)
            StopCoroutine(_displaying);
        
        _displaying = StartCoroutine(DisplayBar(health));
    }

    private IEnumerator DisplayBar(float health)
    {
        while (!Mathf.Approximately(_bar.value, health / Health.MaxValue))
        {
            _bar.value = Mathf.MoveTowards(_bar.value, health / Health.MaxValue, _speed * Time.deltaTime);

            yield return null;
        }
    }
}
