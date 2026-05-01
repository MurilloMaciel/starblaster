using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    [SerializeField] private int damage;

    public int GetDamage()
    {
        return damage;
    }

    public void OnHit()
    {
        Destroy(gameObject);
    }
}
