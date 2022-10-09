using System.Text;

namespace File_Management_Application
{
    public class FMA
    {
        private Dictionary<char, int> CharCount;
        private StreamReader? Reader;
        private string? FileLoc;

        public FMA()
            => CharCount = new();

        public FMA(string fileLoc)
        {
            CharCount = new();
            FileLoc = fileLoc;
        }

        public void NewFileLoc(string loc)
            => FileLoc = loc;

        public void ReadData()
        {
            if (FileLoc is null)
            { throw new Exception("FileLoc is null!\nInsert a new file location."); }

            try
            {
                using (Reader = new(FileLoc))
                {

                    CharCount.Clear();
                    StringBuilder sb = new();
                    string line;
                    while ((line = Reader.ReadLine()!) != null)
                    {
                        sb.Append(line);
                    }

                    CalculateCharOccurances(sb.ToString());
                }
            }
            catch (Exception e)
            {
                System.Console.WriteLine(e.Message);
            }
        }

        public string ProcessData()
        {
            if (CharCount.Count == 0)
            { throw new Exception("FMA contains no data!\nPlease insert some data."); }

            var data = CharCount
                .OrderByDescending(kv => kv.Value)
            ;

            StringBuilder sb = new();
            foreach (var item in data) 
                sb.Append(item + " "); 

            return sb.ToString();
        }

        // HELPER FUNCTIONS
        private void CalculateCharOccurances(string data)
        {
            foreach (var ch in data)
            {
                if (CharCount.ContainsKey(ch))
                {
                    CharCount[ch] += 1;
                }
                else
                {
                    CharCount[ch] = 1;
                }
            }
        }
    }
}