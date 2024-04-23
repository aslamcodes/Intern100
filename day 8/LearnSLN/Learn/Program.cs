namespace Learn
{
    public enum AgeGroup
    {
        Kid,
        Adult,
        Old
    }


    public record Person(string Name, AgeGroup AgeGroup)
    {

    }

    public struct Point(int X, int Y)
    {
        public int X { get; set; } = X;
        public int Y { get; set; } = Y;
    }

    public class PersonCollection
    {

        private Person[] Persons = new Person[100];

        public int Last { get; set; } = 99;
        public Person? this[string name]
        {
            get
            {
                for (int i = 0; i < Persons.Length; i++)
                {
                    if (Persons[i].Name == name)
                    {
                        return Persons[i];
                    }
                }
                return null;
            }
            set => Persons[Last--] = value;
        }

        public Person this[int idx]
        {
            get => Persons[idx];
            set => Persons[idx] = value;
        }


    }



    public class Program
    {
        int Divide(int num1, int num2)
        {
            try
            {
                int result = num1 / num2;
                return result;
            }
            catch (DivideByZeroException dbze)
            {
                Console.WriteLine("You are trying to divide by zero. Its not worth");
            }
            finally
            {
                Console.WriteLine("Release the divide method resource");
            }
            return 0;

        }
        static void Main(string[] args)
        {
            //Point p1 = new Point();
            //Point p2 = new Point();

            //p1.Equals(p2);


            //PersonCollection personCollection = new();

            //personCollection[0] = new Person("Aslam", AgeGroup.Adult);
            //personCollection[1] = new Person("Kavin", AgeGroup.Kid);
            //personCollection[2] = new Person("Sugan", AgeGroup.Kid);
            //personCollection[3] = new Person("Venkat", AgeGroup.Adult);
            //personCollection[4] = new Person("Senthamil", AgeGroup.Adult);
            //personCollection[5] = new Person("Srikanth", AgeGroup.Adult);

            //Console.WriteLine(personCollection["ASdASdsad"]);

            //int num1, num2, result;
            //try
            //{
            //    num1 = Convert.ToInt32(Console.ReadLine());
            //    num2 = Convert.ToInt32(Console.ReadLine());
            //    result = num1 / num2;
            //    Console.WriteLine(result);
            //}
            //catch (FormatException fe)
            //{
            //    Console.WriteLine(fe.Message);
            //    Console.WriteLine("The given data could not be converted to number.");
            //}
            //catch (DivideByZeroException dbze)
            //{
            //    Console.WriteLine("You are trying to divide by zero. Its not worth");
            //}
            //Console.WriteLine("Bye bye");

            new Program().Divide(112, 12);

        }
    }
}
