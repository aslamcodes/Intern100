//Create a application that
//take 2 numbers and find its
//1) sum,=
//2) product
//3) and divide the first by second
//4), also supract the second from the first. 

//5) Include another method to find the remainder when the first number is divided by second

using Arithmetic;

class BasicArithMetic(int a, int b)
{
    public int a = a;
    public int b = b;

    public void PerformTask()
    {
        int sum = this.a + this.b;
        Console.WriteLine("Sum " + sum);
        int product = this.a * this.b;
        Console.WriteLine("Product " +  product);
        int division = this.a / this.b;
        Console.WriteLine("Division " + division);
        this.a -= this.b;
        Console.WriteLine("a after b is reduced from a");
        Console.WriteLine($"Remainder {this.GetRemainder()}");
    }

    public int GetRemainder()
    {
        return this.a % this.b;
    }

   
}

class Program
{
    public int a;
    public int b;
   
    public static void Main(string[] args)
    {
        //int a = Convert.ToInt32(Console.ReadLine());
        //int b = Convert.ToInt32(Console.ReadLine());

        //BasicArithMetic arithmetic = new(a, b);
        //arithmetic.PerformTask();


        //Console.WriteLine("============= 2 ===========");

        //_ = new MaxUntilNegate();

        //Console.WriteLine("============= 3 ===========");

        //_ = new AverageUntillXBy7();

        //Console.WriteLine("============= 4 ===========");
        
        //_ = new UserNameLength();

        //Console.WriteLine("============ 5 ===========");

        //_ = new UserNamePasswordChecker();

        Console.WriteLine("============ 6 ===========");

        _ = new LeastVowels();



    }
}

//int sum = a + b;

//int prodcut = a * b;

//int division = a / b;

//b -= a;
