namespace TypoEditor
{
    using System.Collections.Generic;
    using System.IO;
    using System.Reflection;
    using Newtonsoft.Json.Linq;

    public class CorrectWords : ICorrectWords
    {
        private ISet<string> correctWords;
        private BkTree bktree;

        public CorrectWords()
        {
            this.correctWords = new HashSet<string>();
            this.bktree = new BkTree();
            Assembly ex = Assembly.GetExecutingAssembly();
            var s = ex.GetManifestResourceStream("TypoEditor.words.json");
            var r = new StreamReader(s);
            var str = r.ReadToEnd();
            var arr = JArray.Parse(str);
            foreach (var word in arr.Children())
            {
                string w = (string)((JValue)word).Value;
                this.correctWords.Add(w);
                this.bktree.Insert(w);
            }
        }

        public IEnumerable<string> GetRecommendCorrections(string typo)
        {
            return this.bktree.Query(typo, 2);
        }

        public bool IsWordCorrect(string s)
        {
            return this.correctWords.Contains(s);
        }
    }
}
