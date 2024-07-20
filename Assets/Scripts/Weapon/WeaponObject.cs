using UnityEngine;

[CreateAssetMenu(fileName = "WeaponController", menuName = "Weapon/New Weapon Config")]
public class WeaponObject : ScriptableObject {
  public int _damage;

  public RuntimeAnimatorController _animatorController;
}
