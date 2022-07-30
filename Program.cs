// See https://aka.ms/new-console-template for more information

using DataStructures;

MyMain();

static void MyMain()
{
    Console.WriteLine("Entered main --> \n");

    var x = new LinearDataStrucs();
    x.TestMyStack();


    Console.WriteLine("\nDone executing main -->");
    Console.ReadKey();
}

static void TestAvgFunc()
{
    List<int> a = new List<int> { 1, 2, 3 };
    var b = new List<int> { 4, 5, 6 };

    var x = new LinearDataStrucs();

    SampleAvgOfLists(a, b);
}

static void SampleAvgOfLists(List<int> a, List<int> b)
{
    float avgA = 0;
    float avgB = 0;

    foreach (int currentItem in a)
    {
        avgA = avgA + currentItem;
    }
    avgA = avgA / a.Count;
    foreach (int currentItem in b)
    {
        avgB = avgB + currentItem;
    }
    avgB = avgB / b.Count;

    Console.WriteLine($"runningSumA = {avgA}");
    Console.WriteLine("runningSumB = " + avgB);
}

