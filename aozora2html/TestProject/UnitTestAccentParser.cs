using Xunit;

namespace TestProject
{
    public class UnitTestAccentParser
    {
        [Fact]
        public void TestNew()
        {
            var str = "�ke'tiquette�l\r\n";
            using (var sr = new System.IO.StringReader(str))
            {
                var stream = new Aozora.Jstream(sr);
                var output = new Aozora.Helpers.OutputConsole();
                var parsed = new Aozora.Helpers.AccentParser(stream, '�l', new(), new(), output, gaiji_dir: "g_dir/").process().to_html();
                Assert.Equal(@"�k<img src=""g_dir/1-09/1-09-63.png"" alt=""��(�A�L���[�g�A�N�Z���g�t��E������)"" class=""gaiji"" />tiquette", parsed);
            }
        }

        [Fact]
        public void TestInvalid()
        {
            var str = "�ke'tiquette\r\n";
            using (var sr = new System.IO.StringReader(str))
            {
                var stream = new Aozora.Jstream(sr);
                var output = new Aozora.Helpers.OutputConsole();
                var warn = new Aozora.Helpers.OutputString();
                var parsed = new Aozora.Helpers.AccentParser(stream, '�l', new(), new(), output, warnChannel: warn, gaiji_dir: "g_dir/").process().to_html();
                //kurema:���̃e�X�g�ł͍s����"\n"�ł������A������ł�"\r\n"�ɂ��Ă��܂��B
                Assert.Equal("�x��(1�s��):�A�N�Z���g�����̋T�b���ʂ̎n�߂ƏI��肪�A�s���ő����Ă��܂���\r\n", warn.ToString());
            }
        }

        [Fact]
        public void TestUseJisx0213()
        {
            var str = "�ke'tiquette�l\r\n";
            using (var sr = new System.IO.StringReader(str))
            {
                var stream = new Aozora.Jstream(sr);
                var output = new Aozora.Helpers.OutputConsole();
                var parsed = new Aozora.Helpers.AccentParser(stream, '�l', new(), new(), output, gaiji_dir: "g_dir/") { use_jisx0213_accent = true }.process().to_html();
                Assert.Equal(@"�k&#x00E9;tiquette", parsed);
            }
        }
    }
}