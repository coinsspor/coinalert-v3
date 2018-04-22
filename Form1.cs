using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.IO;
using System.Text.RegularExpressions;

namespace WindowsFormsApp8
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            listBox2.DrawItem += new DrawItemEventHandler(listBox2_DrawItem);
            listBox3.DrawItem += new DrawItemEventHandler(listBox3_DrawItem);
            listBox5.DrawItem += new DrawItemEventHandler(listBox5_DrawItem);
            listBox7.DrawItem += new DrawItemEventHandler(listBox7_DrawItem);
            listBox9.DrawItem += new DrawItemEventHandler(listBox9_DrawItem);
            listBox11.DrawItem += new DrawItemEventHandler(listBox11_DrawItem);
            listBox13.DrawItem += new DrawItemEventHandler(listBox13_DrawItem);
            listBox51.DrawItem += new DrawItemEventHandler(listBox51_DrawItem);
            listBox53.DrawItem += new DrawItemEventHandler(listBox53_DrawItem);
            listBox55.DrawItem += new DrawItemEventHandler(listBox55_DrawItem);
            listBox57.DrawItem += new DrawItemEventHandler(listBox57_DrawItem);
            listBox59.DrawItem += new DrawItemEventHandler(listBox59_DrawItem);
            listBox61.DrawItem += new DrawItemEventHandler(listBox61_DrawItem);
            listBox63.DrawItem += new DrawItemEventHandler(listBox63_DrawItem);
            listBox23.DrawItem += new DrawItemEventHandler(listBox23_DrawItem);
            listBox25.DrawItem += new DrawItemEventHandler(listBox25_DrawItem);
            listBox27.DrawItem += new DrawItemEventHandler(listBox27_DrawItem);
            listBox29.DrawItem += new DrawItemEventHandler(listBox29_DrawItem);
            listBox31.DrawItem += new DrawItemEventHandler(listBox31_DrawItem);
            listBox33.DrawItem += new DrawItemEventHandler(listBox33_DrawItem);
            listBox35.DrawItem += new DrawItemEventHandler(listBox35_DrawItem);
            listBox71.DrawItem += new DrawItemEventHandler(listBox71_DrawItem);
            listBox69.DrawItem += new DrawItemEventHandler(listBox69_DrawItem);
            listBox49.DrawItem += new DrawItemEventHandler(listBox49_DrawItem);
            listBox47.DrawItem += new DrawItemEventHandler(listBox47_DrawItem);
            listBox45.DrawItem += new DrawItemEventHandler(listBox45_DrawItem);
            listBox43.DrawItem += new DrawItemEventHandler(listBox43_DrawItem);
            listBox41.DrawItem += new DrawItemEventHandler(listBox41_DrawItem);
            listBox89.DrawItem += new DrawItemEventHandler(listBox89_DrawItem);
            listBox87.DrawItem += new DrawItemEventHandler(listBox87_DrawItem);
            listBox85.DrawItem += new DrawItemEventHandler(listBox85_DrawItem);
            listBox83.DrawItem += new DrawItemEventHandler(listBox83_DrawItem);
            listBox81.DrawItem += new DrawItemEventHandler(listBox81_DrawItem);
            listBox79.DrawItem += new DrawItemEventHandler(listBox79_DrawItem);
            listBox77.DrawItem += new DrawItemEventHandler(listBox77_DrawItem);
            listBox73.DrawItem += new DrawItemEventHandler(listBox73_DrawItem);
            listBox76.DrawItem += new DrawItemEventHandler(listBox76_DrawItem);
            listBox93.DrawItem += new DrawItemEventHandler(listBox93_DrawItem);
            listBox92.DrawItem += new DrawItemEventHandler(listBox92_DrawItem);
            listBox121.DrawItem += new DrawItemEventHandler(listBox121_DrawItem);
            listBox122.DrawItem += new DrawItemEventHandler(listBox122_DrawItem);
            listBox102.DrawItem += new DrawItemEventHandler(listBox102_DrawItem);
            listBox104.DrawItem += new DrawItemEventHandler(listBox104_DrawItem);
            listBox101.DrawItem += new DrawItemEventHandler(listBox102_DrawItem);
            listBox103.DrawItem += new DrawItemEventHandler(listBox103_DrawItem);
            listBox108.DrawItem += new DrawItemEventHandler(listBox108_DrawItem);
            listBox107.DrawItem += new DrawItemEventHandler(listBox107_DrawItem);
            listBox114.DrawItem += new DrawItemEventHandler(listBox114_DrawItem);
            listBox113.DrawItem += new DrawItemEventHandler(listBox113_DrawItem);
            listBox109.DrawItem += new DrawItemEventHandler(listBox109_DrawItem);
            listBox110.DrawItem += new DrawItemEventHandler(listBox110_DrawItem);
            listBox111.DrawItem += new DrawItemEventHandler(listBox111_DrawItem);
            listBox112.DrawItem += new DrawItemEventHandler(listBox112_DrawItem);
            listBox106.DrawItem += new DrawItemEventHandler(listBox106_DrawItem);
            listBox105.DrawItem += new DrawItemEventHandler(listBox105_DrawItem);
            listBox121.DrawItem += new DrawItemEventHandler(listBox121_DrawItem);
            listBox122.DrawItem += new DrawItemEventHandler(listBox122_DrawItem);

            listBox99.DrawItem += new DrawItemEventHandler(listBox99_DrawItem);
            listBox100.DrawItem += new DrawItemEventHandler(listBox100_DrawItem);
            listBox115.DrawItem += new DrawItemEventHandler(listBox115_DrawItem);
            listBox116.DrawItem += new DrawItemEventHandler(listBox116_DrawItem);


        }

        public string postyolla(string pdata)
        {


            HttpWebRequest istek = (HttpWebRequest)WebRequest.Create("https://scanner.tradingview.com/crypto/scan");
            string postData = pdata;
            var byteData = ASCIIEncoding.ASCII.GetBytes(postData);
            istek.Method = WebRequestMethods.Http.Post;
            istek.ContentType = "application/x-www-form-urlencoded";
            istek.ContentLength = byteData.Length;
            var stream = istek.GetRequestStream();
            stream.Write(byteData, 0, byteData.Length);
            stream.Close();
            HttpWebResponse yanit = (HttpWebResponse)istek.GetResponse();
            StreamReader okuyucu = new StreamReader(yanit.GetResponseStream());
            string kaynak = okuyucu.ReadToEnd().ToString();
            okuyucu.Close(); okuyucu.Dispose();
            yanit.Close(); yanit.Dispose();



            return kaynak;
        }
        public string[] coinyuzdeal(string kaynak)
        {
            string[] dizicoinyuzdesi = new string[250];
            string startY = ":\\[\"";
            string endY = ",\"";
            string patternY = startY + ".*?" + endY;
            int j = 0;
            foreach (string eleman in dizicoinyuzdesi)
            {
                dizicoinyuzdesi[j] = null;
                j++;

            }


            int jj = 0;
            foreach (Match match in Regex.Matches(kaynak, patternY))

            {

                textBox1.Text = null;
                string xY = match.Value.Replace(startY, "").Replace(endY, "");


                //char[] karakterler = xY.ToCharArray();
                //foreach (char karakter in karakterler)
                //{
                //if (karakter !=",- )
                //{
                //textBox1.Text = textBox1.Text + karakter;
                //}
                int uzun = xY.Length;
                int konum = xY.IndexOf(",", 0);
                string alinan = xY.Substring(konum, uzun - konum);


                int bak = alinan.IndexOf(",-", 0);
                string yaz = "";
                string yaz1 = "";

                if (bak == -1)
                {


                    if (alinan.IndexOf("e+02", 0) != -1)
                    {
                        yaz = alinan.Substring(1, 4);
                        yaz1 = alinan.Substring(5, 2);
                        char[] karakterler = yaz.ToCharArray();
                        foreach (char karakter in karakterler)
                        {
                            if (karakter != '.')
                            {
                                textBox1.Text += karakter;
                            }

                        }

                        dizicoinyuzdesi[jj] = (textBox1.Text + "." + yaz1 + "%");
                        jj++;
                    }
                    else if (alinan.IndexOf("e+01", 0) != -1)
                    {
                        yaz = alinan.Substring(1, 3);
                        yaz1 = alinan.Substring(4, 2);
                        char[] karakterler = yaz.ToCharArray();
                        foreach (char karakter in karakterler)
                        {
                            if (karakter != '.')
                            {
                                textBox1.Text += karakter;
                            }

                        }
                        dizicoinyuzdesi[jj] = (textBox1.Text + "." + yaz1 + "%"); jj++;
                    }
                    else if (alinan.IndexOf("e+00", 0) != -1 && alinan.IndexOf(".", 0) != -1)
                    {
                        yaz = alinan.Substring(1, 2);
                        yaz1 = alinan.Substring(3, 2);
                        char[] karakterler = yaz.ToCharArray();
                        foreach (char karakter in karakterler)
                        {
                            if (karakter != '.')
                            {
                                textBox1.Text += karakter;
                            }

                        }
                        dizicoinyuzdesi[jj] = (textBox1.Text + "." + yaz1 + "%"); jj++;
                    }
                    else if (alinan.IndexOf("e-01", 0) != -1)
                    {
                        yaz = alinan.Substring(1, 3);
                        yaz1 = alinan.Substring(4, 2);
                        char[] karakterler = yaz.ToCharArray();
                        foreach (char karakter in karakterler)
                        {
                            if (karakter != '.')
                            {
                                textBox1.Text += karakter;
                            }

                        }
                        dizicoinyuzdesi[jj] = ("0." + textBox1.Text + "%"); jj++;
                    }
                    else if (alinan.IndexOf("e-02", 0) != -1)
                    {
                        yaz = alinan.Substring(1, 2);
                        yaz1 = alinan.Substring(3, 2);
                        char[] karakterler = yaz.ToCharArray();
                        foreach (char karakter in karakterler)
                        {
                            if (karakter != '.')
                            {
                                textBox1.Text += karakter;
                            }

                        }
                        dizicoinyuzdesi[jj] = ("0.0" + textBox1.Text + "%"); jj++;
                    }

                }
                else
                {

                    if (alinan.IndexOf("e+02", 0) != -1)
                    {
                        yaz = alinan.Substring(1, 5);
                        yaz1 = alinan.Substring(6, 2);
                        char[] karakterler = yaz.ToCharArray();
                        foreach (char karakter in karakterler)
                        {
                            if (karakter != '.')
                            {
                                textBox1.Text += karakter;
                            }

                        }
                        dizicoinyuzdesi[jj] = (textBox1.Text + "." + yaz1 + "%"); jj++;
                    }
                    else if (alinan.IndexOf("e+01", 0) != -1)
                    {
                        yaz = alinan.Substring(1, 4);
                        yaz1 = alinan.Substring(5, 2);
                        char[] karakterler = yaz.ToCharArray();
                        foreach (char karakter in karakterler)
                        {
                            if (karakter != '.')
                            {
                                textBox1.Text += karakter;
                            }

                        }
                        dizicoinyuzdesi[jj] = (textBox1.Text + "." + yaz1 + "%"); jj++;
                    }
                    else if (alinan.IndexOf("e+00", 0) != -1)
                    {
                        yaz = alinan.Substring(1, 3);
                        yaz1 = alinan.Substring(4, 2);
                        char[] karakterler = yaz.ToCharArray();
                        foreach (char karakter in karakterler)
                        {
                            if (karakter != '.')
                            {
                                textBox1.Text += karakter;
                            }

                        }
                        dizicoinyuzdesi[jj] = (textBox1.Text + "." + yaz1 + "%"); jj++;
                    }
                    else if (alinan.IndexOf("e-01", 0) != -1)
                    {
                        yaz = alinan.Substring(2, 3);
                        yaz1 = alinan.Substring(5, 2);
                        char[] karakterler = yaz.ToCharArray();
                        foreach (char karakter in karakterler)
                        {
                            if (karakter != '.')
                            {
                                textBox1.Text += karakter;
                            }

                        }
                        dizicoinyuzdesi[jj] = ("-0." + textBox1.Text + "%"); jj++;
                    }
                    else if (alinan.IndexOf("e-02", 0) != -1)
                    {
                        yaz = alinan.Substring(3, 2);
                        yaz1 = alinan.Substring(4, 2);
                        char[] karakterler = yaz.ToCharArray();
                        foreach (char karakter in karakterler)
                        {
                            if (karakter != '.')
                            {
                                textBox1.Text += karakter;
                            }

                        }
                        dizicoinyuzdesi[jj] = ("-0.0" + textBox1.Text + "%"); jj++;
                    }
                }
                if (alinan.IndexOf("0e+00", 0) != -1)
                {
                    dizicoinyuzdesi[jj] = ("0.00" + "%"); jj++;
                }
            }





            string[] parts = kaynak.Split('+');
            string kaynak2 = parts[parts.Length - 1];




            return dizicoinyuzdesi;

            
        }
        public string[] coinlistal(string kaynak)
        {
            string start = "\\[\"";
            string end = "BTC";
            string pattern = start + ".*?" + end;


            int uzunluk;
            int i = 0;
            string[] dizicoinlistesi = new string[250];

            int j = 0;
            foreach (string eleman in dizicoinlistesi)
            {
                dizicoinlistesi[j] = null;
                j++;

            }


            foreach (Match match in Regex.Matches(kaynak, pattern))
            {

                string x = match.Value.Replace(start, "").Replace(end, "");
                uzunluk = x.Length;
                string y = x.Substring(2, uzunluk - 2);
                dizicoinlistesi[i] = y;
                i = i + 1;
            }

            return dizicoinlistesi;
        }


        int saniye = 45;
        int saniye2 = 45;
        int saniye3 = 5;

        private void button1_Click(object sender, EventArgs e)
        {
            saniye = 45;
            saniye2 = 45;
            saniye3 = 5;

            label75.Text = "45";
            label38.Text = "45";
            label68.Text = "45";
            label94.Text = "45";
            label131.Text = "45";
            label128.Text = "5";
            listBox1.Items.Clear();
            listBox2.Items.Clear();
            listBox3.Items.Clear();
            listBox4.Items.Clear();
            listBox5.Items.Clear();
            listBox6.Items.Clear();
            listBox7.Items.Clear();
            listBox8.Items.Clear();
            listBox9.Items.Clear();
            listBox10.Items.Clear();
            listBox11.Items.Clear();
            listBox12.Items.Clear();
            listBox13.Items.Clear();
            listBox14.Items.Clear();
            listBox15.Items.Clear();
            listBox16.Items.Clear();
            listBox17.Items.Clear();
            listBox18.Items.Clear();

            string ma50post1hour = "{\"filter\":[{\"left\":\"change|60\",\"operation\":\"nempty\"},{\"left\":\"exchange\",\"operation\":\"equal\",\"right\":\"BINANCE\"},{\"left\":\"SMA50|60\",\"operation\":\"crosses_below\",\"right\":\"close|60\"},{\"left\":\"name\",\"operation\":\"match\",\"right\":\"btc\"}],\"symbols\":{\"query\":{\"types\":[]}},\"columns\":[\"name\",\"change|60\",\"name\",\"subtype\"],\"sort\":{\"sortBy\":\"change|60\",\"sortOrder\":\"desc\"},\"options\":{\"lang\":\"tr\"},\"range\":[0,150]}";
            string ma501hourkaynak = postyolla(ma50post1hour);
            string[] ma50coinlist = coinlistal(ma501hourkaynak);
            string[] ma50coinyuzdelistesi = coinyuzdeal(ma501hourkaynak);

            string ma100post1hour = "{\"filter\":[{\"left\":\"change|60\",\"operation\":\"nempty\"},{\"left\":\"exchange\",\"operation\":\"equal\",\"right\":\"BINANCE\"},{\"left\":\"SMA100|60\",\"operation\":\"crosses_below\",\"right\":\"close|60\"},{\"left\":\"name\",\"operation\":\"match\",\"right\":\"btc\"}],\"symbols\":{\"query\":{\"types\":[]}},\"columns\":[\"name\",\"change|60\",\"name\",\"subtype\"],\"sort\":{\"sortBy\":\"change|60\",\"sortOrder\":\"desc\"},\"options\":{\"lang\":\"tr\"},\"range\":[0,150]}";
            string ma1001hourkaynak = postyolla(ma100post1hour);
            string[] ma100coinlist = coinlistal(ma1001hourkaynak);
            string[] ma100coinyuzdelistesi = coinyuzdeal(ma1001hourkaynak);

            string ma200post1hour = "{\"filter\":[{\"left\":\"change|60\",\"operation\":\"nempty\"},{\"left\":\"exchange\",\"operation\":\"equal\",\"right\":\"BINANCE\"},{\"left\":\"SMA200|60\",\"operation\":\"crosses_below\",\"right\":\"close|60\"},{\"left\":\"name\",\"operation\":\"match\",\"right\":\"btc\"}],\"symbols\":{\"query\":{\"types\":[]}},\"columns\":[\"name\",\"change|60\",\"name\",\"subtype\"],\"sort\":{\"sortBy\":\"change|60\",\"sortOrder\":\"desc\"},\"options\":{\"lang\":\"tr\"},\"range\":[0,150]}";
            string ma2001hourkaynak = postyolla(ma200post1hour);
            string[] ma200coinlist = coinlistal(ma2001hourkaynak);
            string[] ma200coinyuzdelistesi = coinyuzdeal(ma2001hourkaynak);

            string bbaltpost1hour = "{\"filter\":[{\"left\":\"change|60\",\"operation\":\"nempty\"},{\"left\":\"exchange\",\"operation\":\"equal\",\"right\":\"BINANCE\"},{\"left\":\"BB.lower|60\",\"operation\":\"crosses_below\",\"right\":\"close|60\"},{\"left\":\"name\",\"operation\":\"match\",\"right\":\"btc\"}],\"symbols\":{\"query\":{\"types\":[]}},\"columns\":[\"name\",\"change|60\",\"name\",\"subtype\"],\"sort\":{\"sortBy\":\"change|60\",\"sortOrder\":\"desc\"},\"options\":{\"lang\":\"tr\"},\"range\":[0,150]}";
            string bbalt1hourkaynak = postyolla(bbaltpost1hour);
            string[] bbaltcoinlist = coinlistal(bbalt1hourkaynak);
            string[] bbaltcoinyuzdelistesi = coinyuzdeal(bbalt1hourkaynak);

            string bbustpost1hour = "{\"filter\":[{\"left\":\"change|60\",\"operation\":\"nempty\"},{\"left\":\"exchange\",\"operation\":\"equal\",\"right\":\"BINANCE\"},{\"left\":\"BB.upper|60\",\"operation\":\"crosses_below\",\"right\":\"close|60\"},{\"left\":\"name\",\"operation\":\"match\",\"right\":\"btc\"}],\"symbols\":{\"query\":{\"types\":[]}},\"columns\":[\"name\",\"change|60\",\"name\",\"subtype\"],\"sort\":{\"sortBy\":\"change|60\",\"sortOrder\":\"desc\"},\"options\":{\"lang\":\"tr\"},\"range\":[0,150]}";
            string bbust1hourkaynak = postyolla(bbustpost1hour);
            string[] bbustcoinlist = coinlistal(bbust1hourkaynak);
            string[] bbustcoinyuzdelistesi = coinyuzdeal(bbust1hourkaynak);

            string MACDpost1hour = "{\"filter\":[{\"left\":\"MACD.macd|60\",\"operation\":\"nempty\"},{\"left\":\"exchange\",\"operation\":\"equal\",\"right\":\"BINANCE\"},{\"left\":\"RSI|60\",\"operation\":\"in_range\",\"right\":[0,120]},{\"left\":\"ADX|60\",\"operation\":\"greater\",\"right\":20},{\"left\":\"MACD.macd|60\",\"operation\":\"crosses_above\",\"right\":\"MACD.signal|60\"},{\"left\":\"name\",\"operation\":\"match\",\"right\":\"btc\"}],\"symbols\":{\"query\":{\"types\":[]}},\"columns\":[\"name\",\"RSI|60\",\"name\",\"subtype\",\"RSI|60\",\"RSI[1]|60\"],\"sort\":{\"sortBy\":\"MACD.macd|60\",\"sortOrder\":\"desc\"},\"options\":{\"lang\":\"tr\"},\"range\":[0,150]}";
            string MACD1hourkaynak = postyolla(MACDpost1hour);
            string[] MACDcoinlist = coinlistal(MACD1hourkaynak);
            string[] MACDcoinyuzdelistesi = coinyuzdeal(MACD1hourkaynak);


            string MA10MA50post1hour = "{\"filter\":[{\"left\":\"change|60\",\"operation\":\"nempty\"},{\"left\":\"exchange\",\"operation\":\"equal\",\"right\":\"BINANCE\"},{\"left\":\"SMA10|60\",\"operation\":\"crosses_above\",\"right\":\"SMA50|60\"},{\"left\":\"name\",\"operation\":\"match\",\"right\":\"btc\"}],\"symbols\":{\"query\":{\"types\":[]}},\"columns\":[\"name\",\"change|60\",\"name\",\"subtype\"],\"sort\":{\"sortBy\":\"change|60\",\"sortOrder\":\"desc\"},\"options\":{\"lang\":\"tr\"},\"range\":[0,150]}";
            string MA10MA501hourkaynak = postyolla(MA10MA50post1hour);
            string[] MA10MA50coinlist = coinlistal(MA10MA501hourkaynak);
            string[] MA10MA50coinyuzdelistesi = coinyuzdeal(MA10MA501hourkaynak);

            string GAINERSpost1hour = "{\"filter\":[{\"left\":\"change|60\",\"operation\":\"nempty\"},{\"left\":\"exchange\",\"operation\":\"equal\",\"right\":\"BINANCE\"},{\"left\":\"change|60\",\"operation\":\"greater\",\"right\":0},{\"left\":\"name\",\"operation\":\"match\",\"right\":\"BTC\"}],\"symbols\":{\"query\":{\"types\":[]}},\"columns\":[\"name\",\"change|60\",\"name\",\"subtype\"],\"sort\":{\"sortBy\":\"change|60\",\"sortOrder\":\"desc\"},\"options\":{\"lang\":\"tr\"},\"range\":[0,150]}";
            string GAINERS1hourkaynak = postyolla(GAINERSpost1hour);
            string[] GAINERScoinlist = coinlistal(GAINERS1hourkaynak);
            string[] GAINERScoinyuzdelistesi = coinyuzdeal(GAINERS1hourkaynak);

            string LOSERSpost1hour = "{\"filter\":[{\"left\":\"change|60\",\"operation\":\"nempty\"},{\"left\":\"exchange\",\"operation\":\"equal\",\"right\":\"BINANCE\"},{\"left\":\"change|60\",\"operation\":\"less\",\"right\":0},{\"left\":\"name\",\"operation\":\"match\",\"right\":\"btc\"}],\"symbols\":{\"query\":{\"types\":[]}},\"columns\":[\"name\",\"change|60\",\"name\",\"subtype\"],\"sort\":{\"sortBy\":\"change|60\",\"sortOrder\":\"asc\"},\"options\":{\"lang\":\"tr\"},\"range\":[0,150]}";
            string LOSERS1hourkaynak = postyolla(LOSERSpost1hour);
            string[] LOSERScoinlist = coinlistal(LOSERS1hourkaynak);
            string[] LOSERScoinyuzdelistesi = coinyuzdeal(LOSERS1hourkaynak);
            
                foreach (string eleman in ma50coinlist)
            {
                if (eleman == null) break;
                listBox1.Items.Add(eleman + "BTC");

            }

            foreach (string yuzdedegeri in ma50coinyuzdelistesi)
            {
                if (yuzdedegeri == null) break;
                listBox2.Items.Add(yuzdedegeri );
            }
            /////////////////////////////////////////////////////////////////////////
            foreach (string eleman in ma100coinlist)
            {
                if (eleman == null) break;
                listBox4.Items.Add(eleman + "BTC");

            }

            foreach (string yuzdedegeri in ma100coinyuzdelistesi)
            {
                if (yuzdedegeri == null) break;
                listBox3.Items.Add(yuzdedegeri );

            }
            /////////////////////////////////////////////////////////////////////////
            foreach (string eleman in ma200coinlist)
            {
                if (eleman == null) break;
                listBox6.Items.Add(eleman + "BTC");

            }

            foreach (string yuzdedegeri in ma200coinyuzdelistesi)
            {
                if (yuzdedegeri == null) break;
                listBox5.Items.Add(yuzdedegeri );
            }
            /////////////////////////////////////////////////////////////////////////////

            foreach (string eleman in bbaltcoinlist)
            {
                if (eleman == null) break;
                listBox10.Items.Add(eleman + "BTC");

            }

            foreach (string yuzdedegeri in bbaltcoinyuzdelistesi)
            {
                if (yuzdedegeri == null) break;
                listBox9.Items.Add(yuzdedegeri);
            }
            ////////////////////////////////////////////////////////////////////////////
            foreach (string eleman in bbustcoinlist)
            {
                if (eleman == null) break;
                listBox12.Items.Add(eleman + "BTC");

            }

            foreach (string yuzdedegeri in bbustcoinyuzdelistesi)
            {
                if (yuzdedegeri == null) break;
                listBox11.Items.Add(yuzdedegeri);
            }
            //////////////////////////////////////////////////////////////////////////////
            foreach (string eleman in MACDcoinlist)
            {
                if (eleman == null) break;
                listBox14.Items.Add(eleman + "BTC");

            }


            foreach (string yuzdedegeri in MACDcoinyuzdelistesi)
            {
                if (yuzdedegeri == null) break;
                listBox13.Items.Add(yuzdedegeri.Substring(0, 5));
            }
            /////////////////////////////////////////////////////////////////////////////
            foreach (string eleman in MA10MA50coinlist)
            {
                if (eleman == null) break;
                listBox8.Items.Add(eleman + "BTC");

            }


            foreach (string yuzdedegeri in MA10MA50coinyuzdelistesi)
            {
                if (yuzdedegeri == null) break;
                listBox7.Items.Add(yuzdedegeri);
            }
            /////////////////////////////////////////////////////////////////////////////////
            for(int i=0;i<=15;i++)
            {
                if (GAINERScoinyuzdelistesi[i] == null) break;
                listBox16.Items.Add(GAINERScoinlist[i]);
                listBox15.Items.Add(GAINERScoinyuzdelistesi[i]);
            }
            /////////////////////////////////////////////////////////////////////////////////
            for (int i = 0; i <= 15; i++)
            {
                if (LOSERScoinyuzdelistesi[i] == null) break;
                listBox18.Items.Add(LOSERScoinlist[i]);
                listBox17.Items.Add(LOSERScoinyuzdelistesi[i]);
            }
            timer6.Stop();
            timer4.Stop();
            timer3.Stop();
            timer2.Stop();
            timer5.Stop();
            timer7.Stop();
            if (radioButton2.Checked)
            {
                timer1.Start();
            }
            else if (radioButton1.Checked)
            {
                timer1.Stop();
            }


        }

        private void tabPage1_Click(object sender, EventArgs e)
        {
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            
        }
        
        private void timer1_Tick(object sender, EventArgs e)
        {
            saniye--;
            
            label19.Text = (saniye % 60).ToString("00");
            label19.Visible = true;

            if (saniye == 00)
            {
                timer1.Stop();
                timer1.Enabled = true;
                timer1.Interval = 1000;
                saniye = 45;
                button1_Click(sender, e);
            }
            
        }

        private void listBox7_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();

            //Varsayılan öge rengi (fırçadan)
            Brush myBrush = Brushes.Green;


            //Örneğin 0 ile başlayanları kırmızı, 1 ile başlayanları mavi yap!

            if (listBox7.Items[e.Index].ToString().StartsWith("-") == true)
            {
                myBrush = Brushes.Red;
            }
            e.Graphics.DrawString(((ListBox)sender).Items[e.Index].ToString(),
e.Font, myBrush, e.Bounds, StringFormat.GenericDefault);

            e.DrawFocusRectangle();
        }

        private void listBox9_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();

            //Varsayılan öge rengi (fırçadan)
            Brush myBrush = Brushes.Green;


            //Örneğin 0 ile başlayanları kırmızı, 1 ile başlayanları mavi yap!

            if (listBox9.Items[e.Index].ToString().StartsWith("-") == true)
            {
                myBrush = Brushes.Red;
            }
            e.Graphics.DrawString(((ListBox)sender).Items[e.Index].ToString(),
e.Font, myBrush, e.Bounds, StringFormat.GenericDefault);

            e.DrawFocusRectangle();
        }

        private void listBox2_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();

            //Varsayılan öge rengi (fırçadan)
            Brush myBrush = Brushes.Green;


            //Örneğin 0 ile başlayanları kırmızı, 1 ile başlayanları mavi yap!

            if (listBox2.Items[e.Index].ToString().StartsWith("-") == true)
            {
                myBrush = Brushes.Red;
            }
            e.Graphics.DrawString(((ListBox)sender).Items[e.Index].ToString(),
e.Font, myBrush, e.Bounds, StringFormat.GenericDefault);

            e.DrawFocusRectangle();
        }

        private void listBox3_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();

            //Varsayılan öge rengi (fırçadan)
            Brush myBrush = Brushes.Green;


            //Örneğin 0 ile başlayanları kırmızı, 1 ile başlayanları mavi yap!

            if (listBox3.Items[e.Index].ToString().StartsWith("-") == true)
            {
                myBrush = Brushes.Red;
            }
            e.Graphics.DrawString(((ListBox)sender).Items[e.Index].ToString(),
e.Font, myBrush, e.Bounds, StringFormat.GenericDefault);

            e.DrawFocusRectangle();
        }

        private void listBox5_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();

            //Varsayılan öge rengi (fırçadan)
            Brush myBrush = Brushes.Green;


            //Örneğin 0 ile başlayanları kırmızı, 1 ile başlayanları mavi yap!

            if (listBox5.Items[e.Index].ToString().StartsWith("-") == true)
            {
                myBrush = Brushes.Red;
            }
            e.Graphics.DrawString(((ListBox)sender).Items[e.Index].ToString(),
e.Font, myBrush, e.Bounds, StringFormat.GenericDefault);

            e.DrawFocusRectangle();
        }

        private void listBox11_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();

            //Varsayılan öge rengi (fırçadan)
            Brush myBrush = Brushes.Green;


            //Örneğin 0 ile başlayanları kırmızı, 1 ile başlayanları mavi yap!

            if (listBox11.Items[e.Index].ToString().StartsWith("-") == true)
            {
                myBrush = Brushes.Red;
            }
            e.Graphics.DrawString(((ListBox)sender).Items[e.Index].ToString(),
e.Font, myBrush, e.Bounds, StringFormat.GenericDefault);

            e.DrawFocusRectangle();
        }

        private void listBox13_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();

            //Varsayılan öge rengi (fırçadan)
            Brush myBrush = Brushes.Green;


            //Örneğin 0 ile başlayanları kırmızı, 1 ile başlayanları mavi yap!

            if (listBox13.Items[e.Index].ToString().StartsWith("-") == true)
            {
                myBrush = Brushes.Red;
            }
            e.Graphics.DrawString(((ListBox)sender).Items[e.Index].ToString(),
e.Font, myBrush, e.Bounds, StringFormat.GenericDefault);

            e.DrawFocusRectangle();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            saniye = 45;
            saniye2 = 45;
            saniye3 = 5;
            label19.Text = "45";
            label38.Text = "45";
            label75.Text = "45";
            label94.Text = "45";
            label131.Text = "45";
            label128.Text = "5";
            listBox50.Items.Clear();
            listBox51.Items.Clear();
            listBox52.Items.Clear();
            listBox53.Items.Clear();
            listBox54.Items.Clear();
            listBox55.Items.Clear();
            listBox56.Items.Clear();
            listBox57.Items.Clear();
            listBox58.Items.Clear();
            listBox59.Items.Clear();
            listBox60.Items.Clear();
            listBox61.Items.Clear();
            listBox62.Items.Clear();
            listBox63.Items.Clear();
            listBox64.Items.Clear();
            listBox65.Items.Clear();
            listBox66.Items.Clear();
            listBox67.Items.Clear();

            string ma50post1day = "{\"filter\":[{\"left\":\"change\",\"operation\":\"nempty\"},{\"left\":\"exchange\",\"operation\":\"equal\",\"right\":\"BINANCE\"},{\"left\":\"SMA50\",\"operation\":\"crosses_below\",\"right\":\"close\"},{\"left\":\"name,description\",\"operation\":\"match\",\"right\":\"btc\"}],\"symbols\":{\"query\":{\"types\":[]}},\"columns\":[\"name\",\"change\",\"description\",\"name\",\"subtype\"],\"sort\":{\"sortBy\":\"change\",\"sortOrder\":\"desc\"},\"options\":{\"lang\":\"tr\"},\"range\":[0,150]}";
            string ma501daykaynak = postyolla(ma50post1day);
            string[] ma50coinlist = coinlistal(ma501daykaynak);
            string[] ma50coinyuzdelistesi = coinyuzdeal(ma501daykaynak);

            string ma100post1day = "{\"filter\":[{\"left\":\"change\",\"operation\":\"nempty\"},{\"left\":\"exchange\",\"operation\":\"equal\",\"right\":\"BINANCE\"},{\"left\":\"SMA100\",\"operation\":\"crosses_below\",\"right\":\"close\"},{\"left\":\"name,description\",\"operation\":\"match\",\"right\":\"btc\"}],\"symbols\":{\"query\":{\"types\":[]}},\"columns\":[\"name\",\"change\",\"description\",\"name\",\"subtype\"],\"sort\":{\"sortBy\":\"change\",\"sortOrder\":\"desc\"},\"options\":{\"lang\":\"tr\"},\"range\":[0,150]}";
            string ma1001daykaynak = postyolla(ma100post1day);
            string[] ma100coinlist = coinlistal(ma1001daykaynak);
            string[] ma100coinyuzdelistesi = coinyuzdeal(ma1001daykaynak);

            string ma200post1day = "{\"filter\":[{\"left\":\"change\",\"operation\":\"nempty\"},{\"left\":\"exchange\",\"operation\":\"equal\",\"right\":\"BINANCE\"},{\"left\":\"SMA200\",\"operation\":\"crosses_below\",\"right\":\"close\"},{\"left\":\"name,description\",\"operation\":\"match\",\"right\":\"btc\"}],\"symbols\":{\"query\":{\"types\":[]}},\"columns\":[\"name\",\"change\",\"description\",\"name\",\"subtype\"],\"sort\":{\"sortBy\":\"change\",\"sortOrder\":\"desc\"},\"options\":{\"lang\":\"tr\"},\"range\":[0,150]}";
            string ma2001daykaynak = postyolla(ma200post1day);
            string[] ma200coinlist = coinlistal(ma2001daykaynak);
            string[] ma200coinyuzdelistesi = coinyuzdeal(ma2001daykaynak);

            string bbaltpost1day = "{\"filter\":[{\"left\":\"change\",\"operation\":\"nempty\"},{\"left\":\"exchange\",\"operation\":\"equal\",\"right\":\"BINANCE\"},{\"left\":\"change\",\"operation\":\"greater\",\"right\":0},{\"left\":\"BB.lower\",\"operation\":\"crosses_below\",\"right\":\"close\"},{\"left\":\"name,description\",\"operation\":\"match\",\"right\":\"btc\"}],\"symbols\":{\"query\":{\"types\":[]}},\"columns\":[\"name\",\"change\",\"description\",\"name\",\"subtype\"],\"sort\":{\"sortBy\":\"change\",\"sortOrder\":\"desc\"},\"options\":{\"lang\":\"tr\"},\"range\":[0,150]}";
            string bbalt1daykaynak = postyolla(bbaltpost1day);
            string[] bbaltcoinlist = coinlistal(bbalt1daykaynak);
            string[] bbaltcoinyuzdelistesi = coinyuzdeal(bbalt1daykaynak);

            string bbustpost1day = "{\"filter\":[{\"left\":\"change\",\"operation\":\"nempty\"},{\"left\":\"exchange\",\"operation\":\"equal\",\"right\":\"BINANCE\"},{\"left\":\"BB.upper\",\"operation\":\"crosses_below\",\"right\":\"close\"},{\"left\":\"name,description\",\"operation\":\"match\",\"right\":\"btc\"}],\"symbols\":{\"query\":{\"types\":[]}},\"columns\":[\"name\",\"change\",\"description\",\"name\",\"subtype\"],\"sort\":{\"sortBy\":\"change\",\"sortOrder\":\"desc\"},\"options\":{\"lang\":\"tr\"},\"range\":[0,150]}";
            string bbust1daykaynak = postyolla(bbustpost1day);
            string[] bbustcoinlist = coinlistal(bbust1daykaynak);
            string[] bbustcoinyuzdelistesi = coinyuzdeal(bbust1daykaynak);

            string MACDpost1day = "{\"filter\":[{\"left\":\"change\",\"operation\":\"nempty\"},{\"left\":\"exchange\",\"operation\":\"equal\",\"right\":\"BINANCE\"},{\"left\":\"ADX\",\"operation\":\"greater\",\"right\":20},{\"left\":\"MACD.macd\",\"operation\":\"crosses_above\",\"right\":\"MACD.signal\"},{\"left\":\"name,description\",\"operation\":\"match\",\"right\":\"btc\"}],\"symbols\":{\"query\":{\"types\":[]}},\"columns\":[\"name\",\"RSI\",\"description\",\"name\",\"subtype\",\"RSI\",\"RSI[1]\"],\"sort\":{\"sortBy\":\"change\",\"sortOrder\":\"desc\"},\"options\":{\"lang\":\"tr\"},\"range\":[0,150]}";
            string MACD1daykaynak = postyolla(MACDpost1day);
            string[] MACDcoinlist = coinlistal(MACD1daykaynak);
            string[] MACDcoinyuzdelistesi = coinyuzdeal(MACD1daykaynak);


            string MA10MA50post1day = "{\"filter\":[{\"left\":\"change\",\"operation\":\"nempty\"},{\"left\":\"exchange\",\"operation\":\"equal\",\"right\":\"BINANCE\"},{\"left\":\"SMA10\",\"operation\":\"crosses_above\",\"right\":\"SMA50\"},{\"left\":\"name,description\",\"operation\":\"match\",\"right\":\"btc\"}],\"symbols\":{\"query\":{\"types\":[]}},\"columns\":[\"name\",\"change\",\"description\",\"name\",\"subtype\"],\"sort\":{\"sortBy\":\"change\",\"sortOrder\":\"desc\"},\"options\":{\"lang\":\"tr\"},\"range\":[0,150]}";
            string MA10MA501daykaynak = postyolla(MA10MA50post1day);
            string[] MA10MA50coinlist = coinlistal(MA10MA501daykaynak);
            string[] MA10MA50coinyuzdelistesi = coinyuzdeal(MA10MA501daykaynak);

            string GAINERSpost1day = "{\"filter\":[{\"left\":\"change\",\"operation\":\"nempty\"},{\"left\":\"exchange\",\"operation\":\"equal\",\"right\":\"BINANCE\"},{\"left\":\"name,description\",\"operation\":\"match\",\"right\":\"btc\"}],\"symbols\":{\"query\":{\"types\":[]}},\"columns\":[\"name\",\"change\",\"description\",\"name\",\"subtype\"],\"sort\":{\"sortBy\":\"change\",\"sortOrder\":\"desc\"},\"options\":{\"lang\":\"tr\"},\"range\":[0,150]}";
            string GAINERS1daykaynak = postyolla(GAINERSpost1day);
            string[] GAINERScoinlist = coinlistal(GAINERS1daykaynak);
            string[] GAINERScoinyuzdelistesi = coinyuzdeal(GAINERS1daykaynak);

            string LOSERSpost1day = "{\"filter\":[{\"left\":\"change\",\"operation\":\"nempty\"},{\"left\":\"exchange\",\"operation\":\"equal\",\"right\":\"BINANCE\"},{\"left\":\"change\",\"operation\":\"less\",\"right\":0},{\"left\":\"name,description\",\"operation\":\"match\",\"right\":\"btc\"}],\"symbols\":{\"query\":{\"types\":[]}},\"columns\":[\"name\",\"change\",\"description\",\"name\",\"subtype\"],\"sort\":{\"sortBy\":\"change\",\"sortOrder\":\"asc\"},\"options\":{\"lang\":\"tr\"},\"range\":[0,150]}";
            string LOSERS1daykaynak = postyolla(LOSERSpost1day);
            string[] LOSERScoinlist = coinlistal(LOSERS1daykaynak);
            string[] LOSERScoinyuzdelistesi = coinyuzdeal(LOSERS1daykaynak);

            ////////////////////////////////////////////////////////////////////////
            foreach (string eleman in ma50coinlist)
            {
                if (eleman == null) break;
                listBox50.Items.Add(eleman + "BTC");

            }

            foreach (string yuzdedegeri in ma50coinyuzdelistesi)
            {
                if (yuzdedegeri == null) break;
                listBox51.Items.Add(yuzdedegeri);
            }
            /////////////////////////////////////////////////////////////////////////
            foreach (string eleman in ma100coinlist)
            {
                if (eleman == null) break;
                listBox52.Items.Add(eleman + "BTC");

            }

            foreach (string yuzdedegeri in ma100coinyuzdelistesi)
            {
                if (yuzdedegeri == null) break;
                listBox53.Items.Add(yuzdedegeri);

            }
            /////////////////////////////////////////////////////////////////////////
            foreach (string eleman in ma200coinlist)
            {
                if (eleman == null) break;
                listBox54.Items.Add(eleman + "BTC");

            }

            foreach (string yuzdedegeri in ma200coinyuzdelistesi)
            {
                if (yuzdedegeri == null) break;
                listBox55.Items.Add(yuzdedegeri);
            }
            /////////////////////////////////////////////////////////////////////////////

            foreach (string eleman in bbaltcoinlist)
            {
                if (eleman == null) break;
                listBox58.Items.Add(eleman + "BTC");

            }

            foreach (string yuzdedegeri in bbaltcoinyuzdelistesi)
            {
                if (yuzdedegeri == null) break;
                listBox59.Items.Add(yuzdedegeri);
            }
            ////////////////////////////////////////////////////////////////////////////
            foreach (string eleman in bbustcoinlist)
            {
                if (eleman == null) break;
                listBox60.Items.Add(eleman + "BTC");

            }

            foreach (string yuzdedegeri in bbustcoinyuzdelistesi)
            {
                if (yuzdedegeri == null) break;
                listBox61.Items.Add(yuzdedegeri);
            }
            //////////////////////////////////////////////////////////////////////////////
            foreach (string eleman in MACDcoinlist)
            {
                if (eleman == null) break;
                listBox62.Items.Add(eleman + "BTC");

            }


            foreach (string yuzdedegeri in MACDcoinyuzdelistesi)
            {
                if (yuzdedegeri == null) break;
                listBox63.Items.Add(yuzdedegeri.Substring(0,5));
            }
            /////////////////////////////////////////////////////////////////////////////
            foreach (string eleman in MA10MA50coinlist)
            {
                if (eleman == null) break;
                listBox56.Items.Add(eleman + "BTC");

            }


            foreach (string yuzdedegeri in MA10MA50coinyuzdelistesi)
            {
                if (yuzdedegeri == null) break;
                listBox57.Items.Add(yuzdedegeri);
            }
            /////////////////////////////////////////////////////////////////////////////////
            for (int i = 0; i <= 15; i++)
            {
                if (GAINERScoinyuzdelistesi[i] == null) break;
                listBox64.Items.Add(GAINERScoinlist[i]);
                listBox65.Items.Add(GAINERScoinyuzdelistesi[i]);
            }
            /////////////////////////////////////////////////////////////////////////////////
            for (int i = 0; i <= 15; i++)
            {
                if (LOSERScoinyuzdelistesi[i] == null) break;
                listBox66.Items.Add(LOSERScoinlist[i]);
                listBox67.Items.Add(LOSERScoinyuzdelistesi[i]);
            }
            timer6.Stop();
            timer4.Stop();
            timer3.Stop();
            timer5.Stop();
            timer1.Stop();
            timer7.Stop();
            if (radioButton11.Checked)
            {
                timer2.Start();
            }
            else if (radioButton10.Checked)
            {
                timer2.Stop();
            }
        }

        private void listBox51_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();

            //Varsayılan öge rengi (fırçadan)
            Brush myBrush = Brushes.Green;


            //Örneğin 0 ile başlayanları kırmızı, 1 ile başlayanları mavi yap!

            if (listBox51.Items[e.Index].ToString().StartsWith("-") == true)
            {
                myBrush = Brushes.Red;
            }
            e.Graphics.DrawString(((ListBox)sender).Items[e.Index].ToString(),
e.Font, myBrush, e.Bounds, StringFormat.GenericDefault);

            e.DrawFocusRectangle();
        }

        private void listBox53_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();

            //Varsayılan öge rengi (fırçadan)
            Brush myBrush = Brushes.Green;


            //Örneğin 0 ile başlayanları kırmızı, 1 ile başlayanları mavi yap!

            if (listBox53.Items[e.Index].ToString().StartsWith("-") == true)
            {
                myBrush = Brushes.Red;
            }
            e.Graphics.DrawString(((ListBox)sender).Items[e.Index].ToString(),
e.Font, myBrush, e.Bounds, StringFormat.GenericDefault);

            e.DrawFocusRectangle();
        }

        private void listBox55_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();

            //Varsayılan öge rengi (fırçadan)
            Brush myBrush = Brushes.Green;


            //Örneğin 0 ile başlayanları kırmızı, 1 ile başlayanları mavi yap!

            if (listBox55.Items[e.Index].ToString().StartsWith("-") == true)
            {
                myBrush = Brushes.Red;
            }
            e.Graphics.DrawString(((ListBox)sender).Items[e.Index].ToString(),
e.Font, myBrush, e.Bounds, StringFormat.GenericDefault);

            e.DrawFocusRectangle();
        }

        private void listBox57_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();

            //Varsayılan öge rengi (fırçadan)
            Brush myBrush = Brushes.Green;


            //Örneğin 0 ile başlayanları kırmızı, 1 ile başlayanları mavi yap!

            if (listBox57.Items[e.Index].ToString().StartsWith("-") == true)
            {
                myBrush = Brushes.Red;
            }
            e.Graphics.DrawString(((ListBox)sender).Items[e.Index].ToString(),
e.Font, myBrush, e.Bounds, StringFormat.GenericDefault);

            e.DrawFocusRectangle();
        }

        private void listBox59_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();

            //Varsayılan öge rengi (fırçadan)
            Brush myBrush = Brushes.Green;


            //Örneğin 0 ile başlayanları kırmızı, 1 ile başlayanları mavi yap!

            if (listBox59.Items[e.Index].ToString().StartsWith("-") == true)
            {
                myBrush = Brushes.Red;
            }
            e.Graphics.DrawString(((ListBox)sender).Items[e.Index].ToString(),
e.Font, myBrush, e.Bounds, StringFormat.GenericDefault);

            e.DrawFocusRectangle();
        }

        private void listBox61_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();

            //Varsayılan öge rengi (fırçadan)
            Brush myBrush = Brushes.Green;


            //Örneğin 0 ile başlayanları kırmızı, 1 ile başlayanları mavi yap!

            if (listBox61.Items[e.Index].ToString().StartsWith("-") == true)
            {
                myBrush = Brushes.Red;
            }
            e.Graphics.DrawString(((ListBox)sender).Items[e.Index].ToString(),
e.Font, myBrush, e.Bounds, StringFormat.GenericDefault);

            e.DrawFocusRectangle();
        }

        private void listBox63_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();

            //Varsayılan öge rengi (fırçadan)
            Brush myBrush = Brushes.Green;


            //Örneğin 0 ile başlayanları kırmızı, 1 ile başlayanları mavi yap!

            if (listBox63.Items[e.Index].ToString().StartsWith("-") == true)
            {
                myBrush = Brushes.Red;
            }
            e.Graphics.DrawString(((ListBox)sender).Items[e.Index].ToString(),
e.Font, myBrush, e.Bounds, StringFormat.GenericDefault);

            e.DrawFocusRectangle();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            saniye--;

            label68.Text = (saniye % 60).ToString("00");
            label68.Visible = true;

            if (saniye == 00)
            {
                timer2.Stop();
                timer2.Enabled = true;
                timer2.Interval = 1000;
                saniye = 45;
                button2_Click(sender, e);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            saniye = 45;
            saniye2 = 45;
            saniye3 = 5;
            label19.Text = "45";
            label75.Text = "45";
            label68.Text = "45";
            label94.Text = "45";
            label131.Text = "45";
            label128.Text = "5";
            listBox36.Items.Clear();
            listBox23.Items.Clear();
            listBox34.Items.Clear();
            listBox25.Items.Clear();
            listBox32.Items.Clear();
            listBox27.Items.Clear();
            listBox30.Items.Clear();
            listBox29.Items.Clear();
            listBox28.Items.Clear();
            listBox31.Items.Clear();
            listBox26.Items.Clear();
            listBox33.Items.Clear();
            listBox24.Items.Clear();
            listBox25.Items.Clear();
            listBox22.Items.Clear();
            listBox21.Items.Clear();
            listBox20.Items.Clear();
            listBox19.Items.Clear();
            listBox35.Items.Clear();

            string ma50post4hour = "{\"filter\":[{\"left\":\"change|240\",\"operation\":\"nempty\"},{\"left\":\"exchange\",\"operation\":\"equal\",\"right\":\"BINANCE\"},{\"left\":\"SMA50|240\",\"operation\":\"crosses_below\",\"right\":\"close|240\"},{\"left\":\"name\",\"operation\":\"match\",\"right\":\"BTC\"}],\"symbols\":{\"query\":{\"types\":[]}},\"columns\":[\"name\",\"change|240\",\"name\",\"subtype\"],\"sort\":{\"sortBy\":\"change|240\",\"sortOrder\":\"desc\"},\"options\":{\"lang\":\"tr\"},\"range\":[0,150]}";
            string ma504hourkaynak = postyolla(ma50post4hour);
            string[] ma50coinlist = coinlistal(ma504hourkaynak);
            string[] ma50coinyuzdelistesi = coinyuzdeal(ma504hourkaynak);

            string ma100post4hour = "{\"filter\":[{\"left\":\"change|240\",\"operation\":\"nempty\"},{\"left\":\"exchange\",\"operation\":\"equal\",\"right\":\"BINANCE\"},{\"left\":\"SMA100|240\",\"operation\":\"crosses_below\",\"right\":\"close|240\"},{\"left\":\"name\",\"operation\":\"match\",\"right\":\"BTC\"}],\"symbols\":{\"query\":{\"types\":[]}},\"columns\":[\"name\",\"change|240\",\"name\",\"subtype\"],\"sort\":{\"sortBy\":\"change|240\",\"sortOrder\":\"desc\"},\"options\":{\"lang\":\"tr\"},\"range\":[0,150]}";
            string ma1004hourkaynak = postyolla(ma100post4hour);
            string[] ma100coinlist = coinlistal(ma1004hourkaynak);
            string[] ma100coinyuzdelistesi = coinyuzdeal(ma1004hourkaynak);

            string ma200post4hour = "{\"filter\":[{\"left\":\"change|240\",\"operation\":\"nempty\"},{\"left\":\"exchange\",\"operation\":\"equal\",\"right\":\"BINANCE\"},{\"left\":\"SMA200|240\",\"operation\":\"crosses_below\",\"right\":\"close|240\"},{\"left\":\"name\",\"operation\":\"match\",\"right\":\"BTC\"}],\"symbols\":{\"query\":{\"types\":[]}},\"columns\":[\"name\",\"change|240\",\"name\",\"subtype\"],\"sort\":{\"sortBy\":\"change|240\",\"sortOrder\":\"desc\"},\"options\":{\"lang\":\"tr\"},\"range\":[0,150]}";
            string ma2004hourkaynak = postyolla(ma200post4hour);
            string[] ma200coinlist = coinlistal(ma2004hourkaynak);
            string[] ma200coinyuzdelistesi = coinyuzdeal(ma2004hourkaynak);

            string bbaltpost4hour = "{\"filter\":[{\"left\":\"change|240\",\"operation\":\"nempty\"},{\"left\":\"exchange\",\"operation\":\"equal\",\"right\":\"BINANCE\"},{\"left\":\"BB.lower|240\",\"operation\":\"crosses_below\",\"right\":\"close|240\"},{\"left\":\"name\",\"operation\":\"match\",\"right\":\"BTC\"}],\"symbols\":{\"query\":{\"types\":[]}},\"columns\":[\"name\",\"change|240\",\"name\",\"subtype\"],\"sort\":{\"sortBy\":\"change|240\",\"sortOrder\":\"desc\"},\"options\":{\"lang\":\"tr\"},\"range\":[0,150]}";
            string bbalt4hourkaynak = postyolla(bbaltpost4hour);
            string[] bbaltcoinlist = coinlistal(bbalt4hourkaynak);
            string[] bbaltcoinyuzdelistesi = coinyuzdeal(bbalt4hourkaynak);

            string bbustpost4hour = "{\"filter\":[{\"left\":\"change|240\",\"operation\":\"nempty\"},{\"left\":\"exchange\",\"operation\":\"equal\",\"right\":\"BINANCE\"},{\"left\":\"BB.upper|240\",\"operation\":\"crosses_below\",\"right\":\"close|240\"},{\"left\":\"name\",\"operation\":\"match\",\"right\":\"BTC\"}],\"symbols\":{\"query\":{\"types\":[]}},\"columns\":[\"name\",\"change|240\",\"name\",\"subtype\"],\"sort\":{\"sortBy\":\"change|240\",\"sortOrder\":\"desc\"},\"options\":{\"lang\":\"tr\"},\"range\":[0,150]}";
            string bbust4hourkaynak = postyolla(bbustpost4hour);
            string[] bbustcoinlist = coinlistal(bbust4hourkaynak);
            string[] bbustcoinyuzdelistesi = coinyuzdeal(bbust4hourkaynak);

            string MACDpost4hour = "{\"filter\":[{\"left\":\"MACD.macd|240\",\"operation\":\"nempty\"},{\"left\":\"exchange\",\"operation\":\"equal\",\"right\":\"BINANCE\"},{\"left\":\"RSI|240\",\"operation\":\"in_range\",\"right\":[0,120]},{\"left\":\"ADX|240\",\"operation\":\"greater\",\"right\":20},{\"left\":\"MACD.macd|240\",\"operation\":\"crosses_above\",\"right\":\"MACD.signal|240\"},{\"left\":\"name\",\"operation\":\"match\",\"right\":\"BTC\"}],\"symbols\":{\"query\":{\"types\":[]}},\"columns\":[\"name\",\"RSI|240\",\"name\",\"subtype\",\"RSI|240\",\"RSI[1]|240\"],\"sort\":{\"sortBy\":\"MACD.macd|240\",\"sortOrder\":\"desc\"},\"options\":{\"lang\":\"tr\"},\"range\":[0,150]}";
            string MACD4hourkaynak = postyolla(MACDpost4hour);
            string[] MACDcoinlist = coinlistal(MACD4hourkaynak);
            string[] MACDcoinyuzdelistesi = coinyuzdeal(MACD4hourkaynak);


            string MA10MA50post4hour = "{\"filter\":[{\"left\":\"change|240\",\"operation\":\"nempty\"},{\"left\":\"exchange\",\"operation\":\"equal\",\"right\":\"BINANCE\"},{\"left\":\"SMA10|240\",\"operation\":\"crosses_above\",\"right\":\"SMA50|240\"},{\"left\":\"name\",\"operation\":\"match\",\"right\":\"BTC\"}],\"symbols\":{\"query\":{\"types\":[]}},\"columns\":[\"name\",\"change|240\",\"name\",\"subtype\"],\"sort\":{\"sortBy\":\"change|240\",\"sortOrder\":\"desc\"},\"options\":{\"lang\":\"tr\"},\"range\":[0,150]}";
            string MA10MA504hourkaynak = postyolla(MA10MA50post4hour);
            string[] MA10MA50coinlist = coinlistal(MA10MA504hourkaynak);
            string[] MA10MA50coinyuzdelistesi = coinyuzdeal(MA10MA504hourkaynak);

            string GAINERSpost1hour = "{\"filter\":[{\"left\":\"change|240\",\"operation\":\"nempty\"},{\"left\":\"exchange\",\"operation\":\"equal\",\"right\":\"BINANCE\"},{\"left\":\"change|240\",\"operation\":\"greater\",\"right\":0},{\"left\":\"name\",\"operation\":\"match\",\"right\":\"BTC\"}],\"symbols\":{\"query\":{\"types\":[]}},\"columns\":[\"name\",\"change|240\",\"name\",\"subtype\"],\"sort\":{\"sortBy\":\"change|240\",\"sortOrder\":\"desc\"},\"options\":{\"lang\":\"tr\"},\"range\":[0,150]}";
            string GAINERS1hourkaynak = postyolla(GAINERSpost1hour);
            string[] GAINERScoinlist = coinlistal(GAINERS1hourkaynak);
            string[] GAINERScoinyuzdelistesi = coinyuzdeal(GAINERS1hourkaynak);

            string LOSERSpost1hour = "{\"filter\":[{\"left\":\"change|240\",\"operation\":\"nempty\"},{\"left\":\"exchange\",\"operation\":\"equal\",\"right\":\"BINANCE\"},{\"left\":\"change|240\",\"operation\":\"less\",\"right\":0},{\"left\":\"name\",\"operation\":\"match\",\"right\":\"BTC\"}],\"symbols\":{\"query\":{\"types\":[]}},\"columns\":[\"name\",\"change|240\",\"name\",\"subtype\"],\"sort\":{\"sortBy\":\"change|240\",\"sortOrder\":\"asc\"},\"options\":{\"lang\":\"tr\"},\"range\":[0,150]}";
            string LOSERS1hourkaynak = postyolla(LOSERSpost1hour);
            string[] LOSERScoinlist = coinlistal(LOSERS1hourkaynak);
            string[] LOSERScoinyuzdelistesi = coinyuzdeal(LOSERS1hourkaynak);

            foreach (string eleman in ma50coinlist)
            {
                if (eleman == null) break;
                listBox36.Items.Add(eleman + "BTC");

            }

            foreach (string yuzdedegeri in ma50coinyuzdelistesi)
            {
                if (yuzdedegeri == null) break;
                listBox23.Items.Add(yuzdedegeri);
            }
            /////////////////////////////////////////////////////////////////////////
            foreach (string eleman in ma100coinlist)
            {
                if (eleman == null) break;
                listBox34.Items.Add(eleman + "BTC");

            }

            foreach (string yuzdedegeri in ma100coinyuzdelistesi)
            {
                if (yuzdedegeri == null) break;
                listBox25.Items.Add(yuzdedegeri);

            }
            /////////////////////////////////////////////////////////////////////////
            foreach (string eleman in ma200coinlist)
            {
                if (eleman == null) break;
                listBox32.Items.Add(eleman + "BTC");

            }

            foreach (string yuzdedegeri in ma200coinyuzdelistesi)
            {
                if (yuzdedegeri == null) break;
                listBox27.Items.Add(yuzdedegeri);
            }
            /////////////////////////////////////////////////////////////////////////////

            foreach (string eleman in bbaltcoinlist)
            {
                if (eleman == null) break;
                listBox28.Items.Add(eleman + "BTC");

            }

            foreach (string yuzdedegeri in bbaltcoinyuzdelistesi)
            {
                if (yuzdedegeri == null) break;
                listBox31.Items.Add(yuzdedegeri);
            }
            ////////////////////////////////////////////////////////////////////////////
            foreach (string eleman in bbustcoinlist)
            {
                if (eleman == null) break;
                listBox26.Items.Add(eleman + "BTC");

            }

            foreach (string yuzdedegeri in bbustcoinyuzdelistesi)
            {
                if (yuzdedegeri == null) break;
                listBox33.Items.Add(yuzdedegeri);
            }
            //////////////////////////////////////////////////////////////////////////////
            foreach (string eleman in MACDcoinlist)
            {
                if (eleman == null) break;
                listBox24.Items.Add(eleman + "BTC");

            }


            foreach (string yuzdedegeri in MACDcoinyuzdelistesi)
            {
                if (yuzdedegeri == null) break;
                listBox35.Items.Add(yuzdedegeri.Substring(0, 5));
            }
            /////////////////////////////////////////////////////////////////////////////
            foreach (string eleman in MA10MA50coinlist)
            {
                if (eleman == null) break;
                listBox30.Items.Add(eleman + "BTC");

            }


            foreach (string yuzdedegeri in MA10MA50coinyuzdelistesi)
            {
                if (yuzdedegeri == null) break;
                listBox29.Items.Add(yuzdedegeri);
            }
            /////////////////////////////////////////////////////////////////////////////////
            for (int i = 0; i <= 15; i++)
            {
                if (GAINERScoinyuzdelistesi[i] == null) break;
                listBox22.Items.Add(GAINERScoinlist[i]);
                listBox21.Items.Add(GAINERScoinyuzdelistesi[i]);
            }
            /////////////////////////////////////////////////////////////////////////////////
            for (int i = 0; i <= 15; i++)
            {
                if (LOSERScoinyuzdelistesi[i] == null) break;
                listBox20.Items.Add(LOSERScoinlist[i]);
                listBox19.Items.Add(LOSERScoinyuzdelistesi[i]);
            }
            timer6.Stop();
            timer4.Stop();
            timer5.Stop();
            timer2.Stop();
            timer1.Stop();
            timer7.Stop();
            if (radioButton4.Checked)
            {
                timer3.Start();
            }
            else if (radioButton3.Checked)
            {
                timer3.Stop();
            }
        }

        private void listBox23_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();

            //Varsayılan öge rengi (fırçadan)
            Brush myBrush = Brushes.Green;


            //Örneğin 0 ile başlayanları kırmızı, 1 ile başlayanları mavi yap!

            if (listBox23.Items[e.Index].ToString().StartsWith("-") == true)
            {
                myBrush = Brushes.Red;
            }
            e.Graphics.DrawString(((ListBox)sender).Items[e.Index].ToString(),
e.Font, myBrush, e.Bounds, StringFormat.GenericDefault);

            e.DrawFocusRectangle();
        }

        private void listBox25_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();

            //Varsayılan öge rengi (fırçadan)
            Brush myBrush = Brushes.Green;


            //Örneğin 0 ile başlayanları kırmızı, 1 ile başlayanları mavi yap!

            if (listBox25.Items[e.Index].ToString().StartsWith("-") == true)
            {
                myBrush = Brushes.Red;
            }
            e.Graphics.DrawString(((ListBox)sender).Items[e.Index].ToString(),
e.Font, myBrush, e.Bounds, StringFormat.GenericDefault);

            e.DrawFocusRectangle();
        }

        private void listBox27_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();

            //Varsayılan öge rengi (fırçadan)
            Brush myBrush = Brushes.Green;


            //Örneğin 0 ile başlayanları kırmızı, 1 ile başlayanları mavi yap!

            if (listBox27.Items[e.Index].ToString().StartsWith("-") == true)
            {
                myBrush = Brushes.Red;
            }
            e.Graphics.DrawString(((ListBox)sender).Items[e.Index].ToString(),
e.Font, myBrush, e.Bounds, StringFormat.GenericDefault);

            e.DrawFocusRectangle();
        }

        

        private void listBox31_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();

            //Varsayılan öge rengi (fırçadan)
            Brush myBrush = Brushes.Green;


            //Örneğin 0 ile başlayanları kırmızı, 1 ile başlayanları mavi yap!

            if (listBox31.Items[e.Index].ToString().StartsWith("-") == true)
            {
                myBrush = Brushes.Red;
            }
            e.Graphics.DrawString(((ListBox)sender).Items[e.Index].ToString(),
e.Font, myBrush, e.Bounds, StringFormat.GenericDefault);

            e.DrawFocusRectangle();
        }

        private void listBox29_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();

            //Varsayılan öge rengi (fırçadan)
            Brush myBrush = Brushes.Green;


            //Örneğin 0 ile başlayanları kırmızı, 1 ile başlayanları mavi yap!

            if (listBox29.Items[e.Index].ToString().StartsWith("-") == true)
            {
                myBrush = Brushes.Red;
            }
            e.Graphics.DrawString(((ListBox)sender).Items[e.Index].ToString(),
e.Font, myBrush, e.Bounds, StringFormat.GenericDefault);

            e.DrawFocusRectangle();
        }

        private void listBox33_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();

            //Varsayılan öge rengi (fırçadan)
            Brush myBrush = Brushes.Green;


            //Örneğin 0 ile başlayanları kırmızı, 1 ile başlayanları mavi yap!

            if (listBox33.Items[e.Index].ToString().StartsWith("-") == true)
            {
                myBrush = Brushes.Red;
            }
            e.Graphics.DrawString(((ListBox)sender).Items[e.Index].ToString(),
e.Font, myBrush, e.Bounds, StringFormat.GenericDefault);

            e.DrawFocusRectangle();
        }

        private void listBox35_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();

            //Varsayılan öge rengi (fırçadan)
            Brush myBrush = Brushes.Green;


            //Örneğin 0 ile başlayanları kırmızı, 1 ile başlayanları mavi yap!

            if (listBox35.Items[e.Index].ToString().StartsWith("-") == true)
            {
                myBrush = Brushes.Red;
            }
            e.Graphics.DrawString(((ListBox)sender).Items[e.Index].ToString(),
e.Font, myBrush, e.Bounds, StringFormat.GenericDefault);

            e.DrawFocusRectangle();
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            saniye--;

            label38.Text = (saniye % 60).ToString("00");
            label38.Visible = true;

            if (saniye == 00)
            {
                timer3.Stop();
                timer3.Enabled = true;
                timer3.Interval = 1000;
                saniye = 45;
                button3_Click(sender, e);
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string link= "https://tr.tradingview.com/chart/?symbol=BINANCE:"+listBox1.SelectedItem.ToString();
            System.Diagnostics.Process.Start(link);
        }

        private void listBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            string link = "https://tr.tradingview.com/chart/?symbol=BINANCE:" + listBox4.SelectedItem.ToString();
            System.Diagnostics.Process.Start(link);
        }

        private void listBox6_SelectedIndexChanged(object sender, EventArgs e)
        {
            string link = "https://tr.tradingview.com/chart/?symbol=BINANCE:" + listBox6.SelectedItem.ToString();
            System.Diagnostics.Process.Start(link);
        }

        private void listBox8_SelectedIndexChanged(object sender, EventArgs e)
        {
            string link = "https://tr.tradingview.com/chart/?symbol=BINANCE:" + listBox8.SelectedItem.ToString();
            System.Diagnostics.Process.Start(link);
        }

        private void listBox10_SelectedIndexChanged(object sender, EventArgs e)
        {
            string link = "https://tr.tradingview.com/chart/?symbol=BINANCE:" + listBox10.SelectedItem.ToString();
            System.Diagnostics.Process.Start(link);
        }

        private void listBox12_SelectedIndexChanged(object sender, EventArgs e)
        {
            string link = "https://tr.tradingview.com/chart/?symbol=BINANCE:" + listBox12.SelectedItem.ToString();
            System.Diagnostics.Process.Start(link);
        }

        private void listBox14_SelectedIndexChanged(object sender, EventArgs e)
        {
            string link = "https://tr.tradingview.com/chart/?symbol=BINANCE:" + listBox14.SelectedItem.ToString();
            System.Diagnostics.Process.Start(link);
        }

        private void listBox16_SelectedIndexChanged(object sender, EventArgs e)
        {
            string link = "https://tr.tradingview.com/chart/?symbol=BINANCE:" + listBox16.SelectedItem.ToString()+"BTC";
            System.Diagnostics.Process.Start(link);
        }

        private void listBox18_SelectedIndexChanged(object sender, EventArgs e)
        {
            string link = "https://tr.tradingview.com/chart/?symbol=BINANCE:" + listBox18.SelectedItem.ToString()+"BTC";
            System.Diagnostics.Process.Start(link);
        }

        private void listBox36_SelectedIndexChanged(object sender, EventArgs e)
        {
            string link = "https://tr.tradingview.com/chart/?symbol=BINANCE:" + listBox36.SelectedItem.ToString();
            System.Diagnostics.Process.Start(link);
        }

        private void listBox34_SelectedIndexChanged(object sender, EventArgs e)
        {
            string link = "https://tr.tradingview.com/chart/?symbol=BINANCE:" + listBox34.SelectedItem.ToString();
            System.Diagnostics.Process.Start(link);
        }

        private void listBox32_SelectedIndexChanged(object sender, EventArgs e)
        {
            string link = "https://tr.tradingview.com/chart/?symbol=BINANCE:" + listBox32.SelectedItem.ToString();
            System.Diagnostics.Process.Start(link);
        }

        private void listBox30_SelectedIndexChanged(object sender, EventArgs e)
        {
            string link = "https://tr.tradingview.com/chart/?symbol=BINANCE:" + listBox30.SelectedItem.ToString();
            System.Diagnostics.Process.Start(link);
        }

        private void listBox28_SelectedIndexChanged(object sender, EventArgs e)
        {
            string link = "https://tr.tradingview.com/chart/?symbol=BINANCE:" + listBox28.SelectedItem.ToString();
            System.Diagnostics.Process.Start(link);
        }

        private void listBox26_SelectedIndexChanged(object sender, EventArgs e)
        {
            string link = "https://tr.tradingview.com/chart/?symbol=BINANCE:" + listBox26.SelectedItem.ToString();
            System.Diagnostics.Process.Start(link);
        }

        private void listBox24_SelectedIndexChanged(object sender, EventArgs e)
        {
            string link = "https://tr.tradingview.com/chart/?symbol=BINANCE:" + listBox24.SelectedItem.ToString();
            System.Diagnostics.Process.Start(link);
        }

        private void listBox22_SelectedIndexChanged(object sender, EventArgs e)
        {
            string link = "https://tr.tradingview.com/chart/?symbol=BINANCE:" + listBox22.SelectedItem.ToString()+"BTC";
            System.Diagnostics.Process.Start(link);
        }

        private void listBox20_SelectedIndexChanged(object sender, EventArgs e)
        {
            string link = "https://tr.tradingview.com/chart/?symbol=BINANCE:" + listBox20.SelectedItem.ToString()+"BTC";
            System.Diagnostics.Process.Start(link);
        }

        private void listBox50_SelectedIndexChanged(object sender, EventArgs e)
        {
            string link = "https://tr.tradingview.com/chart/?symbol=BINANCE:" + listBox50.SelectedItem.ToString();
            System.Diagnostics.Process.Start(link);
        }

        private void listBox52_SelectedIndexChanged(object sender, EventArgs e)
        {
            string link = "https://tr.tradingview.com/chart/?symbol=BINANCE:" + listBox52.SelectedItem.ToString();
            System.Diagnostics.Process.Start(link);
        }

        private void listBox54_SelectedIndexChanged(object sender, EventArgs e)
        {
            string link = "https://tr.tradingview.com/chart/?symbol=BINANCE:" + listBox54.SelectedItem.ToString();
            System.Diagnostics.Process.Start(link);
        }

        private void listBox56_SelectedIndexChanged(object sender, EventArgs e)
        {
            string link = "https://tr.tradingview.com/chart/?symbol=BINANCE:" + listBox56.SelectedItem.ToString();
            System.Diagnostics.Process.Start(link);
        }

        private void listBox58_SelectedIndexChanged(object sender, EventArgs e)
        {
            string link = "https://tr.tradingview.com/chart/?symbol=BINANCE:" + listBox58.SelectedItem.ToString();
            System.Diagnostics.Process.Start(link);
        }

        private void listBox60_SelectedIndexChanged(object sender, EventArgs e)
        {
            string link = "https://tr.tradingview.com/chart/?symbol=BINANCE:" + listBox60.SelectedItem.ToString();
            System.Diagnostics.Process.Start(link);
        }

        private void listBox62_SelectedIndexChanged(object sender, EventArgs e)
        {
            string link = "https://tr.tradingview.com/chart/?symbol=BINANCE:" + listBox62.SelectedItem.ToString();
            System.Diagnostics.Process.Start(link);
        }

        private void listBox64_SelectedIndexChanged(object sender, EventArgs e)
        {
            string link = "https://tr.tradingview.com/chart/?symbol=BINANCE:" + listBox64.SelectedItem.ToString()+"BTC";
            System.Diagnostics.Process.Start(link);
        }

        private void listBox66_SelectedIndexChanged(object sender, EventArgs e)
        {
            string link = "https://tr.tradingview.com/chart/?symbol=BINANCE:" + listBox66.SelectedItem.ToString()+"BTC";
            System.Diagnostics.Process.Start(link);
        }

        private void listBox1_DoubleClick(object sender, EventArgs e)
        {
            string link = "https://tr.tradingview.com/chart/?symbol=BINANCE:" + listBox1.SelectedItem.ToString();
            System.Diagnostics.Process.Start(link);
        }

        private void listBox4_DoubleClick(object sender, EventArgs e)
        {
            string link = "https://tr.tradingview.com/chart/?symbol=BINANCE:" + listBox4.SelectedItem.ToString();
            System.Diagnostics.Process.Start(link);
        }

        private void listBox6_DoubleClick(object sender, EventArgs e)
        {
            string link = "https://tr.tradingview.com/chart/?symbol=BINANCE:" + listBox6.SelectedItem.ToString();
            System.Diagnostics.Process.Start(link);
        }

        private void listBox8_DoubleClick(object sender, EventArgs e)
        {
            string link = "https://tr.tradingview.com/chart/?symbol=BINANCE:" + listBox8.SelectedItem.ToString();
            System.Diagnostics.Process.Start(link);
        }

        private void listBox10_DoubleClick(object sender, EventArgs e)
        {
            string link = "https://tr.tradingview.com/chart/?symbol=BINANCE:" + listBox10.SelectedItem.ToString();
            System.Diagnostics.Process.Start(link);
        }

        private void listBox12_DoubleClick(object sender, EventArgs e)
        {
            string link = "https://tr.tradingview.com/chart/?symbol=BINANCE:" + listBox12.SelectedItem.ToString();
            System.Diagnostics.Process.Start(link);
        }

        private void listBox14_DoubleClick(object sender, EventArgs e)
        {
            string link = "https://tr.tradingview.com/chart/?symbol=BINANCE:" + listBox14.SelectedItem.ToString();
            System.Diagnostics.Process.Start(link);
        }

        private void listBox16_DoubleClick(object sender, EventArgs e)
        {
            string link = "https://tr.tradingview.com/chart/?symbol=BINANCE:" + listBox16.SelectedItem.ToString() + "BTC";
            System.Diagnostics.Process.Start(link);
        }

        private void listBox18_DoubleClick(object sender, EventArgs e)
        {
            string link = "https://tr.tradingview.com/chart/?symbol=BINANCE:" + listBox18.SelectedItem.ToString() + "BTC";
            System.Diagnostics.Process.Start(link);
        }

        private void listBox36_DoubleClick(object sender, EventArgs e)
        {
            string link = "https://tr.tradingview.com/chart/?symbol=BINANCE:" + listBox36.SelectedItem.ToString();
            System.Diagnostics.Process.Start(link);
        }

        private void listBox34_DoubleClick(object sender, EventArgs e)
        {
            string link = "https://tr.tradingview.com/chart/?symbol=BINANCE:" + listBox34.SelectedItem.ToString();
            System.Diagnostics.Process.Start(link);
        }

        private void listBox32_DoubleClick(object sender, EventArgs e)
        {
            string link = "https://tr.tradingview.com/chart/?symbol=BINANCE:" + listBox32.SelectedItem.ToString();
            System.Diagnostics.Process.Start(link);
        }

        private void listBox30_DoubleClick(object sender, EventArgs e)
        {
            string link = "https://tr.tradingview.com/chart/?symbol=BINANCE:" + listBox30.SelectedItem.ToString();
            System.Diagnostics.Process.Start(link);
        }

        private void listBox28_DoubleClick(object sender, EventArgs e)
        {
            string link = "https://tr.tradingview.com/chart/?symbol=BINANCE:" + listBox28.SelectedItem.ToString();
            System.Diagnostics.Process.Start(link);
        }

        private void listBox26_DoubleClick(object sender, EventArgs e)
        {
            string link = "https://tr.tradingview.com/chart/?symbol=BINANCE:" + listBox26.SelectedItem.ToString();
            System.Diagnostics.Process.Start(link);
        }

        private void listBox24_DoubleClick(object sender, EventArgs e)
        {
            string link = "https://tr.tradingview.com/chart/?symbol=BINANCE:" + listBox24.SelectedItem.ToString();
            System.Diagnostics.Process.Start(link);
        }

        private void listBox22_DoubleClick(object sender, EventArgs e)
        {
            string link = "https://tr.tradingview.com/chart/?symbol=BINANCE:" + listBox22.SelectedItem.ToString() + "BTC";
            System.Diagnostics.Process.Start(link);
        }

        private void listBox20_DoubleClick(object sender, EventArgs e)
        {
            string link = "https://tr.tradingview.com/chart/?symbol=BINANCE:" + listBox20.SelectedItem.ToString() + "BTC";
            System.Diagnostics.Process.Start(link);
        }

        private void listBox50_DoubleClick(object sender, EventArgs e)
        {
            string link = "https://tr.tradingview.com/chart/?symbol=BINANCE:" + listBox50.SelectedItem.ToString();
            System.Diagnostics.Process.Start(link);
        }

        private void listBox52_DoubleClick(object sender, EventArgs e)
        {
            string link = "https://tr.tradingview.com/chart/?symbol=BINANCE:" + listBox52.SelectedItem.ToString();
            System.Diagnostics.Process.Start(link);
        }

        private void listBox54_DoubleClick(object sender, EventArgs e)
        {
            string link = "https://tr.tradingview.com/chart/?symbol=BINANCE:" + listBox54.SelectedItem.ToString();
            System.Diagnostics.Process.Start(link);
        }

        private void listBox56_DoubleClick(object sender, EventArgs e)
        {
            string link = "https://tr.tradingview.com/chart/?symbol=BINANCE:" + listBox56.SelectedItem.ToString();
            System.Diagnostics.Process.Start(link);
        }

        private void listBox58_DoubleClick(object sender, EventArgs e)
        {
            string link = "https://tr.tradingview.com/chart/?symbol=BINANCE:" + listBox58.SelectedItem.ToString();
            System.Diagnostics.Process.Start(link);
        }

        private void listBox60_DoubleClick(object sender, EventArgs e)
        {
            string link = "https://tr.tradingview.com/chart/?symbol=BINANCE:" + listBox60.SelectedItem.ToString();
            System.Diagnostics.Process.Start(link);
        }

        private void listBox62_DoubleClick(object sender, EventArgs e)
        {
            string link = "https://tr.tradingview.com/chart/?symbol=BINANCE:" + listBox62.SelectedItem.ToString();
            System.Diagnostics.Process.Start(link);
        }

        private void listBox64_DoubleClick(object sender, EventArgs e)
        {
            string link = "https://tr.tradingview.com/chart/?symbol=BINANCE:" + listBox64.SelectedItem.ToString() + "BTC";
            System.Diagnostics.Process.Start(link);
        }

        private void listBox66_DoubleClick(object sender, EventArgs e)
        {
            string link = "https://tr.tradingview.com/chart/?symbol=BINANCE:" + listBox66.SelectedItem.ToString() + "BTC";
            System.Diagnostics.Process.Start(link);
        }

        private void tabPage4_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            saniye = 45;
            saniye2 = 45;
            saniye3 = 5;
            label19.Text = "45";
            label38.Text = "45";
            label68.Text = "45";
            label94.Text = "45";
            label131.Text = "45";
            label128.Text = "5";

            listBox37.Items.Clear();
            listBox38.Items.Clear();
            listBox39.Items.Clear();
            listBox40.Items.Clear();
            listBox41.Items.Clear();
            listBox42.Items.Clear();
            listBox43.Items.Clear();
            listBox44.Items.Clear();
            listBox45.Items.Clear();
            listBox46.Items.Clear();
            listBox47.Items.Clear();
            listBox48.Items.Clear();
            listBox67.Items.Clear();
            listBox68.Items.Clear();
            listBox69.Items.Clear();
            listBox70.Items.Clear();
            listBox71.Items.Clear();
            listBox72.Items.Clear();

            string ma50post1hour = "{\"filter\":[{\"left\":\"change|15\",\"operation\":\"nempty\"},{\"left\":\"exchange\",\"operation\":\"equal\",\"right\":\"BINANCE\"},{\"left\":\"SMA50|15\",\"operation\":\"crosses_below\",\"right\":\"close|15\"},{\"left\":\"name\",\"operation\":\"match\",\"right\":\"btc\"}],\"symbols\":{\"query\":{\"types\":[]}},\"columns\":[\"name\",\"change|15\",\"name\",\"subtype\"],\"sort\":{\"sortBy\":\"change|15\",\"sortOrder\":\"desc\"},\"options\":{\"lang\":\"tr\"},\"range\":[0,150]}";
            string ma501hourkaynak = postyolla(ma50post1hour);
            string[] ma50coinlist = coinlistal(ma501hourkaynak);
            string[] ma50coinyuzdelistesi = coinyuzdeal(ma501hourkaynak);

            string ma100post1hour = "{\"filter\":[{\"left\":\"change|15\",\"operation\":\"nempty\"},{\"left\":\"exchange\",\"operation\":\"equal\",\"right\":\"BINANCE\"},{\"left\":\"SMA100|15\",\"operation\":\"crosses_below\",\"right\":\"close|15\"},{\"left\":\"name\",\"operation\":\"match\",\"right\":\"btc\"}],\"symbols\":{\"query\":{\"types\":[]}},\"columns\":[\"name\",\"change|15\",\"name\",\"subtype\"],\"sort\":{\"sortBy\":\"change|15\",\"sortOrder\":\"desc\"},\"options\":{\"lang\":\"tr\"},\"range\":[0,150]}";
            string ma1001hourkaynak = postyolla(ma100post1hour);
            string[] ma100coinlist = coinlistal(ma1001hourkaynak);
            string[] ma100coinyuzdelistesi = coinyuzdeal(ma1001hourkaynak);

            string ma200post1hour = "{\"filter\":[{\"left\":\"change|15\",\"operation\":\"nempty\"},{\"left\":\"exchange\",\"operation\":\"equal\",\"right\":\"BINANCE\"},{\"left\":\"SMA200|15\",\"operation\":\"crosses_below\",\"right\":\"close|15\"},{\"left\":\"name\",\"operation\":\"match\",\"right\":\"btc\"}],\"symbols\":{\"query\":{\"types\":[]}},\"columns\":[\"name\",\"change|15\",\"name\",\"subtype\"],\"sort\":{\"sortBy\":\"change|15\",\"sortOrder\":\"desc\"},\"options\":{\"lang\":\"tr\"},\"range\":[0,150]}";
            string ma2001hourkaynak = postyolla(ma200post1hour);
            string[] ma200coinlist = coinlistal(ma2001hourkaynak);
            string[] ma200coinyuzdelistesi = coinyuzdeal(ma2001hourkaynak);

            string bbaltpost1hour = "{\"filter\":[{\"left\":\"change|15\",\"operation\":\"nempty\"},{\"left\":\"exchange\",\"operation\":\"equal\",\"right\":\"BINANCE\"},{\"left\":\"BB.lower|15\",\"operation\":\"crosses_below\",\"right\":\"close|15\"},{\"left\":\"name\",\"operation\":\"match\",\"right\":\"btc\"}],\"symbols\":{\"query\":{\"types\":[]}},\"columns\":[\"name\",\"change|15\",\"name\",\"subtype\"],\"sort\":{\"sortBy\":\"change|15\",\"sortOrder\":\"desc\"},\"options\":{\"lang\":\"tr\"},\"range\":[0,150]}";
            string bbalt1hourkaynak = postyolla(bbaltpost1hour);
            string[] bbaltcoinlist = coinlistal(bbalt1hourkaynak);
            string[] bbaltcoinyuzdelistesi = coinyuzdeal(bbalt1hourkaynak);

            string bbustpost1hour = "{\"filter\":[{\"left\":\"change|15\",\"operation\":\"nempty\"},{\"left\":\"exchange\",\"operation\":\"equal\",\"right\":\"BINANCE\"},{\"left\":\"BB.upper|15\",\"operation\":\"crosses_below\",\"right\":\"close|15\"},{\"left\":\"name\",\"operation\":\"match\",\"right\":\"btc\"}],\"symbols\":{\"query\":{\"types\":[]}},\"columns\":[\"name\",\"change|15\",\"name\",\"subtype\"],\"sort\":{\"sortBy\":\"change|15\",\"sortOrder\":\"desc\"},\"options\":{\"lang\":\"tr\"},\"range\":[0,150]}";
            string bbust1hourkaynak = postyolla(bbustpost1hour);
            string[] bbustcoinlist = coinlistal(bbust1hourkaynak);
            string[] bbustcoinyuzdelistesi = coinyuzdeal(bbust1hourkaynak);

            string MACDpost1hour = "{\"filter\":[{\"left\":\"change|15\",\"operation\":\"nempty\"},{\"left\":\"exchange\",\"operation\":\"equal\",\"right\":\"BINANCE\"},{\"left\":\"ADX|15\",\"operation\":\"greater\",\"right\":20},{\"left\":\"MACD.macd|15\",\"operation\":\"crosses_above\",\"right\":\"MACD.signal|15\"},{\"left\":\"name\",\"operation\":\"match\",\"right\":\"btc\"}],\"symbols\":{\"query\":{\"types\":[]}},\"columns\":[\"name\",\"change|15\",\"name\",\"subtype\"],\"sort\":{\"sortBy\":\"change|15\",\"sortOrder\":\"desc\"},\"options\":{\"lang\":\"tr\"},\"range\":[0,150]}";
            string MACD1hourkaynak = postyolla(MACDpost1hour);
            string[] MACDcoinlist = coinlistal(MACD1hourkaynak);
            string[] MACDcoinyuzdelistesi = coinyuzdeal(MACD1hourkaynak);


            string MA10MA50post1hour = "{\"filter\":[{\"left\":\"change|15\",\"operation\":\"nempty\"},{\"left\":\"exchange\",\"operation\":\"equal\",\"right\":\"BINANCE\"},{\"left\":\"SMA10|15\",\"operation\":\"crosses_above\",\"right\":\"SMA50|15\"},{\"left\":\"name\",\"operation\":\"match\",\"right\":\"btc\"}],\"symbols\":{\"query\":{\"types\":[]}},\"columns\":[\"name\",\"change|15\",\"name\",\"subtype\"],\"sort\":{\"sortBy\":\"change|15\",\"sortOrder\":\"desc\"},\"options\":{\"lang\":\"tr\"},\"range\":[0,150]}";
            string MA10MA501hourkaynak = postyolla(MA10MA50post1hour);
            string[] MA10MA50coinlist = coinlistal(MA10MA501hourkaynak);
            string[] MA10MA50coinyuzdelistesi = coinyuzdeal(MA10MA501hourkaynak);

            string GAINERSpost1hour = "{\"filter\":[{\"left\":\"change|15\",\"operation\":\"nempty\"},{\"left\":\"exchange\",\"operation\":\"equal\",\"right\":\"BINANCE\"},{\"left\":\"name\",\"operation\":\"match\",\"right\":\"btc\"}],\"symbols\":{\"query\":{\"types\":[]}},\"columns\":[\"name\",\"change|15\",\"name\",\"subtype\"],\"sort\":{\"sortBy\":\"change|15\",\"sortOrder\":\"desc\"},\"options\":{\"lang\":\"tr\"},\"range\":[0,150]}";
            string GAINERS1hourkaynak = postyolla(GAINERSpost1hour);
            string[] GAINERScoinlist = coinlistal(GAINERS1hourkaynak);
            string[] GAINERScoinyuzdelistesi = coinyuzdeal(GAINERS1hourkaynak);

            string LOSERSpost1hour = "{\"filter\":[{\"left\":\"change|15\",\"operation\":\"nempty\"},{\"left\":\"exchange\",\"operation\":\"equal\",\"right\":\"BINANCE\"},{\"left\":\"name\",\"operation\":\"match\",\"right\":\"btc\"}],\"symbols\":{\"query\":{\"types\":[]}},\"columns\":[\"name\",\"change|15\",\"name\",\"subtype\"],\"sort\":{\"sortBy\":\"change|15\",\"sortOrder\":\"asc\"},\"options\":{\"lang\":\"tr\"},\"range\":[0,150]}";
            string LOSERS1hourkaynak = postyolla(LOSERSpost1hour);
            string[] LOSERScoinlist = coinlistal(LOSERS1hourkaynak);
            string[] LOSERScoinyuzdelistesi = coinyuzdeal(LOSERS1hourkaynak);

            foreach (string eleman in ma50coinlist)
            {
                if (eleman == null) break;
                listBox72.Items.Add(eleman + "BTC");

            }

            foreach (string yuzdedegeri in ma50coinyuzdelistesi)
            {
                if (yuzdedegeri == null) break;
                listBox71.Items.Add(yuzdedegeri);
            }
            /////////////////////////////////////////////////////////////////////////
            foreach (string eleman in ma100coinlist)
            {
                if (eleman == null) break;
                listBox70.Items.Add(eleman + "BTC");

            }

            foreach (string yuzdedegeri in ma100coinyuzdelistesi)
            {
                if (yuzdedegeri == null) break;
                listBox69.Items.Add(yuzdedegeri);

            }
            /////////////////////////////////////////////////////////////////////////
            foreach (string eleman in ma200coinlist)
            {
                if (eleman == null) break;
                listBox68.Items.Add(eleman + "BTC");

            }

            foreach (string yuzdedegeri in ma200coinyuzdelistesi)
            {
                if (yuzdedegeri == null) break;
                listBox67.Items.Add(yuzdedegeri);
            }
            /////////////////////////////////////////////////////////////////////////////

            foreach (string eleman in bbaltcoinlist)
            {
                if (eleman == null) break;
                listBox46.Items.Add(eleman + "BTC");

            }

            foreach (string yuzdedegeri in bbaltcoinyuzdelistesi)
            {
                if (yuzdedegeri == null) break;
                listBox45.Items.Add(yuzdedegeri);
            }
            ////////////////////////////////////////////////////////////////////////////
            foreach (string eleman in bbustcoinlist)
            {
                if (eleman == null) break;
                listBox44.Items.Add(eleman + "BTC");

            }

            foreach (string yuzdedegeri in bbustcoinyuzdelistesi)
            {
                if (yuzdedegeri == null) break;
                listBox43.Items.Add(yuzdedegeri);
            }
            //////////////////////////////////////////////////////////////////////////////
            foreach (string eleman in MACDcoinlist)
            {
                if (eleman == null) break;
                listBox42.Items.Add(eleman + "BTC");

            }


            foreach (string yuzdedegeri in MACDcoinyuzdelistesi)
            {
                if (yuzdedegeri == null) break;
                listBox41.Items.Add(yuzdedegeri.Substring(0, 5));
            }
            /////////////////////////////////////////////////////////////////////////////
            foreach (string eleman in MA10MA50coinlist)
            {
                if (eleman == null) break;
                listBox48.Items.Add(eleman + "BTC");

            }


            foreach (string yuzdedegeri in MA10MA50coinyuzdelistesi)
            {
                if (yuzdedegeri == null) break;
                listBox47.Items.Add(yuzdedegeri);
            }
            /////////////////////////////////////////////////////////////////////////////////
            for (int i = 0; i <= 15; i++)
            {
                if (GAINERScoinyuzdelistesi[i] == null) break;
                listBox40.Items.Add(GAINERScoinlist[i]);
                listBox39.Items.Add(GAINERScoinyuzdelistesi[i]);
            }
            /////////////////////////////////////////////////////////////////////////////////
            for (int i = 0; i <= 15; i++)
            {
                if (LOSERScoinyuzdelistesi[i] == null) break;
                listBox38.Items.Add(LOSERScoinlist[i]);
                listBox37.Items.Add(LOSERScoinyuzdelistesi[i]);
            }
            timer6.Stop();
            timer5.Stop();
            timer3.Stop();
            timer2.Stop();
            timer1.Stop();
            timer7.Stop();
            if (radioButton6.Checked)
            {
                timer4.Start();
            }
            else if (radioButton5.Checked)
            {
                timer4.Stop();
            }
        }

        private void listBox71_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();

            //Varsayılan öge rengi (fırçadan)
            Brush myBrush = Brushes.Green;


            //Örneğin 0 ile başlayanları kırmızı, 1 ile başlayanları mavi yap!

            if (listBox71.Items[e.Index].ToString().StartsWith("-") == true)
            {
                myBrush = Brushes.Red;
            }
            e.Graphics.DrawString(((ListBox)sender).Items[e.Index].ToString(),
e.Font, myBrush, e.Bounds, StringFormat.GenericDefault);

            e.DrawFocusRectangle();
        }

        private void listBox69_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();

            //Varsayılan öge rengi (fırçadan)
            Brush myBrush = Brushes.Green;


            //Örneğin 0 ile başlayanları kırmızı, 1 ile başlayanları mavi yap!

            if (listBox69.Items[e.Index].ToString().StartsWith("-") == true)
            {
                myBrush = Brushes.Red;
            }
            e.Graphics.DrawString(((ListBox)sender).Items[e.Index].ToString(),
e.Font, myBrush, e.Bounds, StringFormat.GenericDefault);

            e.DrawFocusRectangle();
        }

        private void listBox49_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();

            //Varsayılan öge rengi (fırçadan)
            Brush myBrush = Brushes.Green;


            //Örneğin 0 ile başlayanları kırmızı, 1 ile başlayanları mavi yap!

            if (listBox49.Items[e.Index].ToString().StartsWith("-") == true)
            {
                myBrush = Brushes.Red;
            }
            e.Graphics.DrawString(((ListBox)sender).Items[e.Index].ToString(),
e.Font, myBrush, e.Bounds, StringFormat.GenericDefault);

            e.DrawFocusRectangle();
        }

        private void listBox47_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();

            //Varsayılan öge rengi (fırçadan)
            Brush myBrush = Brushes.Green;


            //Örneğin 0 ile başlayanları kırmızı, 1 ile başlayanları mavi yap!

            if (listBox47.Items[e.Index].ToString().StartsWith("-") == true)
            {
                myBrush = Brushes.Red;
            }
            e.Graphics.DrawString(((ListBox)sender).Items[e.Index].ToString(),
e.Font, myBrush, e.Bounds, StringFormat.GenericDefault);

            e.DrawFocusRectangle();
        }

        private void listBox45_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();

            //Varsayılan öge rengi (fırçadan)
            Brush myBrush = Brushes.Green;


            //Örneğin 0 ile başlayanları kırmızı, 1 ile başlayanları mavi yap!

            if (listBox45.Items[e.Index].ToString().StartsWith("-") == true)
            {
                myBrush = Brushes.Red;
            }
            e.Graphics.DrawString(((ListBox)sender).Items[e.Index].ToString(),
e.Font, myBrush, e.Bounds, StringFormat.GenericDefault);

            e.DrawFocusRectangle();
        }

        private void listBox43_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();

            //Varsayılan öge rengi (fırçadan)
            Brush myBrush = Brushes.Green;


            //Örneğin 0 ile başlayanları kırmızı, 1 ile başlayanları mavi yap!

            if (listBox43.Items[e.Index].ToString().StartsWith("-") == true)
            {
                myBrush = Brushes.Red;
            }
            e.Graphics.DrawString(((ListBox)sender).Items[e.Index].ToString(),
e.Font, myBrush, e.Bounds, StringFormat.GenericDefault);

            e.DrawFocusRectangle();
        }

        private void listBox41_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();

            //Varsayılan öge rengi (fırçadan)
            Brush myBrush = Brushes.Green;


            //Örneğin 0 ile başlayanları kırmızı, 1 ile başlayanları mavi yap!

            if (listBox41.Items[e.Index].ToString().StartsWith("-") == true)
            {
                myBrush = Brushes.Red;
            }
            e.Graphics.DrawString(((ListBox)sender).Items[e.Index].ToString(),
e.Font, myBrush, e.Bounds, StringFormat.GenericDefault);

            e.DrawFocusRectangle();
        }

        private void listBox72_DoubleClick(object sender, EventArgs e)
        {
            string link = "https://tr.tradingview.com/chart/?symbol=BINANCE:" + listBox72.SelectedItem.ToString();
            System.Diagnostics.Process.Start(link);
        }

        private void listBox70_Click(object sender, EventArgs e)
        {
            string link = "https://tr.tradingview.com/chart/?symbol=BINANCE:" + listBox70.SelectedItem.ToString();
            System.Diagnostics.Process.Start(link);
        }

        private void listBox68_Click(object sender, EventArgs e)
        {
            string link = "https://tr.tradingview.com/chart/?symbol=BINANCE:" + listBox68.SelectedItem.ToString();
            System.Diagnostics.Process.Start(link);
        }

        private void listBox48_DoubleClick(object sender, EventArgs e)
        {
            string link = "https://tr.tradingview.com/chart/?symbol=BINANCE:" + listBox48.SelectedItem.ToString();
            System.Diagnostics.Process.Start(link);
        }

        private void listBox46_DoubleClick(object sender, EventArgs e)
        {
            string link = "https://tr.tradingview.com/chart/?symbol=BINANCE:" + listBox46.SelectedItem.ToString();
            System.Diagnostics.Process.Start(link);
        }

        private void listBox44_DoubleClick(object sender, EventArgs e)
        {
            string link = "https://tr.tradingview.com/chart/?symbol=BINANCE:" + listBox44.SelectedItem.ToString();
            System.Diagnostics.Process.Start(link);
        }

        private void listBox42_DoubleClick(object sender, EventArgs e)
        {
            string link = "https://tr.tradingview.com/chart/?symbol=BINANCE:" + listBox42.SelectedItem.ToString();
            System.Diagnostics.Process.Start(link);
        }

        private void listBox40_DoubleClick(object sender, EventArgs e)
        {
            string link = "https://tr.tradingview.com/chart/?symbol=BINANCE:" + listBox40.SelectedItem.ToString()+"BTC";
            System.Diagnostics.Process.Start(link);
        }

        private void listBox38_DoubleClick(object sender, EventArgs e)
        {
            string link = "https://tr.tradingview.com/chart/?symbol=BINANCE:" + listBox38.SelectedItem.ToString()+"BTC";
            System.Diagnostics.Process.Start(link);
        }

        private void timer4_Tick(object sender, EventArgs e)
        {

            saniye--;

            label75.Text = (saniye % 60).ToString("00");
            label75.Visible = true;

            if (saniye == 00)
            {
                timer4.Stop();
                timer4.Enabled = true;
                timer4.Interval = 1000;
                saniye = 45;
                button4_Click(sender, e);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            
            saniye = 45;
            saniye2 = 45;
            saniye3 = 5;
            label19.Text = "45";
            label38.Text = "45";
            label68.Text = "45";
            label75.Text = "45";
            label131.Text = "45";
            label128.Text = "5";
            listBox75.Items.Clear();
            listBox76.Items.Clear();
            listBox73.Items.Clear();
            listBox74.Items.Clear();
            listBox77.Items.Clear();
            listBox78.Items.Clear();
            listBox79.Items.Clear();
            listBox80.Items.Clear();
            listBox81.Items.Clear();
            listBox82.Items.Clear();
            listBox83.Items.Clear();
            listBox84.Items.Clear();
            listBox85.Items.Clear();
            listBox86.Items.Clear();
            listBox87.Items.Clear();
            listBox88.Items.Clear();
            listBox89.Items.Clear();
            listBox90.Items.Clear();
            listBox91.Items.Clear();
            listBox93.Items.Clear();
            listBox92.Items.Clear();
            listBox95.Items.Clear();
            listBox94.Items.Clear();
            listBox96.Items.Clear();


            if (radioButton9.Checked)//golden crossssss
            {
                listBox95.Items.Clear();
                listBox96.Items.Clear();
                if (checkBox1.Checked)
                {
                   
                    string goldencrosspost = "{\"filter\":[{\"left\":\"change|60\",\"operation\":\"nempty\"},{\"left\":\"exchange\",\"operation\":\"equal\",\"right\":\"BINANCE\"},{\"left\":\"SMA50|60\",\"operation\":\"crosses_above\",\"right\":\"SMA200|60\"},{\"left\":\"name,description\",\"operation\":\"match\",\"right\":\"BTC\"}],\"symbols\":{\"query\":{\"types\":[]}},\"columns\":[\"name\",\"close|60\",\"change|60\",\"change_abs|60\",\"high|60\",\"low|60\",\"volume|60\",\"Recommend.All|60\",\"exchange\",\"description\",\"name\",\"subtype\",\"pricescale\",\"minmov\",\"fractional\",\"minmove2\"],\"sort\":{\"sortBy\":\"change|60\",\"sortOrder\":\"desc\"},\"options\":{\"lang\":\"tr\"},\"range\":[0,150]}";
                    string goldencrosskaynak = postyolla(goldencrosspost);
                    string[] goldencrosscoinlist = coinlistal(goldencrosskaynak);
                    
                    foreach (string eleman in goldencrosscoinlist)
                    {
                        if (eleman == null) break;
                        listBox95.Items.Add(eleman + "BTC");
                        listBox96.Items.Add("1h");

                    }


                }
                if (checkBox2.Checked)
                {
                    
                    string goldencrosspost = "{\"filter\":[{\"left\":\"change|240\",\"operation\":\"nempty\"},{\"left\":\"exchange\",\"operation\":\"equal\",\"right\":\"BINANCE\"},{\"left\":\"SMA50|240\",\"operation\":\"crosses_above\",\"right\":\"SMA200|240\"},{\"left\":\"name,description\",\"operation\":\"match\",\"right\":\"BTC\"}],\"symbols\":{\"query\":{\"types\":[]}},\"columns\":[\"name\",\"close|240\",\"change|240\",\"change_abs|240\",\"high|240\",\"low|240\",\"volume|240\",\"Recommend.All|240\",\"exchange\",\"description\",\"name\",\"subtype\",\"pricescale\",\"minmov\",\"fractional\",\"minmove2\"],\"sort\":{\"sortBy\":\"change|240\",\"sortOrder\":\"desc\"},\"options\":{\"lang\":\"tr\"},\"range\":[0,150]}";
                    string goldencrosskaynak = postyolla(goldencrosspost);
                    string[] goldencrosscoinlist = coinlistal(goldencrosskaynak);

                    foreach (string eleman in goldencrosscoinlist)
                    {
                        if (eleman == null) break;
                        listBox95.Items.Add(eleman + "BTC");
                        listBox96.Items.Add("4h");

                    }

                }
                if (checkBox3.Checked)
                {
                    
                    string goldencrosspost = "{\"filter\":[{\"left\":\"change\",\"operation\":\"nempty\"},{\"left\":\"exchange\",\"operation\":\"equal\",\"right\":\"BINANCE\"},{\"left\":\"SMA50\",\"operation\":\"crosses_above\",\"right\":\"SMA200\"},{\"left\":\"name,description\",\"operation\":\"match\",\"right\":\"BTC\"}],\"symbols\":{\"query\":{\"types\":[]}},\"columns\":[\"name\",\"close\",\"change\",\"change_abs\",\"high\",\"low\",\"volume\",\"Recommend.All\",\"exchange\",\"description\",\"name\",\"subtype\",\"pricescale\",\"minmov\",\"fractional\",\"minmove2\"],\"sort\":{\"sortBy\":\"change\",\"sortOrder\":\"desc\"},\"options\":{\"lang\":\"tr\"},\"range\":[0,150]}";
                    string goldencrosskaynak = postyolla(goldencrosspost);
                    string[] goldencrosscoinlist = coinlistal(goldencrosskaynak);

                    foreach (string eleman in goldencrosscoinlist)
                    {
                        if (eleman == null) break;
                        listBox95.Items.Add(eleman + "BTC");
                        listBox96.Items.Add("1d");

                    }

                }




            }

            if (radioButton12.Checked)//death cross
            {
                listBox95.Items.Clear();
                listBox96.Items.Clear();
                if (checkBox1.Checked)
                {
                    
                    string goldencrosspost = "{\"filter\":[{\"left\":\"change|60\",\"operation\":\"nempty\"},{\"left\":\"exchange\",\"operation\":\"equal\",\"right\":\"BINANCE\"},{\"left\":\"SMA50|60\",\"operation\":\"crosses_below\",\"right\":\"SMA200|60\"},{\"left\":\"name,description\",\"operation\":\"match\",\"right\":\"btc\"}],\"symbols\":{\"query\":{\"types\":[]}},\"columns\":[\"name\",\"close|60\",\"change|60\",\"change_abs|60\",\"high|60\",\"low|60\",\"volume|60\",\"Recommend.All|60\",\"exchange\",\"description\",\"name\",\"subtype\",\"pricescale\",\"minmov\",\"fractional\",\"minmove2\"],\"sort\":{\"sortBy\":\"change|60\",\"sortOrder\":\"desc\"},\"options\":{\"lang\":\"tr\"},\"range\":[0,150]}";
                    string goldencrosskaynak = postyolla(goldencrosspost);
                    string[] goldencrosscoinlist = coinlistal(goldencrosskaynak);

                    foreach (string eleman in goldencrosscoinlist)
                    {
                        if (eleman == null) break;
                        listBox95.Items.Add(eleman + "BTC");
                        listBox96.Items.Add("1h");

                    }


                }
                if (checkBox2.Checked)
                {
                    
                    string goldencrosspost = "{\"filter\":[{\"left\":\"change|240\",\"operation\":\"nempty\"},{\"left\":\"exchange\",\"operation\":\"equal\",\"right\":\"BINANCE\"},{\"left\":\"SMA50|240\",\"operation\":\"crosses_below\",\"right\":\"SMA200|240\"},{\"left\":\"name,description\",\"operation\":\"match\",\"right\":\"btc\"}],\"symbols\":{\"query\":{\"types\":[]}},\"columns\":[\"name\",\"close|240\",\"change|240\",\"change_abs|240\",\"high|240\",\"low|240\",\"volume|240\",\"Recommend.All|240\",\"exchange\",\"description\",\"name\",\"subtype\",\"pricescale\",\"minmov\",\"fractional\",\"minmove2\"],\"sort\":{\"sortBy\":\"change|240\",\"sortOrder\":\"desc\"},\"options\":{\"lang\":\"tr\"},\"range\":[0,150]}";
                    string goldencrosskaynak = postyolla(goldencrosspost);
                    string[] goldencrosscoinlist = coinlistal(goldencrosskaynak);

                    foreach (string eleman in goldencrosscoinlist)
                    {
                        if (eleman == null) break;
                        listBox95.Items.Add(eleman + "BTC");
                        listBox96.Items.Add("4h");

                    }

                }
                if (checkBox3.Checked)
                {
                    
                    string goldencrosspost = "{\"filter\":[{\"left\":\"change\",\"operation\":\"nempty\"},{\"left\":\"exchange\",\"operation\":\"equal\",\"right\":\"BINANCE\"},{\"left\":\"SMA50\",\"operation\":\"crosses_below\",\"right\":\"SMA200\"},{\"left\":\"name,description\",\"operation\":\"match\",\"right\":\"btc\"}],\"symbols\":{\"query\":{\"types\":[]}},\"columns\":[\"name\",\"close\",\"change\",\"change_abs\",\"high\",\"low\",\"volume\",\"Recommend.All\",\"exchange\",\"description\",\"name\",\"subtype\",\"pricescale\",\"minmov\",\"fractional\",\"minmove2\"],\"sort\":{\"sortBy\":\"change\",\"sortOrder\":\"desc\"},\"options\":{\"lang\":\"tr\"},\"range\":[0,150]}";
                    string goldencrosskaynak = postyolla(goldencrosspost);
                    string[] goldencrosscoinlist = coinlistal(goldencrosskaynak);

                    foreach (string eleman in goldencrosscoinlist)
                    {
                        if (eleman == null) break;
                        listBox95.Items.Add(eleman + "BTC");
                        listBox96.Items.Add("1d");

                    }

                }
                



            }


            string kivancpost4hour = "{\"filter\":[{\"left\":\"change|240\",\"operation\":\"nempty\"},{\"left\":\"exchange\",\"operation\":\"equal\",\"right\":\"BINANCE\"},{\"left\":\"ADX|240\",\"operation\":\"greater\",\"right\":30},{\"left\":\"ADX+DI|240\",\"operation\":\"greater\",\"right\":\"ADX-DI|240\"},{\"left\":\"SMA50|240\",\"operation\":\"greater\",\"right\":\"SMA200|240\"},{\"left\":\"MACD.macd|240\",\"operation\":\"greater\",\"right\":\"MACD.signal|240\"},{\"left\":\"P.SAR|240\",\"operation\":\"less\",\"right\":\"close|240\"},{\"left\":\"Stoch.RSI.K|240\",\"operation\":\"greater\",\"right\":\"Stoch.RSI.D|240\"},{\"left\":\"name,description\",\"operation\":\"match\",\"right\":\"btc\"}],\"symbols\":{\"query\":{\"types\":[]}},\"columns\":[\"name\",\"change|240\",\"description\",\"name\",\"subtype\"],\"sort\":{\"sortBy\":\"change|240\",\"sortOrder\":\"desc\"},\"options\":{\"lang\":\"tr\"},\"range\":[0,150]}";
            string kivanc4hourkaynak = postyolla(kivancpost4hour); //kıvanc 4 hour
            string[] kivanccoinlist = coinlistal(kivanc4hourkaynak);
            string[] kivanccoinyuzdelistesi = coinyuzdeal(kivanc4hourkaynak);

            string ma50post4hour = "{\"filter\":[{\"left\":\"change|240\",\"operation\":\"nempty\"},{\"left\":\"exchange\",\"operation\":\"equal\",\"right\":\"BINANCE\"},{\"left\":\"SMA50|240\",\"operation\":\"crosses_below\",\"right\":\"close|240\"},{\"left\":\"name\",\"operation\":\"match\",\"right\":\"BTC\"}],\"symbols\":{\"query\":{\"types\":[]}},\"columns\":[\"name\",\"change|240\",\"name\",\"subtype\"],\"sort\":{\"sortBy\":\"change|240\",\"sortOrder\":\"desc\"},\"options\":{\"lang\":\"tr\"},\"range\":[0,150]}";
            string ma504hourkaynak = postyolla(ma50post4hour);//ma50 4 hour
            string[] ma50coinlist2 = coinlistal(ma504hourkaynak);
            string[] ma50coinyuzdelistesi2 = coinyuzdeal(ma504hourkaynak);

            string ma50post1hour = "{\"filter\":[{\"left\":\"change|15\",\"operation\":\"nempty\"},{\"left\":\"exchange\",\"operation\":\"equal\",\"right\":\"BINANCE\"},{\"left\":\"SMA50|15\",\"operation\":\"crosses_below\",\"right\":\"close|15\"},{\"left\":\"name\",\"operation\":\"match\",\"right\":\"btc\"}],\"symbols\":{\"query\":{\"types\":[]}},\"columns\":[\"name\",\"change|15\",\"name\",\"subtype\"],\"sort\":{\"sortBy\":\"change|15\",\"sortOrder\":\"desc\"},\"options\":{\"lang\":\"tr\"},\"range\":[0,150]}";
            string ma501hourkaynak = postyolla(ma50post1hour); //ma50 15 dakika
            string[] ma50coinlist = coinlistal(ma501hourkaynak);
            string[] ma50coinyuzdelistesi = coinyuzdeal(ma501hourkaynak);

            string ma100post1hour = "{\"filter\":[{\"left\":\"change|60\",\"operation\":\"nempty\"},{\"left\":\"exchange\",\"operation\":\"equal\",\"right\":\"BINANCE\"},{\"left\":\"SMA50|60\",\"operation\":\"crosses_below\",\"right\":\"close|60\"},{\"left\":\"name\",\"operation\":\"match\",\"right\":\"btc\"}],\"symbols\":{\"query\":{\"types\":[]}},\"columns\":[\"name\",\"change|60\",\"name\",\"subtype\"],\"sort\":{\"sortBy\":\"change|60\",\"sortOrder\":\"desc\"},\"options\":{\"lang\":\"tr\"},\"range\":[0,150]}";
            string ma1001hourkaynak = postyolla(ma100post1hour); // ma50 1 saat
            string[] ma100coinlist = coinlistal(ma1001hourkaynak);
            string[] ma100coinyuzdelistesi = coinyuzdeal(ma1001hourkaynak);

            string ma200post1hour = "{\"filter\":[{\"left\":\"change|60\",\"operation\":\"nempty\"},{\"left\":\"exchange\",\"operation\":\"equal\",\"right\":\"BINANCE\"},{\"left\":\"ADX|60\",\"operation\":\"greater\",\"right\":20},{\"left\":\"ADX+DI|60\",\"operation\":\"greater\",\"right\":\"ADX-DI|60\"},{\"left\":\"SMA50|60\",\"operation\":\"greater\",\"right\":\"SMA200|60\"},{\"left\":\"MACD.macd|60\",\"operation\":\"greater\",\"right\":\"MACD.signal|60\"},{\"left\":\"P.SAR|60\",\"operation\":\"less\",\"right\":\"close|60\"},{\"left\":\"Stoch.RSI.K|60\",\"operation\":\"greater\",\"right\":\"Stoch.RSI.D|60\"},{\"left\":\"name\",\"operation\":\"match\",\"right\":\"btc\"}],\"symbols\":{\"query\":{\"types\":[]}},\"columns\":[\"name\",\"change|60\",\"name\",\"subtype\"],\"sort\":{\"sortBy\":\"change|60\",\"sortOrder\":\"desc\"},\"options\":{\"lang\":\"tr\"},\"range\":[0,150]}";
            string ma2001hourkaynak = postyolla(ma200post1hour); //kıvanç 1 saat
            string[] ma200coinlist = coinlistal(ma2001hourkaynak);
            string[] ma200coinyuzdelistesi = coinyuzdeal(ma2001hourkaynak);

            string bbaltpost1hour = "{\"filter\":[{\"left\":\"change|15\",\"operation\":\"nempty\"},{\"left\":\"exchange\",\"operation\":\"equal\",\"right\":\"BINANCE\"},{\"left\":\"ADX|15\",\"operation\":\"greater\",\"right\":20},{\"left\":\"ADX+DI|15\",\"operation\":\"greater\",\"right\":\"ADX-DI|15\"},{\"left\":\"SMA50|15\",\"operation\":\"greater\",\"right\":\"SMA200|15\"},{\"left\":\"MACD.macd|15\",\"operation\":\"greater\",\"right\":\"MACD.signal|15\"},{\"left\":\"P.SAR|15\",\"operation\":\"less\",\"right\":\"close|15\"},{\"left\":\"Stoch.RSI.K|15\",\"operation\":\"greater\",\"right\":\"Stoch.RSI.D|15\"},{\"left\":\"name\",\"operation\":\"match\",\"right\":\"btc\"}],\"symbols\":{\"query\":{\"types\":[]}},\"columns\":[\"name\",\"change|15\",\"name\",\"subtype\"],\"sort\":{\"sortBy\":\"change|15\",\"sortOrder\":\"desc\"},\"options\":{\"lang\":\"tr\"},\"range\":[0,150]}";
            string bbalt1hourkaynak = postyolla(bbaltpost1hour); //kıvanç 15 dakika
            string[] bbaltcoinlist = coinlistal(bbalt1hourkaynak);
            string[] bbaltcoinyuzdelistesi = coinyuzdeal(bbalt1hourkaynak);

            string bbustpost1hour = "{\"filter\":[{\"left\":\"Recommend.All|60\",\"operation\":\"nempty\"},{\"left\":\"exchange\",\"operation\":\"equal\",\"right\":\"BINANCE\"},{\"left\":\"RSI|60\",\"operation\":\"greater\",\"right\":30},{\"left\":\"ADX|60\",\"operation\":\"greater\",\"right\":20},{\"left\":\"MACD.macd|60\",\"operation\":\"greater\",\"right\":\"MACD.signal|60\"},{\"left\":\"P.SAR|60\",\"operation\":\"greater\",\"right\":\"close|60\",\"sortOrder\":\"desc\"},{\"left\":\"CCI20|60\",\"operation\":\"greater\",\"right\":-100},{\"left\":\"Stoch.RSI.K|60\",\"operation\":\"greater\",\"right\":\"Stoch.RSI.D|60\"},{\"left\":\"Ichimoku.CLine|60\",\"operation\":\"less\",\"right\":\"close|60\"},{\"left\":\"Ichimoku.BLine|60\",\"operation\":\"less\",\"right\":\"Ichimoku.CLine|60\"},{\"left\":\"Ichimoku.Lead1|60\",\"operation\":\"greater\",\"right\":\"Ichimoku.Lead2|60\"},{\"left\":\"name\",\"operation\":\"match\",\"right\":\"btc\"}],\"symbols\":{\"query\":{\"types\":[]}},\"columns\":[\"name\",\"change|60\",\"name\",\"subtype\"],\"sort\":{\"sortBy\":\"Recommend.All|60\",\"sortOrder\":\"desc\"},\"options\":{\"lang\":\"tr\"},\"range\":[0,150]}";
            string bbust1hourkaynak = postyolla(bbustpost1hour);// mustafa karışık 1 saat
            string[] bbustcoinlist = coinlistal(bbust1hourkaynak);
            string[] bbustcoinyuzdelistesi = coinyuzdeal(bbust1hourkaynak);

            string MACDpost1hour = "{\"filter\":[{\"left\":\"Recommend.All|15\",\"operation\":\"nempty\"},{\"left\":\"exchange\",\"operation\":\"equal\",\"right\":\"BINANCE\"},{\"left\":\"RSI|15\",\"operation\":\"greater\",\"right\":30},{\"left\":\"ADX|15\",\"operation\":\"greater\",\"right\":20},{\"left\":\"MACD.macd|15\",\"operation\":\"greater\",\"right\":\"MACD.signal|15\"},{\"left\":\"P.SAR|15\",\"operation\":\"greater\",\"right\":\"close|15\",\"sortOrder\":\"desc\"},{\"left\":\"CCI20|15\",\"operation\":\"greater\",\"right\":-100},{\"left\":\"Stoch.RSI.K|15\",\"operation\":\"greater\",\"right\":\"Stoch.RSI.D|15\"},{\"left\":\"Ichimoku.CLine|15\",\"operation\":\"less\",\"right\":\"close|15\"},{\"left\":\"Ichimoku.BLine|15\",\"operation\":\"less\",\"right\":\"Ichimoku.CLine|15\"},{\"left\":\"Ichimoku.Lead1|15\",\"operation\":\"greater\",\"right\":\"Ichimoku.Lead2|15\"},{\"left\":\"name\",\"operation\":\"match\",\"right\":\"btc\"}],\"symbols\":{\"query\":{\"types\":[]}},\"columns\":[\"name\",\"change|15\",\"name\",\"subtype\"],\"sort\":{\"sortBy\":\"Recommend.All|15\",\"sortOrder\":\"desc\"},\"options\":{\"lang\":\"tr\"},\"range\":[0,150]}";
            string MACD1hourkaynak = postyolla(MACDpost1hour); //mustafa karışık 15 dk
            string[] MACDcoinlist = coinlistal(MACD1hourkaynak);
            string[] MACDcoinyuzdelistesi = coinyuzdeal(MACD1hourkaynak);

            string mustafa4hpost = "{\"filter\":[{\"left\":\"change|15\",\"operation\":\"nempty\"},{\"left\":\"exchange\",\"operation\":\"equal\",\"right\":\"BINANCE\"},{\"left\":\"SMA10|15\",\"operation\":\"crosses_above\",\"right\":\"SMA50|15\"},{\"left\":\"name\",\"operation\":\"match\",\"right\":\"btc\"}],\"symbols\":{\"query\":{\"types\":[]}},\"columns\":[\"name\",\"change|15\",\"name\",\"subtype\"],\"sort\":{\"sortBy\":\"change|15\",\"sortOrder\":\"desc\"},\"options\":{\"lang\":\"tr\"},\"range\":[0,150]}";
            string mustafa4hourkaynak = postyolla(mustafa4hpost); //mustafa karışık 4h
            string[] mustafacoinlist = coinlistal(mustafa4hourkaynak);
            string[] mustafacoinyuzdelistesi = coinyuzdeal(mustafa4hourkaynak);


            string MA10MA50post1hour = "{\"filter\":[{\"left\":\"change|15\",\"operation\":\"nempty\"},{\"left\":\"exchange\",\"operation\":\"equal\",\"right\":\"BINANCE\"},{\"left\":\"SMA10|15\",\"operation\":\"crosses_above\",\"right\":\"SMA50|15\"},{\"left\":\"name\",\"operation\":\"match\",\"right\":\"btc\"}],\"symbols\":{\"query\":{\"types\":[]}},\"columns\":[\"name\",\"change|15\",\"name\",\"subtype\"],\"sort\":{\"sortBy\":\"change|15\",\"sortOrder\":\"desc\"},\"options\":{\"lang\":\"tr\"},\"range\":[0,150]}";
            string MA10MA501hourkaynak = postyolla(MA10MA50post1hour); //ma10ma50 15 dk
            string[] MA10MA50coinlist = coinlistal(MA10MA501hourkaynak);
            string[] MA10MA50coinyuzdelistesi = coinyuzdeal(MA10MA501hourkaynak);

            string MAa10MA50post1hour = "{\"filter\":[{\"left\":\"change|60\",\"operation\":\"nempty\"},{\"left\":\"exchange\",\"operation\":\"equal\",\"right\":\"BINANCE\"},{\"left\":\"SMA10|60\",\"operation\":\"crosses_above\",\"right\":\"SMA50|60\"},{\"left\":\"name\",\"operation\":\"match\",\"right\":\"btc\"}],\"symbols\":{\"query\":{\"types\":[]}},\"columns\":[\"name\",\"change|60\",\"name\",\"subtype\"],\"sort\":{\"sortBy\":\"change|60\",\"sortOrder\":\"desc\"},\"options\":{\"lang\":\"tr\"},\"range\":[0,150]}";
            string MAa10MA501hourkaynak = postyolla(MAa10MA50post1hour); //ma10ma50 1 saat
            string[] MAa10MA50coinlist = coinlistal(MAa10MA501hourkaynak);
            string[] MAa10MA50coinyuzdelistesi = coinyuzdeal(MAa10MA501hourkaynak);

            foreach (string eleman in mustafacoinlist)
            {
                if (eleman == null) break;
                listBox94.Items.Add(eleman + "BTC");

            }

            foreach (string yuzdedegeri in mustafacoinyuzdelistesi)
            {
                if (yuzdedegeri == null) break;
                listBox92.Items.Add(yuzdedegeri);
            }

            /////////////////////////////////////////////////////////////////////////
            foreach (string eleman in kivanccoinlist)
            {
                if (eleman == null) break;
                listBox91.Items.Add(eleman + "BTC");

            }

            foreach (string yuzdedegeri in kivanccoinyuzdelistesi)
            {
                if (yuzdedegeri == null) break;
                listBox93.Items.Add(yuzdedegeri);
            }

            /////////////////////////////////////////////////////////////////////////
                        
            foreach (string eleman in ma50coinlist2)
            {
                if (eleman == null) break;
                listBox75.Items.Add(eleman + "BTC");

            }

            foreach (string yuzdedegeri in ma50coinyuzdelistesi2)
            {
                if (yuzdedegeri == null) break;
                listBox76.Items.Add(yuzdedegeri);
            }

            /////////////////////////////////////////////////////////////////////////
            foreach (string eleman in ma50coinlist)
            {
                if (eleman == null) break;
                listBox90.Items.Add(eleman + "BTC");

            }

            foreach (string yuzdedegeri in ma50coinyuzdelistesi)
            {
                if (yuzdedegeri == null) break;
                listBox89.Items.Add(yuzdedegeri);
            }
            /////////////////////////////////////////////////////////////////////////
            foreach (string eleman in ma100coinlist)
            {
                if (eleman == null) break;
                listBox88.Items.Add(eleman + "BTC");

            }

            foreach (string yuzdedegeri in ma100coinyuzdelistesi)
            {
                if (yuzdedegeri == null) break;
                listBox87.Items.Add(yuzdedegeri);

            }
            /////////////////////////////////////////////////////////////////////////
            foreach (string eleman in ma200coinlist)
            {
                if (eleman == null) break;
                listBox84.Items.Add(eleman + "BTC");

            }

            foreach (string yuzdedegeri in ma200coinyuzdelistesi)
            {
                if (yuzdedegeri == null) break;
                listBox83.Items.Add(yuzdedegeri);
            }
            /////////////////////////////////////////////////////////////////////////////

            foreach (string eleman in bbaltcoinlist)
            {
                if (eleman == null) break;
                listBox86.Items.Add(eleman + "BTC");

            }

            foreach (string yuzdedegeri in bbaltcoinyuzdelistesi)
            {
                if (yuzdedegeri == null) break;
                listBox85.Items.Add(yuzdedegeri);
            }
            ////////////////////////////////////////////////////////////////////////////
            foreach (string eleman in bbustcoinlist)
            {
                if (eleman == null) break;
                listBox74.Items.Add(eleman + "BTC");

            }

            foreach (string yuzdedegeri in bbustcoinyuzdelistesi)
            {
                if (yuzdedegeri == null) break;
                listBox73.Items.Add(yuzdedegeri);
            }
            //////////////////////////////////////////////////////////////////////////////
            foreach (string eleman in MACDcoinlist)
            {
                if (eleman == null) break;
                listBox78.Items.Add(eleman + "BTC");

            }


            foreach (string yuzdedegeri in MACDcoinyuzdelistesi)
            {
                if (yuzdedegeri == null) break;
                listBox77.Items.Add(yuzdedegeri.Substring(0, 5));
            }
            /////////////////////////////////////////////////////////////////////////////
            foreach (string eleman in MA10MA50coinlist)
            {
                if (eleman == null) break;
                listBox82.Items.Add(eleman + "BTC");

            }


            foreach (string yuzdedegeri in MA10MA50coinyuzdelistesi)
            {
                if (yuzdedegeri == null) break;
                listBox81.Items.Add(yuzdedegeri);
            }
            /////////////////////////////////////////////////////////////////////////////////
            foreach (string eleman in MAa10MA50coinlist)
            {
                if (eleman == null) break;
                listBox80.Items.Add(eleman + "BTC");

            }


            foreach (string yuzdedegeri in MAa10MA50coinyuzdelistesi)
            {
                if (yuzdedegeri == null) break;
                listBox79.Items.Add(yuzdedegeri);
            }
            timer6.Stop();
            timer4.Stop();
            timer3.Stop();
            timer2.Stop();
            timer1.Stop();
            timer7.Stop();
            if (radioButton8.Checked)
            {


                timer5.Start();
            }
            else if (radioButton7.Checked)
            {
                timer5.Stop();
            }
        }

        private void timer5_Tick(object sender, EventArgs e)
        {
            saniye--;

            label94.Text = (saniye % 60).ToString("00");
            label94.Visible = true;

            if (saniye == 00)
            {
                timer5.Stop();
                timer5.Enabled = true;
                timer5.Interval = 1000;
                saniye = 45;
                button5_Click(sender, e);
            }
        }

        private void listBox89_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();

            //Varsayılan öge rengi (fırçadan)
            Brush myBrush = Brushes.Green;


            //Örneğin 0 ile başlayanları kırmızı, 1 ile başlayanları mavi yap!

            if (listBox89.Items[e.Index].ToString().StartsWith("-") == true)
            {
                myBrush = Brushes.Red;
            }
            e.Graphics.DrawString(((ListBox)sender).Items[e.Index].ToString(),
e.Font, myBrush, e.Bounds, StringFormat.GenericDefault);

            e.DrawFocusRectangle();
        }

        private void listBox87_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();

            //Varsayılan öge rengi (fırçadan)
            Brush myBrush = Brushes.Green;


            //Örneğin 0 ile başlayanları kırmızı, 1 ile başlayanları mavi yap!

            if (listBox87.Items[e.Index].ToString().StartsWith("-") == true)
            {
                myBrush = Brushes.Red;
            }
            e.Graphics.DrawString(((ListBox)sender).Items[e.Index].ToString(),
e.Font, myBrush, e.Bounds, StringFormat.GenericDefault);

            e.DrawFocusRectangle();
        }

        private void listBox85_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();

            //Varsayılan öge rengi (fırçadan)
            Brush myBrush = Brushes.Green;


            //Örneğin 0 ile başlayanları kırmızı, 1 ile başlayanları mavi yap!

            if (listBox85.Items[e.Index].ToString().StartsWith("-") == true)
            {
                myBrush = Brushes.Red;
            }
            e.Graphics.DrawString(((ListBox)sender).Items[e.Index].ToString(),
e.Font, myBrush, e.Bounds, StringFormat.GenericDefault);

            e.DrawFocusRectangle();
        }

        private void listBox83_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();

            //Varsayılan öge rengi (fırçadan)
            Brush myBrush = Brushes.Green;


            //Örneğin 0 ile başlayanları kırmızı, 1 ile başlayanları mavi yap!

            if (listBox83.Items[e.Index].ToString().StartsWith("-") == true)
            {
                myBrush = Brushes.Red;
            }
            e.Graphics.DrawString(((ListBox)sender).Items[e.Index].ToString(),
e.Font, myBrush, e.Bounds, StringFormat.GenericDefault);

            e.DrawFocusRectangle();
        }

        private void listBox81_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();

            //Varsayılan öge rengi (fırçadan)
            Brush myBrush = Brushes.Green;


            //Örneğin 0 ile başlayanları kırmızı, 1 ile başlayanları mavi yap!

            if (listBox81.Items[e.Index].ToString().StartsWith("-") == true)
            {
                myBrush = Brushes.Red;
            }
            e.Graphics.DrawString(((ListBox)sender).Items[e.Index].ToString(),
e.Font, myBrush, e.Bounds, StringFormat.GenericDefault);

            e.DrawFocusRectangle();
        }

        private void listBox79_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();

            //Varsayılan öge rengi (fırçadan)
            Brush myBrush = Brushes.Green;


            //Örneğin 0 ile başlayanları kırmızı, 1 ile başlayanları mavi yap!

            if (listBox79.Items[e.Index].ToString().StartsWith("-") == true)
            {
                myBrush = Brushes.Red;
            }
            e.Graphics.DrawString(((ListBox)sender).Items[e.Index].ToString(),
e.Font, myBrush, e.Bounds, StringFormat.GenericDefault);

            e.DrawFocusRectangle();
        }

        private void listBox77_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();

            //Varsayılan öge rengi (fırçadan)
            Brush myBrush = Brushes.Green;


            //Örneğin 0 ile başlayanları kırmızı, 1 ile başlayanları mavi yap!

            if (listBox77.Items[e.Index].ToString().StartsWith("-") == true)
            {
                myBrush = Brushes.Red;
            }
            e.Graphics.DrawString(((ListBox)sender).Items[e.Index].ToString(),
e.Font, myBrush, e.Bounds, StringFormat.GenericDefault);

            e.DrawFocusRectangle();
        }

        private void listBox73_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();

            //Varsayılan öge rengi (fırçadan)
            Brush myBrush = Brushes.Green;


            //Örneğin 0 ile başlayanları kırmızı, 1 ile başlayanları mavi yap!

            if (listBox73.Items[e.Index].ToString().StartsWith("-") == true)
            {
                myBrush = Brushes.Red;
            }
            e.Graphics.DrawString(((ListBox)sender).Items[e.Index].ToString(),
e.Font, myBrush, e.Bounds, StringFormat.GenericDefault);

            e.DrawFocusRectangle();
        }
        private void listBox76_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();

            //Varsayılan öge rengi (fırçadan)
            Brush myBrush = Brushes.Green;


            //Örneğin 0 ile başlayanları kırmızı, 1 ile başlayanları mavi yap!

            if (listBox76.Items[e.Index].ToString().StartsWith("-") == true)
            {
                myBrush = Brushes.Red;
            }
            e.Graphics.DrawString(((ListBox)sender).Items[e.Index].ToString(),
e.Font, myBrush, e.Bounds, StringFormat.GenericDefault);

            e.DrawFocusRectangle();
        }
        private void listBox93_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();

            //Varsayılan öge rengi (fırçadan)
            Brush myBrush = Brushes.Green;


            //Örneğin 0 ile başlayanları kırmızı, 1 ile başlayanları mavi yap!

            if (listBox93.Items[e.Index].ToString().StartsWith("-") == true)
            {
                myBrush = Brushes.Red;
            }
            e.Graphics.DrawString(((ListBox)sender).Items[e.Index].ToString(),
e.Font, myBrush, e.Bounds, StringFormat.GenericDefault);

            e.DrawFocusRectangle();
        }
        private void listBox92_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();

            //Varsayılan öge rengi (fırçadan)
            Brush myBrush = Brushes.Green;


            //Örneğin 0 ile başlayanları kırmızı, 1 ile başlayanları mavi yap!

            if (listBox92.Items[e.Index].ToString().StartsWith("-") == true)
            {
                myBrush = Brushes.Red;
            }
            e.Graphics.DrawString(((ListBox)sender).Items[e.Index].ToString(),
e.Font, myBrush, e.Bounds, StringFormat.GenericDefault);

            e.DrawFocusRectangle();
        }


        private void listBox90_DoubleClick(object sender, EventArgs e)
        {
            string link = "https://tr.tradingview.com/chart/?symbol=BINANCE:" + listBox90.SelectedItem.ToString();
            System.Diagnostics.Process.Start(link);
        }

        private void listBox88_DoubleClick(object sender, EventArgs e)
        {
            string link = "https://tr.tradingview.com/chart/?symbol=BINANCE:" + listBox88.SelectedItem.ToString();
            System.Diagnostics.Process.Start(link);
        }

        private void listBox86_DoubleClick(object sender, EventArgs e)
        {
            string link = "https://tr.tradingview.com/chart/?symbol=BINANCE:" + listBox86.SelectedItem.ToString();
            System.Diagnostics.Process.Start(link);
        }

        private void listBox84_DoubleClick(object sender, EventArgs e)
        {
            string link = "https://tr.tradingview.com/chart/?symbol=BINANCE:" + listBox84.SelectedItem.ToString();
            System.Diagnostics.Process.Start(link);
        }

        private void listBox82_DoubleClick(object sender, EventArgs e)
        {
            string link = "https://tr.tradingview.com/chart/?symbol=BINANCE:" + listBox82.SelectedItem.ToString();
            System.Diagnostics.Process.Start(link);
        }

        private void listBox80_DoubleClick(object sender, EventArgs e)
        {
            string link = "https://tr.tradingview.com/chart/?symbol=BINANCE:" + listBox80.SelectedItem.ToString();
            System.Diagnostics.Process.Start(link);
        }

        private void listBox78_DoubleClick(object sender, EventArgs e)
        {
            string link = "https://tr.tradingview.com/chart/?symbol=BINANCE:" + listBox78.SelectedItem.ToString();
            System.Diagnostics.Process.Start(link);
        }

        private void listBox74_DoubleClick(object sender, EventArgs e)
        {
            string link = "https://tr.tradingview.com/chart/?symbol=BINANCE:" + listBox74.SelectedItem.ToString();
            System.Diagnostics.Process.Start(link);
        }

        private void listBox76_DoubleClick(object sender, EventArgs e)
        {
            string link = "https://tr.tradingview.com/chart/?symbol=BINANCE:" + listBox76.SelectedItem.ToString();
            System.Diagnostics.Process.Start(link);
        }

       

   

 

        

        private void listBox93_DoubleClick(object sender, EventArgs e)
        {
            string link = "https://tr.tradingview.com/chart/?symbol=BINANCE:" + listBox93.SelectedItem.ToString();
            System.Diagnostics.Process.Start(link);
        }

        private void listBox92_DoubleClick(object sender, EventArgs e)
        {
            string link = "https://tr.tradingview.com/chart/?symbol=BINANCE:" + listBox92.SelectedItem.ToString();
            System.Diagnostics.Process.Start(link);
        }

        private void listBox75_DoubleClick(object sender, EventArgs e)
        {
            string link = "https://tr.tradingview.com/chart/?symbol=BINANCE:" + listBox75.SelectedItem.ToString();
            System.Diagnostics.Process.Start(link);
        }

        private void listBox86_DoubleClick_1(object sender, EventArgs e)
        {
            string link = "https://tr.tradingview.com/chart/?symbol=BINANCE:" + listBox86.SelectedItem.ToString();
            System.Diagnostics.Process.Start(link);
        }

        private void listBox84_DoubleClick_1(object sender, EventArgs e)
        {
            string link = "https://tr.tradingview.com/chart/?symbol=BINANCE:" + listBox84.SelectedItem.ToString();
            System.Diagnostics.Process.Start(link);
        }

        private void listBox91_DoubleClick(object sender, EventArgs e)
        {
            string link = "https://tr.tradingview.com/chart/?symbol=BINANCE:" + listBox91.SelectedItem.ToString();
            System.Diagnostics.Process.Start(link);
        }

        private void listBox78_DoubleClick_1(object sender, EventArgs e)
        {
            string link = "https://tr.tradingview.com/chart/?symbol=BINANCE:" + listBox78.SelectedItem.ToString();
            System.Diagnostics.Process.Start(link);
        }

        private void listBox74_DoubleClick_1(object sender, EventArgs e)
        {
            string link = "https://tr.tradingview.com/chart/?symbol=BINANCE:" + listBox74.SelectedItem.ToString();
            System.Diagnostics.Process.Start(link);
        }

        private void listBox94_DoubleClick(object sender, EventArgs e)
        {
            string link = "https://tr.tradingview.com/chart/?symbol=BINANCE:" + listBox94.SelectedItem.ToString();
            System.Diagnostics.Process.Start(link);
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            
        }
        
private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void listBox95_DoubleClick(object sender, EventArgs e)
        {
            string link = "https://tr.tradingview.com/chart/?symbol=BINANCE:" + listBox95.SelectedItem.ToString();
            System.Diagnostics.Process.Start(link);
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://twitter.com/coinsspor");
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)

        {
            System.Diagnostics.Process.Start("https://twitter.com/coinmus");
            
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Clipboard.SetText("0x9e7edf9d457b6fb74902f554551356d793e988b4");
            MessageBox.Show("ETH address successfully copied");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Clipboard.SetText("1KUN6oRStXKkAfGmDzSTCdatetwj318pCD");
            MessageBox.Show("BTC address successfully copied");
        }

        private void button8_Click(object sender, EventArgs e)
        {
            saniye2 = 45;
            saniye = 45;
            saniye3 = 5;

            label19.Text = "45";
            label38.Text = "45";
            label75.Text = "45";
            label68.Text = "45";
            label94.Text = "45";
            label128.Text = "5";

            listBox99.Items.Clear();
            listBox100.Items.Clear();
            listBox101.Items.Clear();
            listBox102.Items.Clear();
            listBox103.Items.Clear();
            listBox104.Items.Clear();
            listBox107.Items.Clear();
            listBox108.Items.Clear();
            listBox109.Items.Clear();
            listBox110.Items.Clear();
            listBox111.Items.Clear();
            listBox112.Items.Clear();
            listBox113.Items.Clear();
            listBox114.Items.Clear();
            listBox115.Items.Clear();
            listBox116.Items.Clear();










            string ma50post4hour = "{\"filter\":[{\"left\":\"change|240\",\"operation\":\"nempty\"},{\"left\":\"exchange\",\"operation\":\"equal\",\"right\":\"BINANCE\"},{\"left\":\"SMA50|240\",\"operation\":\"crosses_below\",\"right\":\"close|240\"},{\"left\":\"name\",\"operation\":\"match\",\"right\":\"BTC\"}],\"symbols\":{\"query\":{\"types\":[]}},\"columns\":[\"name\",\"change|240\",\"name\",\"subtype\"],\"sort\":{\"sortBy\":\"change|240\",\"sortOrder\":\"desc\"},\"options\":{\"lang\":\"tr\"},\"range\":[0,150]}";
            string ma504hourkaynak = postyolla(ma50post4hour);//ma50 4 hour
            string[] ma50coinlist = coinlistal(ma504hourkaynak);
            string[] ma50coinyuzdelistesi = coinyuzdeal(ma504hourkaynak);

            string BBUPALERTpost4hour = "{\"filter\":[{\"left\":\"change|240\",\"operation\":\"nempty\"},{\"left\":\"exchange\",\"operation\":\"equal\",\"right\":\"BINANCE\"},{\"left\":\"BB.upper|240\",\"operation\":\"crosses_below\",\"right\":\"close|240\"},{\"left\":\"name\",\"operation\":\"match\",\"right\":\"BTC\"}],\"symbols\":{\"query\":{\"types\":[]}},\"columns\":[\"name\",\"change|240\",\"name\",\"subtype\"],\"sort\":{\"sortBy\":\"change|240\",\"sortOrder\":\"desc\"},\"options\":{\"lang\":\"tr\"},\"range\":[0,150]}";
            string BBUPALERT4hourkaynak = postyolla(BBUPALERTpost4hour);//BBUPALERT 4 hour
            string[] BBUPALERTcoinlist = coinlistal(BBUPALERT4hourkaynak);
            string[] BBUPALERTcoinyuzdelistesi = coinyuzdeal(BBUPALERT4hourkaynak);

            string BBELOWALERTpost4hour = "{\"filter\":[{\"left\":\"change|240\",\"operation\":\"nempty\"},{\"left\":\"exchange\",\"operation\":\"equal\",\"right\":\"BINANCE\"},{\"left\":\"BB.lower|240\",\"operation\":\"greater\",\"right\":\"low|240\"},{\"left\":\"name\",\"operation\":\"match\",\"right\":\"btc\"}],\"symbols\":{\"query\":{\"types\":[]}},\"columns\":[\"name\",\"change|240\",\"name\",\"subtype\"],\"sort\":{\"sortBy\":\"change|240\",\"sortOrder\":\"desc\"},\"options\":{\"lang\":\"tr\"},\"range\":[0,150]}";
            string BBELOWALERT4hourkaynak = postyolla(BBELOWALERTpost4hour);//BBBELOWALERT 4 hour
            string[] BBELOWALERTcoinlist = coinlistal(BBELOWALERT4hourkaynak);
            string[] BBELOWALERTcoinyuzdelistesi = coinyuzdeal(BBELOWALERT4hourkaynak);

            

            string SARONEpost4hour = "{\"filter\":[{\"left\":\"change|240\",\"operation\":\"nempty\"},{\"left\":\"exchange\",\"operation\":\"equal\",\"right\":\"BINANCE\"},{\"left\":\"ADX|240\",\"operation\":\"greater\",\"right\":20},{\"left\":\"P.SAR|240\",\"operation\":\"crosses_below\",\"right\":\"close|240\"},{\"left\":\"name\",\"operation\":\"match\",\"right\":\"btc\"}],\"symbols\":{\"query\":{\"types\":[]}},\"columns\":[\"name\",\"change|240\",\"name\",\"subtype\"],\"sort\":{\"sortBy\":\"change|240\",\"sortOrder\":\"desc\"},\"options\":{\"lang\":\"tr\"},\"range\":[0,150]}";
            string SARONE4hourkaynak = postyolla(SARONEpost4hour);//PARABOLİK SAR ve adx>20 4 HOUR
            string[] SARONEcoinlist = coinlistal(SARONE4hourkaynak);
            string[] SARONEcoinyuzdelistesi = coinyuzdeal(SARONE4hourkaynak);

            string ICHTRENDUPpost4hour = "{\"filter\":[{\"left\":\"change|240\",\"operation\":\"nempty\"},{\"left\":\"exchange\",\"operation\":\"equal\",\"right\":\"BINANCE\"},{\"left\":\"ADX|240\",\"operation\":\"egreater\",\"right\":40},{\"left\":\"Ichimoku.CLine|240\",\"operation\":\"less\",\"right\":\"close|240\"},{\"left\":\"Ichimoku.BLine|240\",\"operation\":\"less\",\"right\":\"Ichimoku.CLine|240\"},{\"left\":\"Ichimoku.Lead1|240\",\"operation\":\"greater\",\"right\":\"Ichimoku.Lead2|240\"},{\"left\":\"name\",\"operation\":\"match\",\"right\":\"btc\"}],\"symbols\":{\"query\":{\"types\":[]}},\"columns\":[\"name\",\"change|240\",\"name\",\"subtype\"],\"sort\":{\"sortBy\":\"change|240\",\"sortOrder\":\"desc\"},\"options\":{\"lang\":\"tr\"},\"range\":[0,150]}";
            string ICHTRENDUP4hourkaynak = postyolla(ICHTRENDUPpost4hour);//ICHTRENDUP 4H adx>=40
            string[] ICHTRENDUPcoinlist = coinlistal(ICHTRENDUP4hourkaynak);
            string[] ICHTRENDUPcoinyuzdelistesi = coinyuzdeal(ICHTRENDUP4hourkaynak);

            string ICHTRENDUP1daypost4hour = "{\"filter\":[{\"left\":\"change\",\"operation\":\"nempty\"},{\"left\":\"exchange\",\"operation\":\"equal\",\"right\":\"BINANCE\"},{\"left\":\"ADX\",\"operation\":\"egreater\",\"right\":40},{\"left\":\"Ichimoku.CLine\",\"operation\":\"less\",\"right\":\"close\"},{\"left\":\"Ichimoku.BLine\",\"operation\":\"less\",\"right\":\"Ichimoku.CLine\"},{\"left\":\"Ichimoku.Lead1\",\"operation\":\"greater\",\"right\":\"Ichimoku.Lead2\"},{\"left\":\"name,description\",\"operation\":\"match\",\"right\":\"btc\"}],\"symbols\":{\"query\":{\"types\":[]}},\"columns\":[\"name\",\"close\",\"change\",\"change_abs\",\"high\",\"low\",\"volume\",\"Recommend.All\",\"exchange\",\"description\",\"name\",\"subtype\",\"pricescale\",\"minmov\",\"fractional\",\"minmove2\"],\"sort\":{\"sortBy\":\"change\",\"sortOrder\":\"desc\"},\"options\":{\"lang\":\"tr\"},\"range\":[0,150]}";
            string ICHTRENDUP1day4hourkaynak = postyolla(ICHTRENDUP1daypost4hour);//ICHTRENDUP 1D adx>=40
            string[] ICHTRENDUP1daycoinlist = coinlistal(ICHTRENDUP1day4hourkaynak);
            string[] ICHTRENDUP1daycoinyuzdelistesi = coinyuzdeal(ICHTRENDUP1day4hourkaynak);

            

            string ICHSTRONGBUYFOURpost4hour = "{\"filter\":[{\"left\":\"change|240\",\"operation\":\"nempty\"},{\"left\":\"exchange\",\"operation\":\"equal\",\"right\":\"BINANCE\"},{\"left\":\"Ichimoku.CLine|240\",\"operation\":\"crosses_above\",\"right\":\"Ichimoku.BLine|240\"},{\"left\":\"Ichimoku.BLine|240\",\"operation\":\"greater\",\"right\":\"Ichimoku.Lead2|240\"},{\"left\":\"name\",\"operation\":\"match\",\"right\":\"BTC\"}],\"symbols\":{\"query\":{\"types\":[]}},\"columns\":[\"name\",\"change|240\",\"name\",\"subtype\"],\"sort\":{\"sortBy\":\"change|240\",\"sortOrder\":\"desc\"},\"options\":{\"lang\":\"tr\"},\"range\":[0,150]}";
            string ICHSTRONGBUYFOUR4hourkaynak = postyolla(ICHSTRONGBUYFOURpost4hour);//ICHSTRONGBUYFOUR HOUR
            string[] ICHSTRONGBUYFOURcoinlist = coinlistal(ICHSTRONGBUYFOUR4hourkaynak);
            string[] ICHSTRONGBUYFOURoinyuzdelistesi = coinyuzdeal(ICHSTRONGBUYFOUR4hourkaynak);

            string ICHSTRONGBUYONEpost4hour = "{\"filter\":[{\"left\":\"change\",\"operation\":\"nempty\"},{\"left\":\"exchange\",\"operation\":\"equal\",\"right\":\"BINANCE\"},{\"left\":\"Ichimoku.CLine\",\"operation\":\"crosses_above\",\"right\":\"Ichimoku.BLine\"},{\"left\":\"Ichimoku.BLine\",\"operation\":\"greater\",\"right\":\"Ichimoku.Lead2\"},{\"left\":\"name\",\"operation\":\"match\",\"right\":\"BTC\"}],\"symbols\":{\"query\":{\"types\":[]}},\"columns\":[\"name\",\"change\",\"name\",\"subtype\"],\"sort\":{\"sortBy\":\"change\",\"sortOrder\":\"desc\"},\"options\":{\"lang\":\"tr\"},\"range\":[0,150]}";
            string ICHSTRONGBUYONE4hourkaynak = postyolla(ICHSTRONGBUYONEpost4hour);//ICHSTRONGBUY 1 DAY
            string[] ICHSTRONGBUYONEcoinlist = coinlistal(ICHSTRONGBUYONE4hourkaynak);
            string[] ICHSTRONGBUYONEoinyuzdelistesi = coinyuzdeal(ICHSTRONGBUYONE4hourkaynak);


            foreach (string eleman in ma50coinlist)
            {
                if (eleman == null) break;
                listBox100.Items.Add(eleman + "BTC");

            }

            foreach (string yuzdedegeri in ma50coinyuzdelistesi)
            {
                if (yuzdedegeri == null) break;
                listBox99.Items.Add(yuzdedegeri);
            }

//////////////////////////////////////////////////////////////////////////////////////
            foreach (string eleman in BBUPALERTcoinlist)
            {
                if (eleman == null) break;
                listBox102.Items.Add(eleman + "BTC");

            }

            foreach (string yuzdedegeri in BBUPALERTcoinyuzdelistesi)
            {
                if (yuzdedegeri == null) break;
                listBox101.Items.Add(yuzdedegeri);
            }
///////////////////////////////////////////////////////////////////////////////////
            foreach (string eleman in BBELOWALERTcoinlist)
            {
                if (eleman == null) break;
                listBox104.Items.Add(eleman + "BTC");

            }

            foreach (string yuzdedegeri in BBELOWALERTcoinyuzdelistesi)
            {
                if (yuzdedegeri == null) break;
                listBox103.Items.Add(yuzdedegeri);
            }
            ///////////////////////////////////////////////////////////////////////////////////

            

            foreach (string eleman in SARONEcoinlist)
            {
                if (eleman == null) break;
                listBox116.Items.Add(eleman + "BTC");

            }

            foreach (string yuzdedegeri in SARONEcoinyuzdelistesi)
            {
                if (yuzdedegeri == null) break;
                listBox115.Items.Add(yuzdedegeri);
            }
            ///////////////////////////////////////////////////////////////////////////////////

            foreach (string eleman in ICHTRENDUPcoinlist)
            {
                if (eleman == null) break;
                listBox108.Items.Add(eleman + "BTC");

            }

            foreach (string yuzdedegeri in ICHTRENDUPcoinyuzdelistesi)
            {
                if (yuzdedegeri == null) break;
                listBox107.Items.Add(yuzdedegeri);
            }
            ///////////////////////////////////////////////////////////////////////////////////
            foreach (string eleman in ICHTRENDUP1daycoinlist)
            {
                if (eleman == null) break;
                listBox114.Items.Add(eleman + "BTC");

            }

            foreach (string yuzdedegeri in ICHTRENDUP1daycoinyuzdelistesi)
            {
                if (yuzdedegeri == null) break;
                listBox113.Items.Add(yuzdedegeri);
            }
            ///////////////////////////////////////////////////////////////////////////////////

           

            foreach (string eleman in ICHSTRONGBUYFOURcoinlist)
            {
                if (eleman == null) break;
                listBox110.Items.Add(eleman + "BTC");

            }

            foreach (string yuzdedegeri in ICHSTRONGBUYFOURoinyuzdelistesi)
            {
                if (yuzdedegeri == null) break;
                listBox109.Items.Add(yuzdedegeri);
            }

            /////////////////////////////////////////////////////////////////////////////////

            foreach (string eleman in ICHSTRONGBUYONEcoinlist)
            {
                if (eleman == null) break;
                listBox112.Items.Add(eleman + "BTC");

            }

            foreach (string yuzdedegeri in ICHSTRONGBUYONEoinyuzdelistesi)
            {
                if (yuzdedegeri == null) break;
                listBox111.Items.Add(yuzdedegeri);
            }

            timer4.Stop();
            timer3.Stop();
            timer5.Stop();
            timer1.Stop();
            timer2.Stop();
            timer7.Stop();
            if (radioButton14.Checked)
            {
                timer6.Start();
            }
            else if (radioButton13.Checked)
            {
                timer6.Stop();
            }



        }

        private void timer6_Tick(object sender, EventArgs e)
        {
            saniye2--;

            label131.Text = (saniye2 % 60).ToString("00");
            label131.Visible = true;

            if (saniye2 == 00)
            {
                timer6.Stop();
                timer6.Enabled = true;
                timer6.Interval = 1000;
                saniye2 = 45;
                button8_Click(sender, e);
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            saniye3 = 5;

            label19.Text = "45";
            label38.Text = "45";
            label75.Text = "45";
            label68.Text = "45";
            label94.Text = "45";
            label31.Text = "45";




            listBox97.Items.Clear();
            listBox98.Items.Clear();
            listBox117.Items.Clear();
            listBox118.Items.Clear();
            listBox121.Items.Clear();
            listBox122.Items.Clear();
            listBox106.Items.Clear();
            listBox105.Items.Clear();

            string SARpost4hour = "{\"filter\":[{\"left\":\"change|5\",\"operation\":\"nempty\"},{\"left\":\"exchange\",\"operation\":\"equal\",\"right\":\"BINANCE\"},{\"left\":\"ADX|5\",\"operation\":\"greater\",\"right\":20},{\"left\":\"P.SAR|5\",\"operation\":\"crosses_below\",\"right\":\"close|5\"},{\"left\":\"name\",\"operation\":\"match\",\"right\":\"btc\"}],\"symbols\":{\"query\":{\"types\":[]}},\"columns\":[\"name\",\"change|5\",\"name\",\"subtype\"],\"sort\":{\"sortBy\":\"change|5\",\"sortOrder\":\"desc\"},\"options\":{\"lang\":\"tr\"},\"range\":[0,150]}";
            string SAR4hourkaynak = postyolla(SARpost4hour);//PARABOLİK SAR ve adx>20 5 MUNITE
            string[] SARcoinlist = coinlistal(SAR4hourkaynak);
            string[] SARcoinyuzdelistesi = coinyuzdeal(SAR4hourkaynak);

            string EMAVEMApost4hour = "{\"filter\":[{\"left\":\"name\",\"operation\":\"nempty\"},{\"left\":\"exchange\",\"operation\":\"equal\",\"right\":\"BINANCE\"},{\"left\":\"EMA10|5\",\"operation\":\"crosses_above\",\"right\":\"SMA20|5\"},{\"left\":\"name\",\"operation\":\"match\",\"right\":\"btc\"}],\"symbols\":{\"query\":{\"types\":[]}},\"columns\":[\"name\",\"change|5\",\"name\",\"subtype\"],\"sort\":{\"sortBy\":\"name\",\"sortOrder\":\"asc\"},\"options\":{\"lang\":\"tr\"},\"range\":[0,150]}";
            string EMAVEMA4hourkaynak = postyolla(EMAVEMApost4hour);//EMA CORESSES MA 5 MUNITES
            string[] EMAVEMAcoinlist = coinlistal(EMAVEMA4hourkaynak);
            string[] EMAVEMAcoinyuzdelistesi = coinyuzdeal(EMAVEMA4hourkaynak);

            string GAINERSpost4hour = "{\"filter\":[{\"left\":\"change|5\",\"operation\":\"nempty\"},{\"left\":\"exchange\",\"operation\":\"equal\",\"right\":\"BINANCE\"},{\"left\":\"change|5\",\"operation\":\"greater\",\"right\":0},{\"left\":\"name\",\"operation\":\"match\",\"right\":\"BTC\"}],\"symbols\":{\"query\":{\"types\":[]}},\"columns\":[\"name\",\"change|5\",\"name\",\"subtype\"],\"sort\":{\"sortBy\":\"change|5\",\"sortOrder\":\"desc\"},\"options\":{\"lang\":\"tr\"},\"range\":[0,150]}";
            string GAINERS4hourkaynak = postyolla(GAINERSpost4hour);//GAINERS5 MUNITES
            string[] GAINERScoinlist = coinlistal(GAINERS4hourkaynak);
            string[] GAINERSoinyuzdelistesi = coinyuzdeal(GAINERS4hourkaynak);

            string LOSERSpost4hour = "{\"filter\":[{\"left\":\"change|5\",\"operation\":\"nempty\"},{\"left\":\"exchange\",\"operation\":\"equal\",\"right\":\"BINANCE\"},{\"left\":\"change|5\",\"operation\":\"less\",\"right\":0},{\"left\":\"name\",\"operation\":\"match\",\"right\":\"BTC\"}],\"symbols\":{\"query\":{\"types\":[]}},\"columns\":[\"name\",\"change|5\",\"name\",\"subtype\"],\"sort\":{\"sortBy\":\"change|5\",\"sortOrder\":\"asc\"},\"options\":{\"lang\":\"tr\"},\"range\":[0,150]}";
            string LOSERS4hourkaynak = postyolla(LOSERSpost4hour);//LOSERS MUNITES
            string[] LOSERScoinlist = coinlistal(LOSERS4hourkaynak);
            string[] LOSERSoinyuzdelistesi = coinyuzdeal(LOSERS4hourkaynak);


            foreach (string eleman in SARcoinlist)
            {
                if (eleman == null) break;
                listBox106.Items.Add(eleman + "BTC");

            }

            foreach (string yuzdedegeri in SARcoinyuzdelistesi)
            {
                if (yuzdedegeri == null) break;
                listBox105.Items.Add(yuzdedegeri);
            }
            ///////////////////////////////////////////////////////////////////////////////////

            foreach (string eleman in EMAVEMAcoinlist)
            {
                if (eleman == null) break;
                listBox122.Items.Add(eleman + "BTC");

            }

            foreach (string yuzdedegeri in EMAVEMAcoinyuzdelistesi)
            {
                if (yuzdedegeri == null) break;
                listBox121.Items.Add(yuzdedegeri);
            }
            ///////////////////////////////////////////////////////////////////////////////////
            for (int i = 0; i <= 15; i++)
            {
                if (GAINERSoinyuzdelistesi[i] == null) break;
                listBox97.Items.Add(GAINERScoinlist[i]);
                listBox98.Items.Add(GAINERSoinyuzdelistesi[i]);
            }
            /////////////////////////////////////////////////////////////////////////////////

            for (int i = 0; i <= 15; i++)
            {
                if (LOSERSoinyuzdelistesi[i] == null) break;
                listBox118.Items.Add(LOSERScoinlist[i]);
                listBox117.Items.Add(LOSERSoinyuzdelistesi[i]);
            }
            /////////////////////////////////////////////////////////////////////////////////
            timer4.Stop();
            timer3.Stop();
            timer5.Stop();
            timer1.Stop();
            timer2.Stop();
            timer6.Stop();
            timer7.Start();

        }

        private void timer7_Tick(object sender, EventArgs e)
        {
            saniye3--;

            label128.Text = (saniye3 % 60).ToString("00");
            label128.Visible = true;

            if (saniye3 == 00)
            {
                timer7.Stop();
                timer7.Enabled = true;
                timer7.Interval = 1000;
                saniye3 = 5;
                button9_Click(sender, e);
            }
        }

        private void listBox100_DoubleClick(object sender, EventArgs e)
        {
            string link = "https://tr.tradingview.com/chart/?symbol=BINANCE:" + listBox100.SelectedItem.ToString();
            System.Diagnostics.Process.Start(link);
        }

        private void listBox102_DoubleClick(object sender, EventArgs e)
        {
            string link = "https://tr.tradingview.com/chart/?symbol=BINANCE:" + listBox102.SelectedItem.ToString();
            System.Diagnostics.Process.Start(link);
        }

        private void listBox104_DoubleClick(object sender, EventArgs e)
        {
            string link = "https://tr.tradingview.com/chart/?symbol=BINANCE:" + listBox104.SelectedItem.ToString();
            System.Diagnostics.Process.Start(link);
        }

        private void listBox108_DoubleClick(object sender, EventArgs e)
        {
            string link = "https://tr.tradingview.com/chart/?symbol=BINANCE:" + listBox108.SelectedItem.ToString();
            System.Diagnostics.Process.Start(link);
        }

        private void listBox114_DoubleClick(object sender, EventArgs e)
        {
            string link = "https://tr.tradingview.com/chart/?symbol=BINANCE:" + listBox114.SelectedItem.ToString();
            System.Diagnostics.Process.Start(link);
        }

        private void listBox116_DoubleClick(object sender, EventArgs e)
        {
            string link = "https://tr.tradingview.com/chart/?symbol=BINANCE:" + listBox116.SelectedItem.ToString();
            System.Diagnostics.Process.Start(link);
        }

        private void listBox110_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listBox110_DoubleClick(object sender, EventArgs e)
        {
            string link = "https://tr.tradingview.com/chart/?symbol=BINANCE:" + listBox110.SelectedItem.ToString();
            System.Diagnostics.Process.Start(link);
        }

        private void listBox112_DoubleClick(object sender, EventArgs e)
        {
            string link = "https://tr.tradingview.com/chart/?symbol=BINANCE:" + listBox112.SelectedItem.ToString();
            System.Diagnostics.Process.Start(link);
        }

        private void listBox122_DoubleClick(object sender, EventArgs e)
        {
            string link = "https://tr.tradingview.com/chart/?symbol=BINANCE:" + listBox122.SelectedItem.ToString();
            System.Diagnostics.Process.Start(link);
        }

        private void listBox106_DoubleClick(object sender, EventArgs e)
        {
            string link = "https://tr.tradingview.com/chart/?symbol=BINANCE:" + listBox106.SelectedItem.ToString();
            System.Diagnostics.Process.Start(link);
        }

        private void listBox97_DoubleClick(object sender, EventArgs e)
        {
            string link = "https://tr.tradingview.com/chart/?symbol=BINANCE:" + listBox97.SelectedItem.ToString() + "BTC";
            System.Diagnostics.Process.Start(link);
        }

        private void listBox118_DoubleClick(object sender, EventArgs e)
        {
            string link = "https://tr.tradingview.com/chart/?symbol=BINANCE:" + listBox118.SelectedItem.ToString() + "BTC";
            System.Diagnostics.Process.Start(link);
        }

        private void tabPage6_Click(object sender, EventArgs e)
        {

        }



     

        private void listBox117_DrawItem_1(object sender, DrawItemEventArgs e)
        {

        }

        private void listBox121_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();

            //Varsayılan öge rengi (fırçadan)
            Brush myBrush = Brushes.Green;


            //Örneğin 0 ile başlayanları kırmızı, 1 ile başlayanları mavi yap!

            if (listBox121.Items[e.Index].ToString().StartsWith("-") == true)
            {
                myBrush = Brushes.Red;
            }
            e.Graphics.DrawString(((ListBox)sender).Items[e.Index].ToString(),
e.Font, myBrush, e.Bounds, StringFormat.GenericDefault);

            e.DrawFocusRectangle();
        }

        private void listBox122_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();

            //Varsayılan öge rengi (fırçadan)
            Brush myBrush = Brushes.Black;


            //Örneğin 0 ile başlayanları kırmızı, 1 ile başlayanları mavi yap!

            if (listBox122.Items[e.Index].ToString().StartsWith("-") == true)
            {
                myBrush = Brushes.Red;
            }
            e.Graphics.DrawString(((ListBox)sender).Items[e.Index].ToString(),
e.Font, myBrush, e.Bounds, StringFormat.GenericDefault);

            e.DrawFocusRectangle();
        }

        private void listBox102_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();

            //Varsayılan öge rengi (fırçadan)
            Brush myBrush = Brushes.Black;


            //Örneğin 0 ile başlayanları kırmızı, 1 ile başlayanları mavi yap!

            if (listBox102.Items[e.Index].ToString().StartsWith("-") == true)
            {
                myBrush = Brushes.Red;
            }
            e.Graphics.DrawString(((ListBox)sender).Items[e.Index].ToString(),
e.Font, myBrush, e.Bounds, StringFormat.GenericDefault);

            e.DrawFocusRectangle();
        }

        private void listBox104_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();

            //Varsayılan öge rengi (fırçadan)
            Brush myBrush = Brushes.Black;


            //Örneğin 0 ile başlayanları kırmızı, 1 ile başlayanları mavi yap!

            if (listBox104.Items[e.Index].ToString().StartsWith("-") == true)
            {
                myBrush = Brushes.Red;
            }
            e.Graphics.DrawString(((ListBox)sender).Items[e.Index].ToString(),
e.Font, myBrush, e.Bounds, StringFormat.GenericDefault);

            e.DrawFocusRectangle();
        }

        private void listBox108_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();

            //Varsayılan öge rengi (fırçadan)
            Brush myBrush = Brushes.Black;


            //Örneğin 0 ile başlayanları kırmızı, 1 ile başlayanları mavi yap!

            if (listBox108.Items[e.Index].ToString().StartsWith("-") == true)
            {
                myBrush = Brushes.Red;
            }
            e.Graphics.DrawString(((ListBox)sender).Items[e.Index].ToString(),
e.Font, myBrush, e.Bounds, StringFormat.GenericDefault);

            e.DrawFocusRectangle();
        }

        private void listBox114_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();

            //Varsayılan öge rengi (fırçadan)
            Brush myBrush = Brushes.Black;


            //Örneğin 0 ile başlayanları kırmızı, 1 ile başlayanları mavi yap!

            if (listBox114.Items[e.Index].ToString().StartsWith("-") == true)
            {
                myBrush = Brushes.Red;
            }
            e.Graphics.DrawString(((ListBox)sender).Items[e.Index].ToString(),
e.Font, myBrush, e.Bounds, StringFormat.GenericDefault);

            e.DrawFocusRectangle();
        }

        private void listBox110_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();

            //Varsayılan öge rengi (fırçadan)
            Brush myBrush = Brushes.Black;


            //Örneğin 0 ile başlayanları kırmızı, 1 ile başlayanları mavi yap!

            if (listBox110.Items[e.Index].ToString().StartsWith("-") == true)
            {
                myBrush = Brushes.Red;
            }
            e.Graphics.DrawString(((ListBox)sender).Items[e.Index].ToString(),
e.Font, myBrush, e.Bounds, StringFormat.GenericDefault);

            e.DrawFocusRectangle();
        }

        private void listBox112_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();

            //Varsayılan öge rengi (fırçadan)
            Brush myBrush = Brushes.Black;


            //Örneğin 0 ile başlayanları kırmızı, 1 ile başlayanları mavi yap!

            if (listBox112.Items[e.Index].ToString().StartsWith("-") == true)
            {
                myBrush = Brushes.Red;
            }
            e.Graphics.DrawString(((ListBox)sender).Items[e.Index].ToString(),
e.Font, myBrush, e.Bounds, StringFormat.GenericDefault);

            e.DrawFocusRectangle();
        }

        private void listBox106_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();

            //Varsayılan öge rengi (fırçadan)
            Brush myBrush = Brushes.Black;


            //Örneğin 0 ile başlayanları kırmızı, 1 ile başlayanları mavi yap!

            if (listBox106.Items[e.Index].ToString().StartsWith("-") == true)
            {
                myBrush = Brushes.Red;
            }
            e.Graphics.DrawString(((ListBox)sender).Items[e.Index].ToString(),
e.Font, myBrush, e.Bounds, StringFormat.GenericDefault);

            e.DrawFocusRectangle();
        }

        private void listBox103_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();

            //Varsayılan öge rengi (fırçadan)
            Brush myBrush = Brushes.Green;


            //Örneğin 0 ile başlayanları kırmızı, 1 ile başlayanları mavi yap!

            if (listBox103.Items[e.Index].ToString().StartsWith("-") == true)
            {
                myBrush = Brushes.Red;
            }
            e.Graphics.DrawString(((ListBox)sender).Items[e.Index].ToString(),
e.Font, myBrush, e.Bounds, StringFormat.GenericDefault);

            e.DrawFocusRectangle();
        }

        private void listBox107_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();

            //Varsayılan öge rengi (fırçadan)
            Brush myBrush = Brushes.Green;


            //Örneğin 0 ile başlayanları kırmızı, 1 ile başlayanları mavi yap!

            if (listBox107.Items[e.Index].ToString().StartsWith("-") == true)
            {
                myBrush = Brushes.Red;
            }
            e.Graphics.DrawString(((ListBox)sender).Items[e.Index].ToString(),
e.Font, myBrush, e.Bounds, StringFormat.GenericDefault);

            e.DrawFocusRectangle();
        }

        private void listBox113_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();

            //Varsayılan öge rengi (fırçadan)
            Brush myBrush = Brushes.Green;


            //Örneğin 0 ile başlayanları kırmızı, 1 ile başlayanları mavi yap!

            if (listBox113.Items[e.Index].ToString().StartsWith("-") == true)
            {
                myBrush = Brushes.Red;
            }
            e.Graphics.DrawString(((ListBox)sender).Items[e.Index].ToString(),
e.Font, myBrush, e.Bounds, StringFormat.GenericDefault);

            e.DrawFocusRectangle();
        }

        private void listBox109_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();

            //Varsayılan öge rengi (fırçadan)
            Brush myBrush = Brushes.Green;


            //Örneğin 0 ile başlayanları kırmızı, 1 ile başlayanları mavi yap!

            if (listBox109.Items[e.Index].ToString().StartsWith("-") == true)
            {
                myBrush = Brushes.Red;
            }
            e.Graphics.DrawString(((ListBox)sender).Items[e.Index].ToString(),
e.Font, myBrush, e.Bounds, StringFormat.GenericDefault);

            e.DrawFocusRectangle();
        }

        private void listBox111_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();

            //Varsayılan öge rengi (fırçadan)
            Brush myBrush = Brushes.Green;


            //Örneğin 0 ile başlayanları kırmızı, 1 ile başlayanları mavi yap!

            if (listBox111.Items[e.Index].ToString().StartsWith("-") == true)
            {
                myBrush = Brushes.Red;
            }
            e.Graphics.DrawString(((ListBox)sender).Items[e.Index].ToString(),
e.Font, myBrush, e.Bounds, StringFormat.GenericDefault);

            e.DrawFocusRectangle();
        }

        private void listBox105_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();

            //Varsayılan öge rengi (fırçadan)
            Brush myBrush = Brushes.Green;


            //Örneğin 0 ile başlayanları kırmızı, 1 ile başlayanları mavi yap!

            if (listBox105.Items[e.Index].ToString().StartsWith("-") == true)
            {
                myBrush = Brushes.Red;
            }
            e.Graphics.DrawString(((ListBox)sender).Items[e.Index].ToString(),
e.Font, myBrush, e.Bounds, StringFormat.GenericDefault);

            e.DrawFocusRectangle();
        }

        private void listBox101_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();

            //Varsayılan öge rengi (fırçadan)
            Brush myBrush = Brushes.Green;


            //Örneğin 0 ile başlayanları kırmızı, 1 ile başlayanları mavi yap!

            if (listBox101.Items[e.Index].ToString().StartsWith("-") == true)
            {
                myBrush = Brushes.Red;
            }
            e.Graphics.DrawString(((ListBox)sender).Items[e.Index].ToString(),
e.Font, myBrush, e.Bounds, StringFormat.GenericDefault);

            e.DrawFocusRectangle();
        }

        private void listBox99_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();

            //Varsayılan öge rengi (fırçadan)
            Brush myBrush = Brushes.Green;


            //Örneğin 0 ile başlayanları kırmızı, 1 ile başlayanları mavi yap!

            if (listBox99.Items[e.Index].ToString().StartsWith("-") == true)
            {
                myBrush = Brushes.Red;
            }
            e.Graphics.DrawString(((ListBox)sender).Items[e.Index].ToString(),
e.Font, myBrush, e.Bounds, StringFormat.GenericDefault);

            e.DrawFocusRectangle();
        }

        private void listBox100_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();

            //Varsayılan öge rengi (fırçadan)
            Brush myBrush = Brushes.Black;


            //Örneğin 0 ile başlayanları kırmızı, 1 ile başlayanları mavi yap!

            if (listBox100.Items[e.Index].ToString().StartsWith("-") == true)
            {
                myBrush = Brushes.Red;
            }
            e.Graphics.DrawString(((ListBox)sender).Items[e.Index].ToString(),
e.Font, myBrush, e.Bounds, StringFormat.GenericDefault);

            e.DrawFocusRectangle();
        }

        private void listBox116_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();

            //Varsayılan öge rengi (fırçadan)
            Brush myBrush = Brushes.Black;


            //Örneğin 0 ile başlayanları kırmızı, 1 ile başlayanları mavi yap!

            if (listBox116.Items[e.Index].ToString().StartsWith("-") == true)
            {
                myBrush = Brushes.Red;
            }
            e.Graphics.DrawString(((ListBox)sender).Items[e.Index].ToString(),
e.Font, myBrush, e.Bounds, StringFormat.GenericDefault);

            e.DrawFocusRectangle();
        }

        private void listBox115_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();

            //Varsayılan öge rengi (fırçadan)
            Brush myBrush = Brushes.Green;


            //Örneğin 0 ile başlayanları kırmızı, 1 ile başlayanları mavi yap!

            if (listBox115.Items[e.Index].ToString().StartsWith("-") == true)
            {
                myBrush = Brushes.Red;
            }
            e.Graphics.DrawString(((ListBox)sender).Items[e.Index].ToString(),
e.Font, myBrush, e.Bounds, StringFormat.GenericDefault);

            e.DrawFocusRectangle();
        }
    }
    }

