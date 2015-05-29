using AdapterPattern.Interfaces;

namespace AdapterPattern
{
    // The adapter implements the Target interface and is composed with the Adaptee
    public class TurkeyAdapter : IDuck
    {
        private readonly ITurkey _turkey;

        public TurkeyAdapter(ITurkey turkey)
        {
            _turkey = turkey;
        }

        public void Quack()
        {
            _turkey.Gobble();
        }

        public void Fly()
        {
            // need to compensate because turkeys are only flying short distance
            for (int i = 0; i < 5; i++)
            {
                _turkey.Fly();
            }
        }

        public void CatchFish()
        {
            throw new System.InvalidOperationException("I'm a turkey, I cannot catch fish!");
        }
    }
}
