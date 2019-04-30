using System.IO;

namespace Ion.Tests.Core
{
    public static class TestUtil
    {
        public static string dataDir = "../../../Data/";

        public static string ResolveDataPath(string path)
        {
            return Path.Join(TestUtil.dataDir, path);
        }
    }
}