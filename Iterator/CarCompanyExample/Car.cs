namespace Iterator.CarCompanyExample
{
    public class Car
    {
        public string Name { get; }

        public Car(string name)
        {
            Name = name;
        }

        public override string ToString() => Name;
    }
}
