using Microsoft.VisualStudio.TestTools.UnitTesting;
using static ControlMaterials.Tools.Security.Encryption;

namespace UnitTests.Features.Security
{
    [TestClass]
    public class Encryption
    {
        private readonly string _data;
        private readonly byte[] _expected;

        public Encryption()
        {
            _data = "Hello";
            _expected = new byte[] {
                1,0,0,0,208,140,157,223,1,21,209,17,140,122,0,
                192,79,194,151,235,1,0,0,0,11,183,151,63,126,
                72,142,75,157,47,235,11,255,172,144,248,0,0,0,
                0,2,0,0,0,0,0,16,102,0,0,0,1,0,0,32,0,0,0,217,
                126,32,1,65,110,140,45,9,201,159,165,16,31,134,
                240,224,126,104,36,23,238,173,13,212,57,81,15,
                112,65,170,31,0,0,0,0,14,128,0,0,0,2,0,0,32,0,
                0,0,31,158,25,114,234,47,241,108,111,137,11,0,
                177,83,249,166,78,51,69,56,155,42,133,97,44,59,
                137,213,237,236,74,248,16,0,0,0,188,24,126,13,
                32,173,58,61,78,40,134,181,230,107,217,118,64,
                0,0,0,64,212,16,65,212,80,87,169,177,139,178,75,
                156,243,59,190,198,16,20,235,16,231,102,224,23,
                78,14,191,19,184,166,70,43,22,220,132,207,212,
                98,110,191,0,34,203,96,84,114,58,37,121,84,63,
                128,25,124,231,186,229,53,58,182,30,94,163,
            };
        }

        [TestMethod]
        public void TestEncrypting()
        {
            byte[] encrypted = ProtectData(_data);
            Assert.AreEqual(_expected.ToString(), encrypted.ToString());
        }

        [TestMethod]
        public void TestDecrypting()
        {
            string decrypted = UnprotectData(_expected);
            Assert.AreEqual(_data, decrypted);
        }
    }
}
