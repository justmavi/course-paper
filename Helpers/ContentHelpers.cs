using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoursePaper.Types;
using System.Windows.Forms;
using System.Drawing;
using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace CoursePaper.Helpers
{
    static internal class ContentHelpers
    {
        private static readonly string path = Path.Combine(Directory.GetCurrentDirectory(), "content");
        public static string ContentPath { get => path; }

        public async static Task<string> ReadOrWrite(string filename, string content)
        {

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            string filePath = Path.Combine(path, filename);

            if (!File.Exists(filePath))
            {
                using (var stream = new StreamWriter(filePath))
                {
                    await stream.WriteLineAsync(content);
                }

                return content;
            }

            using (var reader = new StreamReader(filePath))
            {
                content = await reader.ReadToEndAsync();
            }

            return content;
        }

        public static Tip ParseTipFromLine(string line) 
        {
            string caption;
            string content;

            if (line.StartsWith("#"))
            {
                int separatorIndex = line.IndexOf('\n');
                caption = line.Substring(1, separatorIndex);
                content = line.Substring(separatorIndex + 1, line.Length - separatorIndex - 1);
            }
            else
            {
                content = line;
                caption = null;
            }

            return new Tip { Content = content, Caption = caption };
        }

        public static void SetTip(this TipsForm form, Tip tip)
        {
            if (tip is null) return;


            form.captionLabel.Text = tip.Caption ?? "Առանց վերնագրի";
            form.tipsRichBox.Text = string.IsNullOrEmpty(tip.Content) ? "Խորհուրդներ չկան" : tip.Content;
        }

        public static List<Image> LoadImagesFromDirectory(string imageFolder)
        {
            string fullPathToImages = Path.Combine(path, imageFolder);

            if (!Directory.Exists(fullPathToImages))
            {
                Directory.CreateDirectory(fullPathToImages);
            }

            var files = Directory.EnumerateFiles(fullPathToImages)
                .Where(file => file.EndsWith(".jpg") || file.EndsWith(".jpeg") || file.EndsWith(".png"));
            
            var images = new List<Image>();

            foreach (var file in files)
            {
                images.Add(Image.FromFile(Path.Combine(fullPathToImages, file)));
            }

            return images;
        }

        public static void UpdateTime(this MainAppForm form)
        {
            form.dateLabel.Text = DateTime.Now.ToString("dd/MM/yyyy");
            form.dayLabel.Text = DateTime.Now.ToString("dddd", new CultureInfo("hy-AM"));
            form.monthLabel.Text = DateTime.Now.ToString("MMMM", new CultureInfo("hy-AM"));
            form.timeLabel.Text = DateTime.Now.ToString("HH:mm:ss");
        }

        public static async Task UpdateCurrencies(this MainAppForm form)
        {
            try
            {
                string body = await RequestHelpers.GetCurrencyRates("AMD", form.currencyRateLabels.Keys.ToArray());

                var results = ((JObject)JsonConvert.DeserializeObject(body))["results"];

                decimal currencyRate;
                foreach (var item in form.currencyRateLabels)
                {
                    if (results[item.Key] is null) continue;

                    currencyRate = 1 / results[item.Key].Value<decimal>();
                    item.Value.Text = currencyRate.ToString("#.###", new CultureInfo("hy-AM")) + " ֏";
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);

                var result = MessageBox.Show("Չստացվեց թարմացնել տարադրամի կուրսը։ Ստուգեք կապը ինտերնետի հետ և փորձեք կրկին",
                    "Խնդիր",
                    MessageBoxButtons.RetryCancel,
                    MessageBoxIcon.Error);

                if (result == DialogResult.Retry)
                {
                    await UpdateCurrencies(form);
                }
            }
        }

        public static Fibonacci GetFibonacci(int n)
        {
            long temp;
            long prev1 = 0;
            long prev2 = 1;

            string text = string.Empty;

            long currentNumber;

            while (prev1 + prev1 >= 0)
            {
                currentNumber = prev1 + prev2;
                text += currentNumber;

                if (text.Length >= n)
                {
                    return new Fibonacci
                    {
                        Result = (int)char.GetNumericValue(text[n - 1]),
                        Number = currentNumber
                    };
                }

                temp = prev1;
                prev1 = prev2;
                prev2 += temp;
            }

            return null;
        }
    }
}
