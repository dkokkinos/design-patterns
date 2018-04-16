namespace AbstractFactory.Client
{
    public abstract class StyleFormatter
    {
        public abstract INumberFormatter CreateNumberFormatter();
        public abstract IStringFormatter CreateStringFormatter();

    }
}
