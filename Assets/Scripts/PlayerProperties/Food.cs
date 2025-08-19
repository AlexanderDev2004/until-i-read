namespace Assets.Scripts.PlayerProperties
{
    public class Food : HealingItem
    {
        public override void Use(Point target)
        {
            if (target.healthType == Type.PHYSICAL)
            {
                target.Heal(amount);
            }
        }
    }
}