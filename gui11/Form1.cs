namespace gui11
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            txtInput.Text=Properties.Settings.Default.txtInput;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            string sentence = txtInput.Text;
            MessageBox.Show(Logic.splitSentence(sentence));
            Properties.Settings.Default.txtInput = sentence;
            Properties.Settings.Default.Save();
        }
    }

    public class Logic
    {
        public static string splitSentence(string sent)
        {
            char[] sep = { ' ', '.', ',', '!', '?', ';', ':', '-' };
            string[] words = sent.Split(sep);
            for (int i = 0; i < words.Length - 1; i++)
            {
                for (int j = 0; j < words.Length - 1 - i; j++)
                {
                    if (words[j].Length < words[j + 1].Length)
                    {
                        string temp = words[j];
                        words[j] = words[j + 1];
                        words[j + 1] = temp;
                    }
                }
            }
            string result = "";
            for (int i = 0; i < words.Length; i++)
            {
                result += words[i] + " ";
            }
            return result;
        }
    }
}

