namespace TestedApp
{
    public class Program
    {
        public static void Main()
        {

        }
        public float a;
        public void subtract(int x, int y)
        {
            a = x - y;
        }
        public void Square(int x) 
        {
            if (x <= 100 && x > -1)
            {
                a = x * x;
            } 
        }
        public void Root(double x)
        {
            if (x < 0)
            {
                throw new System.NotSupportedException("Cannot take square root of negative number");
            }
            a =(float) Math.Sqrt(x);
        }
        public void FindSmallestDouble(List<Double> doubles)
        {
            if (doubles.Count > 0)
            {
                a = (float)doubles[0];
                for (int i = 0; i < doubles.Count; i++)
                {
                    if (doubles[i] < a)
                    {
                        a = (float)doubles[i];
                    }
                }
            }
        }
        public void BiggestInt(List<int> ints)
        {
            if (ints.Count > 0)
            {
                a = ints[0];
                for (int i = 0; i < ints.Count; i++)
                {
                    if (ints[i] > a)
                    {
                        a = ints[i];
                    }
                }
            }
        }
        public void MidFloat(List<float> floats)
        {
            if (floats.Count > 0)
            {
                foreach (float f in floats)
                {
                    a += f;
                }
                a = a / floats.Count;
            }
        }
    }
}
