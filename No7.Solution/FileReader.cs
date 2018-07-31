using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace No7.Solution
{
    public class FileReader
    {
        private List<string> dataList;

        private bool flag;

        public FileReader()
        {
            dataList = new List<string>();
        }

        public IEnumerable<string> GetEnumerator()
        {
            if (!flag)
            {
                throw new InvalidOperationException($"Nothing has been read");
            }

            IEnumerable<string> InsideIterator()
            {
                foreach (var item in dataList)
                {
                    yield return item;
                }
            }

            return InsideIterator();
        }

        public void ReadFrom(Stream stream)
        {
            Validate(stream);

            using (var reader = new StreamReader(stream))
            {
                string line;

                while ((line = reader.ReadLine()) != null)
                {
                    dataList.Add(line);
                }
            }

            flag = true;
        }

        private void Validate(Stream stream)
        {
            if (!stream.CanRead)
            {
                throw new ArgumentException($"{nameof(stream)} closed for read");
            }
        }
    }
}
