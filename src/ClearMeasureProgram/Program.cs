using ClearMeasureLibrary;

var dict = new Dictionary<int, string>
{
    { 3, "Rikki" },
    { 5, "Bobby" },
};
var collection = new ClearMeasureCollection(int.MaxValue, dict);
foreach (var measure in collection)
{
    Console.WriteLine(measure);
}