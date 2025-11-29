using UnityEngine;

namespace HealthDirectory
{
    public class Box : Health
    {
        internal override void Die()
        {
            Object.Destroy(gameObject);
        }
    }
}