using System.Text.RegularExpressions;


var lines = File.ReadAllLines("input.txt");
var limits = new Dictionary<string, int>() { { "red", 12 }, { "green", 13 }, { "blue", 14 } };
int sum = 0, powers = 0;

foreach (string line in lines)
{
    string[] items = line.Split(new char[] { ':', ';' }, StringSplitOptions.RemoveEmptyEntries);
    string gameid = Regex.Match(items[0], @"\d+").Value;
    bool isOk = true;
    var max = new Dictionary<string, int>() { { "red", 0 }, { "green", 0 }, { "blue", 0 } };
    Console.WriteLine($"Game: {gameid}");

    foreach (var item in items[1..])
    {
        var subsets = item.Split(',', StringSplitOptions.RemoveEmptyEntries);

        foreach (var subset in subsets)
        {
            var cubes = subset.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            max[cubes[1]] = Math.Max(max[cubes[1]], int.Parse(cubes[0]));

            if (int.Parse(cubes[0]) > limits[cubes[1]])
            {
                isOk = false;
            }
        }
    }

    if (isOk)
    {
        sum += int.Parse(gameid);
        Console.WriteLine($"Game {gameid} - possible");
    }

    Console.WriteLine($"Red: {max["red"]}");
    Console.WriteLine($"Green: {max["green"]}");
    Console.WriteLine($"Blue: {max["blue"]}");

    Console.WriteLine($"Game {gameid} Power: {max["red"] * max["green"] * max["blue"]}");

    powers += max["red"] * max["green"] * max["blue"];
}

Console.WriteLine($"Total possible game id sum {sum}");
Console.WriteLine($"Total Powers: {powers}");