//        using ConsoleApp2;

//        var strs = new[] { "flower", "flow", "flight" };
//        GetCommonPrefix(strs);

//        strs = new[] { "cir", "car" };
//    GetCommonPrefix(strs);

//    strs = new[] { "reflower", "flow", "flight" };
//GetCommonPrefix(strs);

//Console.ReadKey();


//string GetCommonPrefix(string[] strs)
//{
//    var str = strs.MinBy(x => x.Length);
//    var result = "";
//    var searchValue = "";

//    foreach (var s in str)
//    {
//        searchValue = result == "" ? s.ToString() : result + s;

//        if (strs.All(x => x.StartsWith(searchValue)))
//        {
//            result += s;
//        }
//        else
//        {
//            Console.WriteLine(result + "+.. -------------------------------------------------------");
//            return result;
//        }
//    }

//    Console.WriteLine(result + "+.. -------------------------------------------------------");
//    return result;
//}

////int decimalNotation = 2_000_000;
////int usual = 2000000;

////Console.WriteLine($"{decimalNotation == usual}");

////double d1 = 0.1;
////double d2 = 0.2;

////Console.WriteLine($"{d1 == 0.1}");
////Console.WriteLine($"{d1 + d2 == 0.3}");
///*
// *
// * Symbol       Value
//I             1
//V             5
//X             10
//L             50
//C             100
//D             500
//M             1000
// */



////var d = "LVIII";

////var dict = new Dictionary<char, int>()
////{
////    {'I', 1},
////    {'V', 5},
////    {'X', 10},
////    {'L', 50},
////    {'C', 100},
////    {'D', 500},
////    {'M', 1000},
////};
////while (true)
////{
////    int globalNumber = 0;
////    char previousChar = 'X';

////    var s = Console.ReadLine();

////    if (string.IsNullOrEmpty(s))
////    {
////        s = d;
////    }

////    previousChar = s[s.Length - 1];

////    for (int i = s.Length - 1; i > -1; i--)
////    {
////        if (dict.TryGetValue(s[i], out int currNumber))
////        {
////            dict.TryGetValue(previousChar, out int prevNumber);

////            if (previousChar != s[i] && prevNumber > currNumber)
////            {
////                globalNumber -= currNumber;
////            }
////            else
////            {

////                globalNumber += currNumber;
////            }

////            previousChar = s[i];
////        }
////    }
////    Console.WriteLine($"{s} = {globalNumber} ??");
////}



////var d = 3; // "III";
////var d1 = 4; // "IV";
////var d2 = 9; // "IX";
////var d3 = 13; // "XIII";
////var d4 = 1; // "XIII";
////var d5 = 1; // "XIV";
////var d6 = 1; // "XIX";


//async Task WriteCheck()
//{
//    var t1 = DateTime.Now;
//    Console.WriteLine(t1 + " before run task ++++++++++++++++++++++++++++++++++++++++++++++++++++++++");
//    _ = Task.Run(async () => await WriteAsyncWhileCan());
//    t1 = DateTime.Now;
//    Console.WriteLine(t1 + " after run... -------------------------------------------------------");

//    await Task.CompletedTask;
//}

//async Task WriteAsyncWhileCan()
//{
//    int x = 1;
//    while (x < 10)
//    {
//        x++;
//        Console.WriteLine(x);
//        await Task.Delay(1000);
//        var t = DateTime.Now;
//        Console.WriteLine(t);
//    }

//}

    
//        }
