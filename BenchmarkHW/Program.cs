using System;
using System.Collections.Generic;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

public class SearchBenchmark
{
    private List<int> sortedList;
    private List<int> unsortedList;

    [Params(10, 100, 10000)]
    public int ListSize;

    [GlobalSetup]
    public void Setup()
    {
        sortedList = GenerateRandomList(ListSize);
        sortedList.Sort();

        unsortedList = GenerateRandomList(ListSize);
    }

    /*[Benchmark]
    public int BinarySearchSorted()
    {
        int targetValue = sortedList[ListSize / 2];
        return sortedList.BinarySearch(targetValue);
    }*/
    [Benchmark]
    public int BinarySearchUnSorted()
    {
        int targetValue = unsortedList[ListSize / 2];
        return unsortedList.BinarySearch(targetValue);
    }

    /*[Benchmark]
    public int IndexOfSorted()
    {
        int targetValue = sortedList[ListSize / 2];
        return sortedList.IndexOf(targetValue);
    }*/
    [Benchmark]
    public int IndexOfUnsorted()
    {
        int targetValue = unsortedList[ListSize / 2];
        return unsortedList.IndexOf(targetValue);
    }

    private List<int> GenerateRandomList(int count)
    {
        List<int> randomList = new List<int>();
        Random random = new Random();

        for (int i = 0; i < count; i++)
        {
            randomList.Add(random.Next());
        }

        return randomList;
    }
}

public class Program
{
    public static void Main()
    {
        var summary = BenchmarkRunner.Run<SearchBenchmark>();
    }
}
