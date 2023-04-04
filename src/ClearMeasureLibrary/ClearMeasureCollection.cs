using System.Collections;
using System.Text;

namespace ClearMeasureLibrary
{
    public class ClearMeasureCollection: IEnumerable
    {
        private int UpperBound { get; }
        private Dictionary<int, string> NumbersToNames { get; }

        public ClearMeasureCollection(int upperBound, Dictionary<int, string> numbersToNames)
        {
            this.UpperBound = upperBound;
            this.NumbersToNames = numbersToNames;
        }

        public string this[int number] => GetNameForNumber(number);
        public int Length => this.UpperBound;

        private string GetNameForNumber(int number)
        {
            var builder = new StringBuilder();
            foreach (var entry in this.NumbersToNames)
            {
                if (number % entry.Key == 0)
                {
                    builder.Append(entry.Value);
                }
            }
            if (builder.Length == 0)
            {
                builder.Append(number);
            }
            return builder.ToString();
        }

        public IEnumerator GetEnumerator()
        {
            return new ClearMeasureCollectionEnumerator(this);
        }
    }
}   