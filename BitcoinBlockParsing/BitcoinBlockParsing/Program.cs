// Путь к исходному TSV-файлу
var inputFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"blockchair_bitcoin_blocks_20240727.tsv"); 

if (!File.Exists(inputFilePath))
{
    Console.WriteLine($"Файл {inputFilePath} не найден.");
    return;
}

// Чтение содержимого TSV-файла
var lines = File.ReadAllLines(inputFilePath);

// Обработка первой строки (заголовки столбцов)
var headerLine = lines[0];
var headers = headerLine.Split('\t');
var csvHeader = string.Join(",", headers);

// Парсинг остальных строк и создание CSV-строк
var csvLines = lines.Skip(1).Select(line => 
{
    var elements = line.Split('\t');
    return string.Join(",", elements);
}).ToArray();

// Путь к результирующему CSV-файлу
var outputFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"blockchair_bitcoin_blocks_20240727.csv"); 

// Запись CSV-строк в файл
File.WriteAllLines(outputFilePath, new[] { csvHeader }.Concat(csvLines));

Console.WriteLine($"Файл успешно преобразован: {outputFilePath}");