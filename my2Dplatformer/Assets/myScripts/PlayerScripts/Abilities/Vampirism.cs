using System.Collections;
using UnityEngine;

public class Vampirism : MonoBehaviour
{
    [SerializeField] private float _duration;
    [SerializeField] private float _cooldown;
    [SerializeField] private float _areaRadius;
    [SerializeField] private float _hpStealPerSecond;
    [SerializeField] private GameObject _area;
    [SerializeField] private LayerMask _enemyLayer;

    private Collider2D[] _abilityTargets;
    private bool _isAbilityEnable = true;
    private Character _character;
    private readonly WaitForSeconds _oneSecond = new WaitForSeconds(1);

    private void Awake()
    {
        _character = GetComponent<Character>();
    }

    public void Activate()
    {
        if (_isAbilityEnable == true)
            StartCoroutine(Vampiring());
    }

    private IEnumerator Vampiring()
    {
        _isAbilityEnable = false;

        ShowAbilityArea(true);
        
        for(int i = 0; i < _duration; i++)
        {
            DoDamage();

            _character.ApplyHeal(_hpStealPerSecond);

            yield return _oneSecond;
        }

        ShowAbilityArea(false);
        StartCoroutine(WaitCooldown());
    }
    private void DoDamage()
    {
        _abilityTargets = GetNearestTargets();

        foreach (var abilityTarget in _abilityTargets)
        {
            if (abilityTarget.TryGetComponent(out Character target))
                target.ApplyDamage(_hpStealPerSecond);
        }
    }

    private IEnumerator WaitCooldown()
    {
        for (int i = 0; i < _cooldown; i++)
        {
            yield return _oneSecond;
        }

        _isAbilityEnable = true;
    }

    private Collider2D[] GetNearestTargets()
    {
        return Physics2D.OverlapCircleAll(transform.position, _areaRadius, _enemyLayer);
    }

    private void ShowAbilityArea(bool isAbilityActive)
    {
        _area.SetActive(isAbilityActive);
    }
}