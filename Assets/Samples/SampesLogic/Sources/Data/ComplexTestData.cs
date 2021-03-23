namespace SampesLogic.Data
{
    public class ComplexTestData
    {
        public SimpleTestData Data;

        public override string ToString()
        {
            return $"ComplexTestData: data = {Data}";
        }
    }
}