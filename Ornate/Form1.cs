using System;
using System.Collections.Generic;

using System.Windows.Forms;
using System.Speech.Synthesis;
using System.Speech.Recognition;
using System.IO;
using System.Threading.Tasks;
using System.Drawing;
using System.Text;

namespace Ornate
{
    public partial class Form1 : Form
    {
        private string[] lines;
        private SpeechSynthesizer sSynth = new SpeechSynthesizer();
        private PromptBuilder pBuilder = new PromptBuilder();
        private SpeechRecognitionEngine sRecognize = new SpeechRecognitionEngine();
        private OrnateBayesClassifier _classifier;
        private Dictionary<String, String> _dataset;
        private List<String> _classifiedContent;
        private PDFConverter _converter;
        private Boolean fileParsed;
        private Boolean deficientParsed;
        private string deficientDirectory;
        private Boolean key_space = false;
        private List<String> recordedPhrases;
        private Boolean recordingSpeech = false;
        public Form1()
        {
            InitializeComponent();
            recordedPhrases = new List<String>();
            PopulateListBox(lstuatoSlides, @"C:\Ornate\Ornate\data\out", "*.pdf");
            _converter = new PDFConverter();
            btnUploadDeficient.Enabled = false;


            _classifier = new OrnateBayesClassifier();
            _classifiedContent = new List<String>();
            List<Page> pages = PDFConverter.GetTextFromAllPages(@"C:\Ornate\Ornate\data\sample_input.pdf");
            _dataset = new Dictionary<String, String>();
            foreach (var page in pages)
            {
                //Parsing the content to be trained
                _dataset.Add(page.getHeader().Replace(" ", String.Empty), page._content);
            }
            _classifier._dataset = _dataset;
            _classifier.trainDataset();


            textBox1.ScrollBars = ScrollBars.Vertical;
            IEnumerable<String> grams = StringComputation.makeNgrams("Hello my name is martin mese and I love programming", 3);
            foreach (var gram in grams)
            {
                // System.Diagnostics.Debug.WriteLine(gram); Test successful
            }



        }


        //private void btnSpeechText_Click(object sender, EventArgs e)
        //{
        //    pBuilder.ClearContent();
        //    pBuilder.AppendText(txtbox.Text);
        //    sSynth.Speak(pBuilder);

        //}

        //private void btnStart_Click(object sender, EventArgs e)
        //{
        //    btnStart.Enabled = false;
        //    btnStop.Enabled = true;
        //    Choices sList = new Choices();
        //    sList.Add(new String[] {"today","stacks","queues","artificial","intelligence"});
        //    Grammar grammar = new Grammar(sList);

        //    sRecognize.RequestRecognizerUpdate();
        //    sRecognize.LoadGrammar(grammar);
        //    sRecognize.SpeechRecognized += sRecognize_SpeechRecognized;
        //    sRecognize.SetInputToDefaultAudioDevice();
        //    sRecognize.RecognizeAsync(RecognizeMode.Multiple);

        //}

        //private void sRecognize_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        //{
        //    txtbox.Text = txtbox.Text+" " + e.Result.Text.ToString();
        //}

        //private void Form1_Load(object sender, EventArgs e)
        //{
        //    txtbox.ScrollBars = ScrollBars.Vertical;

        //}

        //private void button1_Click(object sender, EventArgs e)
        //{
        //   List<Page> pages= PDFConverter.GetTextFromAllPages("C:\\Users\\RENDANI MARTIN MESE\\Desktop\\Ornate\\Ornate\\data\\data.pdf");

        //    var _content_list = new List<string>();

        //    for (int i = 1; i < pages.Count; i++)
        //    {
        //        txtbox.Text += pages[i]._content+ "\r\n";
        //        txtbox.Text += "\r\n" + "\r\n";
        //        String[] _lower_data = pages[i]._content.Split();
        //        foreach(String s in _lower_data)
        //        {
        //            _content_list.Add(s);
        //        }

        //    }
        //    Dictionary<string, int> notesDictionary = new Dictionary<string, int>();

        //    foreach (string item in _content_list)
        //    {
        //        if (!notesDictionary.ContainsKey(item))
        //        {
        //            notesDictionary.Add(item, 1);
        //        }
        //        else
        //        {
        //            int count = 0;
        //            notesDictionary.TryGetValue(item, out count);
        //            notesDictionary.Remove(item);
        //            notesDictionary.Add(item, count + 1);
        //        }
        //    }
        //    // output the results, each item with quantity
        //    foreach (KeyValuePair<string, int> entry in notesDictionary)
        //    {
        //        txtbox.Text += entry.Key + " x " + entry.Value;
        //    };

        //    // PDFConverter.ExtractImagesFromPDF("C:\\Users\\RENDANI MARTIN MESE\\Desktop\\Ornate\\Ornate\\data\\data.pdf", "C:\\Users\\RENDANI MARTIN MESE\\Desktop\\Ornate\\Ornate\\data");
        //}

        private void btnCaptureNotes_Click_1(object sender, EventArgs e)
        {
            //Task task = new Task(new Action(PrintMessage));
            //task.Start();
            if (deficientParsed == true && recordingSpeech == false)
            {
                List<Page> pages = PDFConverter.GetTextFromAllPages(deficientDirectory);
                List<Page> correctContent = PDFConverter.GetTextFromAllPages(@"C:\Ornate\Ornate\data\sample_input.pdf");
                foreach (Page page in pages)
                {
                    _classifiedContent.Add(page._content);
                }
                StringBuilder contentresults = new StringBuilder();
                List<String> result = new List<string>();
                result = _classifier.classify(_classifiedContent);
                foreach (var val in result)
                {
                    System.Diagnostics.Debug.WriteLine(val);
                    foreach (var page in correctContent)
                    {
                        // System.Diagnostics.Debug.WriteLine(page.getHeader().Replace(" ", String.Empty));
                        if (page.getHeader().Replace(" ", String.Empty).ToLower().Equals(val.ToLower()))
                        {
                            contentresults.Append(page._content.Replace("#", ""));
                          
                        }
                    }
                }
                _converter.writeParagraph(contentresults.ToString());
                lstuatoSlides.Items.Clear();
                PopulateListBox(lstuatoSlides, @"C:\Ornate\Ornate\data\out", "*.pdf");
            }
            else
            {
                if (recordedPhrases.Count > 1)
                {
                    List<Page> correctContent = PDFConverter.GetTextFromAllPages(@"C:\Ornate\Ornate\data\sample_input.pdf");
                    foreach (var phrase in recordedPhrases)
                    {
                        _classifiedContent.Add(phrase);
                    }


                    List<String> result = new List<string>();
                    result = _classifier.classify(_classifiedContent);
                    StringBuilder contentresults = new StringBuilder();
                    foreach (var val in result)
                    {
                        System.Diagnostics.Debug.WriteLine(val);

                        foreach (var page in correctContent)
                        {

                            // System.Diagnostics.Debug.WriteLine(page.getHeader().Replace(" ", String.Empty));
                            if (page.getHeader().Replace(" ", String.Empty).ToLower().Equals(val.ToLower()))
                            {
                                contentresults.Append(page._content.Replace("#", ""));

                            }

                        }
                    }
                    _converter.writeParagraph(contentresults.ToString());
                    lstuatoSlides.Items.Clear();
                    PopulateListBox(lstuatoSlides, @"C:\Ornate\Ornate\data\out", "*.pdf");
                }
                else
                {
                    MessageBox.Show("Insufficient Information from Audio");
                }

            }



        }

        private void startRecognition()
        {

            if (fileParsed)
            {
                sRecognize.SpeechRecognized += sRecognize_SpeechRecognized;
                sRecognize.SetInputToDefaultAudioDevice();
                sRecognize.RecognizeAsync(RecognizeMode.Multiple);
            }
            else
            {
                MessageBox.Show("Parse the training file!");
            }

        }

        private void sRecognize_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            recordedPhrases.Add(e.Result.Text.ToString());
            textBox1.Text = textBox1.Text + " " + e.Result.Text.ToString();
        }

        private void btnTrainData_Click(object sender, EventArgs e)
        {
            OpenFileDialog fd = new OpenFileDialog();
            fd.InitialDirectory = @"C:\Ornate\Ornate\data";
            fd.Title = "Browse Training Document";
            fd.CheckFileExists = true;
            fd.CheckPathExists = true;
            fd.DefaultExt = "pdf";
            if (fd.ShowDialog() == DialogResult.OK)
            {

                List<Page> pages = PDFConverter.GetTextFromAllPages(fd.FileName);

                var _content_list = new List<string>();
                fileParsed = true;
                //loading grammar from the parsed file
                lines = RecognitionInitializer.getDictionary(fd.FileName);
                textBox1.Text += "Traing data is processed to grammar" + "\r\n";
                Choices sList = new Choices();
                sList.Add(lines);
                Grammar grammar = new Grammar(sList);
                sRecognize.RequestRecognizerUpdate();
                sRecognize.LoadGrammar(grammar);
                textBox1.Text += "Speech Recognition is ready" + "\r\n";
                chckTrainData.Checked = true;
            }
            else
            if (fd.ShowDialog() == DialogResult.Cancel)
            {
                fileParsed = false;
            }
        }

        private void btnUploadDeficient_Click(object sender, EventArgs e)
        {
            OpenFileDialog fd = new OpenFileDialog();
            fd.InitialDirectory = @"C:\Ornate\Ornate\data";
            fd.Title = "Browse Training Document";
            fd.CheckFileExists = true;
            fd.CheckPathExists = true;
            fd.DefaultExt = "pdf";
            if (fd.ShowDialog() == DialogResult.OK)
            {

                deficientDirectory = fd.FileName;
                deficientParsed = true;
                chckDeficient.Checked = true;
            }
            else
            {

                deficientParsed = false;
                chckDeficient.Checked = false;
            }
        }

        private void PopulateListBox(ListBox lsb, string Folder, string FileType)
        {
            DirectoryInfo dinfo = new DirectoryInfo(Folder);
            FileInfo[] Files = dinfo.GetFiles(FileType);
            foreach (FileInfo file in Files)
            {
                lsb.Items.Add(file.Name);
            }
        }

        private void comboMechanism_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboMechanism.SelectedItem.ToString().Equals("Deficient"))
            {
                btnUploadDeficient.Enabled = true;
            }
            else
            {
                btnUploadDeficient.Enabled = false;
            }
        }
        private void viewPDF(String directory)
        {
            webBrowser1.Navigate(directory);
        }

        private void lstuatoSlides_SelectedIndexChanged(object sender, EventArgs e)
        {
            String directory = @"C:\Ornate\Ornate\data\out\" + lstuatoSlides.SelectedItem.ToString();
            viewPDF(directory);
        }
        private async void Blink(Boolean condition)
        {
            if (key_space)
            {
                lblRecording.Text = "Recording";
                while (key_space)
                {
                    lblRecording.Visible = true;
                    await Task.Delay(500);
                    lblRecording.Visible = false;
                    await Task.Delay(500);
                }
            }

        }

        private void btnSpeech_Click(object sender, EventArgs e)
        {
            key_space = true;
            recordingSpeech = true;
            startRecognition();
            if (fileParsed)
            {
                //   Blink(key_space);
            }

        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                key_space = false;
                textBox1.Text = "Recognition is stopped";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            recordingSpeech = false;
            sRecognize.RecognizeAsyncStop();

        }
    }
}
