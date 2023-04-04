using ClearMeasureLibrary;

var collection = new ClearMeasureCollection(int.MaxValue, "Rikki", "Bobby");
foreach (var measure in collection)
{
    Console.WriteLine(measure);
}