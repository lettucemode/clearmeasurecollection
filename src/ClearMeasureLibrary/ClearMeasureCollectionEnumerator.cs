using System.Collections;

namespace ClearMeasureLibrary
{
    public class ClearMeasureCollectionEnumerator : IEnumerator<string>
    {
        private int Position = 0;
        private ClearMeasureCollection Collection { get; }

        public ClearMeasureCollectionEnumerator(ClearMeasureCollection collection)
        {
            this.Collection = collection;
        }

        object IEnumerator.Current => this.Collection[this.Position];

        public string Current => this.Collection[this.Position];

        public bool MoveNext()
        {
            this.Position++;
            return this.Position < this.Collection.Length;
        }

        public void Reset()
        {
            this.Position = -1;
        }

        public void Dispose()
        {

        }
    }
}   