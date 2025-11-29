public class Box : Health
{
    internal override void Die()
    {
        Destroy(gameObject);
    }
}