using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonLibrary.Template
{
    public abstract class DataMiner
    {
        protected string result;
        public void Mine(string path)
        {
            var file = OpenFile(path);
            var rawData = ExtractData(file);
            var data = ParseData(rawData);
            data = PreProcess(data);
            var analysis = AnalyzeData(data);
            analysis = PostProcess(analysis);
            SendReport(analysis);
            CloseFile(file);
        }

        public abstract Stream OpenFile(string path);
        public abstract string ExtractData(Stream file);
        public abstract string ParseData(string rawData);

        public virtual string AnalyzeData(string data)
            => $"วิเคราะห์ข้อมูลเสร็จสิ้น, {data}";

        public virtual void SendReport(string analysis)
            => Console.WriteLine($"ส่งอีเมล์เสร็จสิ้น, ข้อมูลคือ: {analysis}");

        public virtual void CloseFile(Stream file)
           => file.Dispose();

        public virtual string PreProcess(string data)
            => data;

        public virtual string PostProcess(string data)
            => data;
    }
    public class PDFDataMiner : DataMiner
    {
        public override Stream OpenFile(string path)
            => Stream.Null;

        public override string ExtractData(Stream file)
            => "PDF_FILE_FORMAT";

        public override string ParseData(string rawData)
            => rawData.Replace("_", " ");
    }
    public class HtmlDataMiner : DataMiner
    {
        public override Stream OpenFile(string path)
            => Stream.Null;

        public override string ExtractData(Stream file)
            => "<body>Hello world</body>";

        public override string ParseData(string rawData)
            => rawData.Replace("<body>", " ").Replace("</body>", " ");

        public override string PreProcess(string data)
            => $"PRE-Process {data}";

        public override string PostProcess(string data)
            => $"{data} POST-Process";
    }
}
