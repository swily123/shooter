namespace HealthDirectory
{
    public class Box : Health
    {
        protected override void Die()
        {
            Destroy(gameObject);
        }
    }
}