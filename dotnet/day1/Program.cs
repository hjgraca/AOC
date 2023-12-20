var lines = File.ReadLines(Directory.GetCurrentDirectory() + "/input.txt");

int sum = 0;
var numberNames = new List<string> { "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };

foreach (var line in lines)
{
    var digits = new List<int>();
    for (int i = 0; i < line.Length; i++)
    {
        char character = line[i];
        if (int.TryParse(character.ToString(), out var tmp))
        {
            digits.Add(tmp);
        }
        else
        {
            var n = numberNames.FirstOrDefault(x => x.StartsWith(character) && line.Substring(i, x.Length + i <= line.Length ? x.Length : 0) == x);
            if (n != null)
            {
                digits.Add(numberNames.IndexOf(n) + 1);
                i += n.Length - 2;
            }
        }

    }

    var digit = digits.First() + "" + digits.Last();
    Console.WriteLine(digit);
    sum += int.Parse(digit);
}


Console.WriteLine(sum);

