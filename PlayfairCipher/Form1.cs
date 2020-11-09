using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PlayfairCipher
{    
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        ErrorProvider errorP = new ErrorProvider();

        public bool ValidKeyword(string keyword, out string errorMessage)
        {
            if (keyword.Length == 0)
            {
                errorMessage = "Keyword is required to encrypt a message";
                return false;
            }
            if (keyword.Length < 3)
            {
                errorMessage = "Keyword must contain at least 3 letters";
                return false;
            }
            if (Regex.IsMatch(keyword, @"^[a-zA-Z]+$"))
            {
                errorMessage = "";
                return true;
            }
            
            errorMessage = "Keyword must contain only letters from a to z";
            return false;
        }

        private char[] engAlphabet = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'X', 'Y', 'Z' };
        private char[,] table = new char[5, 5];

        private int[] getPosition(char letter)
        {
            int[] position = new int[2];

            for (int i = 0; i < table.GetLength(0); i++)
            {
                for (int j = 0; j < table.GetLength(1); j++)
                {
                    if (letter == table[i, j])
                    {
                        position[0] = i;
                        position[1] = j;
                        return position;
                    }
                }
            }
            return position;
        }

        private char getLetter(int[] position)
        {
            return table[position[0], position[1]];
        }

        private int[] swapOpposite(int firstLetterColPos, int secondLetterColPos)
        {
            int height = Math.Abs(firstLetterColPos - secondLetterColPos);

            int[] position = new int[2];

            position[0] = (firstLetterColPos > secondLetterColPos)
                ? firstLetterColPos - height
                : firstLetterColPos + height;

            position[1] = (secondLetterColPos > firstLetterColPos)
                ? secondLetterColPos - height
                : secondLetterColPos + height;

            return position;
        }

        private string encryptDigram(string digram, bool reverse = false)
        {
            string newDigram = "";
            int[] firstLetterPos = getPosition(digram[0]);
            int[] secondLetterPos = getPosition(digram[1]);

            if (reverse)
            {
                if (firstLetterPos[0] == secondLetterPos[0])
                {
                    firstLetterPos[1] = (firstLetterPos[1] == 0) ? firstLetterPos[1] = 4 : firstLetterPos[1] -= 1;
                    secondLetterPos[1] = (secondLetterPos[1] == 0) ? secondLetterPos[1] = 4 : secondLetterPos[1] -= 1;
                }
                //2nd rule - check if letters are in same column
                else if (firstLetterPos[1] == secondLetterPos[1])
                {
                    firstLetterPos[0] = (firstLetterPos[0] == 0) ? firstLetterPos[0] = 4 : firstLetterPos[0] -= 1;
                    secondLetterPos[0] = (secondLetterPos[0] == 0) ? secondLetterPos[0] = 4 : secondLetterPos[0] -= 1;
                }
                else
                {
                    int[] changedPositions = swapOpposite(firstLetterPos[1], secondLetterPos[1]);
                    firstLetterPos[1] = changedPositions[0];
                    secondLetterPos[1] = changedPositions[1];
                }
            }
            else
            {
                //1st rule - check if letters are in same row
                if (firstLetterPos[0] == secondLetterPos[0])
                {
                    firstLetterPos[1] = (firstLetterPos[1] == 4) ? firstLetterPos[1] = 0 : firstLetterPos[1] += 1;
                    secondLetterPos[1] = (secondLetterPos[1] == 4) ? secondLetterPos[1] = 0 : secondLetterPos[1] += 1;
                }
                //2nd rule - check if letters are in same column
                else if (firstLetterPos[1] == secondLetterPos[1])
                {
                    firstLetterPos[0] = (firstLetterPos[0] == 4) ? firstLetterPos[0] = 0 : firstLetterPos[0] += 1;
                    secondLetterPos[0] = (secondLetterPos[0] == 4) ? secondLetterPos[0] = 0 : secondLetterPos[0] += 1;
                }
                else
                {
                    int[] changedPositions = swapOpposite(firstLetterPos[1], secondLetterPos[1]);
                    firstLetterPos[1] = changedPositions[0];
                    secondLetterPos[1] = changedPositions[1];
                }
            }            

            newDigram += getLetter(firstLetterPos);
            newDigram += getLetter(secondLetterPos);

            return newDigram;
        }

        private string convertSpaces(string text)
        {
            return text.Replace(" ", "Q");
        }

        private string removeDuplicates(string word)
        {
            string removed = "";
            List<char> found = new List<char>();
            for (int i = 0; i < word.Length; i++)
            {
                if (i == 0)
                {
                    removed += word[i];
                    found.Add(word[i]);
                    continue;
                }

                removed = (!found.Contains(word[i])) ? removed += word[i] : removed;
                found.Add(word[i]);
            }

            return removed;
        }

        private string removeX (string text)
        {
            if(text[text.Length - 1] == 'X')
            {
                text = text.Remove(text.Length - 1);
            }
            return text;
        }


        private string editOpenText(string openText)
        {
            string normalizedString = openText.Normalize(NormalizationForm.FormD);
            StringBuilder removedDiacritics = new StringBuilder();

            for (int i = 0; i < normalizedString.Length; i++)
            {
                UnicodeCategory uc = CharUnicodeInfo.GetUnicodeCategory(normalizedString[i]);
                if (uc != UnicodeCategory.NonSpacingMark) removedDiacritics.Append(normalizedString[i]);
            }

            openText = removedDiacritics.ToString().ToUpper();
            //openText = (openText.Contains(" ")) ? openText.Replace(" ", "") : openText;

            // replacing W and Q for their equivalent in czech language
            openText = (openText.Contains('W')) ? openText.Replace('W', 'V') : openText;
            openText = (openText.Contains('Q')) ? openText.Replace('Q', 'K') : openText;

            string editedText = "";

            for (int i = 0; i < openText.Length; i++)
            {
                if (i == openText.Length - 1)
                {
                    editedText += openText[i];
                }
                else if (openText[i] != openText[i + 1])
                {
                    editedText += openText[i];
                }
                else
                {
                    editedText += openText[i] + "X";
                }
            }

            editedText = (editedText.Length % 2 != 0) ? editedText += 'X' : editedText;
            editedText = convertSpaces(editedText);
            return editedText.Trim();
        }

        private void fillTable(string keyword)
        {
            string kAlpha = "";

            for (int i = 0; i < keyword.Length; i++)
            {
                kAlpha += keyword[i];
            }

            for (int i = 0; i < engAlphabet.Length; i++)
            {
                kAlpha += engAlphabet[i];
            }

            kAlpha = removeDuplicates(kAlpha);

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.ColumnCount = table.GetLength(1);

            // filling 2D array with characters from kAplha string
            for (int i = 0; i < table.GetLength(0); i++)
            {
                for (int j = 0; j < table.GetLength(1); j++)
                {
                    table[i, j] = kAlpha[table.GetLength(0) * i + j];
                }
            }

            for (int i = 0; i < table.GetLength(0); i++) 
            {
                string[] row = new string[table.GetLength(1)];
                for (int j = 0; j < table.GetLength(0); j++) 
                {
                    row[j] = Convert.ToString(table[i, j]);
                }
                dataGridView1.Rows.Add(row);
            }            
        }

        private List<string> makeDigrams(string text)
        {
            List<string> digrams = new List<string>();

            for (int i = 0; i < text.Length; i += 2)
            {
                string el = "";
                el += text[i];
                el += text[i + 1];
                digrams.Add(el);
            }

            return digrams;
        }

        private void showDigrams(List<string> digrams, TextBox textBox, bool decryption = false)
        {
            if(digrams.Count() > 1)
            {
                StringBuilder sc = new StringBuilder();
                foreach (var digram in digrams)
                {
                    sc.Append(digram);
                }

                string outText = sc.ToString();
                if (decryption)
                {
                    outText = removeX(outText);
                    outText = (outText.Contains("Q") ? outText.Replace("Q", " ") : outText);
                }
               
                textBox.Text = outText;
            }
        }

        private void encryptBtn_Click(object sender, EventArgs e)
        {
            if (encryptionTextInput.Text.Length > 0 && keyTextInput.Text.Length > 0)
            {
                startEncryption(encryptionTextInput.Text, keyTextInput.Text);
            }
            else
            {
                MessageBox.Show("Enter text into the open text field.");
            }
        }

        private void startEncryption(string openText, string keyword)
        {
            string editedText = editOpenText(openText);
            editedTextOut.Text = editedText;

            List<string> digrams = makeDigrams(editedText);

            keyword = removeDuplicates(keyword).ToUpper();
            fillTable(keyword);

            List<string> encryptedDigrams = new List<string>();

            foreach (var digram in digrams)
            {
                encryptedDigrams.Add(encryptDigram(digram));
            }

            showDigrams(encryptedDigrams, encryptedTextOut);
        }

        private void startDecryption(string encryptedText)
        {
            List<string> encryptedDigrams = makeDigrams(encryptedText);

            List<string> decryptedDigrams = new List<string>();

            foreach (var encDigram in encryptedDigrams)
            {
                decryptedDigrams.Add(encryptDigram(encDigram, true));
            }

            showDigrams(decryptedDigrams, decryptedTextOut, true);
        }

        private void decryptBtn_Click(object sender, EventArgs e)
        {
            if (decryptTextInput.Text.Length > 0 && decryptTextInput.Text.Length % 2 == 0)
            {
                startDecryption(decryptTextInput.Text);
            }
            else
            {
                MessageBox.Show("Enter valid encrypted text into the decryption field.");
            }
        }

        private void encryptBtn_Enter(object sender, EventArgs e)
        {
            string errorMsg;
            if (!ValidKeyword(keyTextInput.Text, out errorMsg))
            {
                MessageBox.Show(errorMsg);
            }
        }

        private void keyTextInput_Validating(object sender, CancelEventArgs e)
        {
            string errorMsg;
            if(!ValidKeyword(keyTextInput.Text, out errorMsg))
            {
                e.Cancel = true;
                this.errorP.SetError(keyTextInput, errorMsg);
            }
        }

        private void keyTextInput_Validated(object sender, EventArgs e)
        {
            errorP.SetError(keyTextInput, "");
        }
    }
}
