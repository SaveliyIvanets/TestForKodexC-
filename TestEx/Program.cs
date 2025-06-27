class Task
{
    static void uniqueReader(Dictionary<int, int> uniqueNumbers,
        String path) //функция где я в словарик заношу число + сколько раз встретилось
    {
        using (StreamReader reader = new StreamReader(path))
        {
            string line;
            int number;
            while ((line = reader.ReadLine()) != null)
            {
                number = int.Parse(line);
                if (!uniqueNumbers.ContainsKey(number))
                {
                    uniqueNumbers.Add(number, 1);
                }
                else
                {
                    uniqueNumbers[number]++;
                }
            }
        }
    }

    static void Main()
    {
        string directoryPath = Console.ReadLine(); // читаю путь к каталогу
        List<string> numbers = new List<string>(); // создаю список для подходящих под условия массив 
        Dictionary<int, int>
            uniqueNumbers = new Dictionary<int, int>(); // создаю словарь для поиска уникальных чисел за О(1)
        string[] paths = Directory.GetFiles(directoryPath, "*.txt");
        foreach (string path in paths) // прогоняю все файлы через функцию чтобы сформировать итоговый словарь
        {
            uniqueReader(uniqueNumbers, path);
        }


        foreach (int key in uniqueNumbers.Keys)
        {
            int item = uniqueNumbers[key];
            if (item == 1 && key % 4 == 3)
            {
                numbers.Add(key.ToString());
            }
        }

        numbers.Sort((a, b) => b.CompareTo(a));
        File.WriteAllLines(Path.Combine(directoryPath, "result.txt"), numbers);
        foreach (string key in numbers)
        {
            Console.WriteLine(key);
        }
    }

    static void GenerateTestData(string directoryPath,
        int fileCount = 10) // функция что генерирует файлы в директории по пути 
    {
        Random rnd = new Random();

        if (!Directory.Exists(directoryPath))
        {
            Directory.CreateDirectory(directoryPath);
        }

        for (int i = 1; i <= fileCount; i++)
        {
            string filePath = Path.Combine(directoryPath, $"file_{i}.txt");
            int numbersCount = rnd.Next(100, 1001);
            List<string> numbers = new List<string>();

            for (int j = 0; j < numbersCount; j++)
            {
                numbers.Add(rnd.Next(1, 10001).ToString());
            }

            File.WriteAllLines(filePath, numbers);
        }
    }
}