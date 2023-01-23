using UnityEngine;

[System.Serializable]
public class SW_ZombieData
{
    [SerializeField] private string _id;
    [SerializeField] private string _skinId;
    [SerializeField] private SW_ZombieMovePolicyData _movePolicyData;
    [SerializeField] private SW_ZombieAttackPolicyData _attackPolicyData;

    public string Id => _id;
    public string SkinId => _skinId;
    public SW_ZombieMovePolicyData MovePolicyData => _movePolicyData;
    public SW_ZombieAttackPolicyData AttackPolicyData => _attackPolicyData;
}
