using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TypoEditor.UnitTests
{
    public class FakeMainWindow : IMainWindow
    {
        public string SelectFolder()
        {
            return Constants.UserSelectedPath;
        }
    }
}
