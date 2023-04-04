using System.Collections;

namespace ClearMeasureLibrary
{
    public class ClearMeasureCollection: IEnumerable
    {
        private int UpperBound { get; }
        private string Name1 { get; }
        private string Name2 { get; }
        private string ComboName { get; }

        public ClearMeasureCollection(int upperBound, string name1, string name2)
        {
            this.UpperBound = upperBound;
            this.Name1 = name1;
            this.Name2 = name2;
            this.ComboName = $"{Name1}{Name2}";
        }

        public string this[int number] => GetNameForNumber(number);
        public int Length => this.UpperBound;

        private string GetNameForNumber(int number)
        {
            if (number % 3 == 0 && number % 5 == 0) return this.ComboName;
            if (number % 3 == 0) return this.Name1;
            if (number % 5 == 0) return this.Name2;
            return number.ToString();
        }

        public IEnumerator GetEnumerator()
        {
            return new ClearMeasureCollectionEnumerator(this);
        }
    }
}   