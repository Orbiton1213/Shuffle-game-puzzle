namespace ShuffelGamePuzzel
{
    public partial class ShuffelGamePuzzel : Form
    {
        public ShuffelGamePuzzel()
        {
            InitializeComponent();
        }
    
            // the number of the squers on the board 3x3
            const int BOARD_NUM = 3;

            //the size of the squers
            const int BOARD_SIZE = 120;

            //Game over massage (when you win)
            const string WINNIG_MESSAGE = "Congrtulation ! , Your the Winner !";

            //defualt color
            readonly Color BackgroundDefult = new Button().BackColor;

            //creatin the board itself with buttons
            readonly Button[,] board = new Button[BOARD_SIZE, BOARD_NUM];

            //the list of the numbers that will appear on the board
            private static readonly List<string> NumberList = new List<string>(){
                   "1","2","3","4","5","6","7","8",""
        };

            private void ShuffelGamePuzzel_Load(object sender, EventArgs e)
            {
                ClientSize = new Size(BOARD_NUM * BOARD_SIZE, BOARD_NUM * BOARD_SIZE);
                Size ButtonSize = new(BOARD_SIZE, BOARD_SIZE);

                for (int i = 0; i < BOARD_NUM; ++i)
                {
                    for (int j = 0; j < BOARD_NUM; ++j)
                    {
                        board[i, j] = new Button
                        {
                            Size = ButtonSize,
                            Location = new Point(BOARD_SIZE * i, BOARD_SIZE * j),
                            TabStop = false
                        };
                        board[i, j].Click += Button_Click;
                        Controls.Add(board[i, j]);
                    }
                }
                AutoSize = true;
                AutoSizeMode = AutoSizeMode.GrowAndShrink;
                ShuffleBoard();
            }
                //the event when you click on the button
            private void Button_Click(object sender, EventArgs e)
            {
                Button Button = sender as Button;

                int x = (Button.Bounds.X) /BOARD_SIZE;
                int y = (Button.Bounds.Y) /BOARD_SIZE;
                if (IsLegal(x, y))
                {
                    //Switch Between the buttons
                    string swi = board[x,y].Text;
                    foreach (Control control in Controls)
                    {

                        Button SecButton = control as Button;

                        if (SecButton.Text == "")
                        {
                            SecButton.Text = swi;
                        }
                        
                            board[x, y].Text = "";
                    }

                }
                if (CheckFunc())
                {
                    MessageBox.Show(WINNIG_MESSAGE);
                }
            }
        //checking the position near the button
            private bool IsLegal(int x, int y)
            {
                if (board[x, y].Text == "")
                { 
                return false;
                }

                for (int i = -1; i <= 1; i++)
                {
                    for (int j = -1; j <= 1; j++)
                    {
                        if (LegalPath(x,y,i,j))
                        {
                            return true;
                        }
                    }
                }
                return false;
            }
        //the right way
            private bool LegalPath(int x, int y, int i, int j)
            {
                if (i == 0 && j == 0) { 
                return false; 
                }
                if (i == -1 && j == 1) { 
                return false; 
                 }
                if (i == 1 && j == 1) {
                return false;
                 }
                if (i == 1 && j == -1) {
                return false; 
                 }
                if (i == -1 && j == -1) {
                return false;
                  }
            if (x + i < 0 || x + i >= BOARD_NUM || y + j < 0 || y + j >= BOARD_NUM)
                {
                    return false;
                }
                if (!board[x + i, y + j].Text.Equals(""))
                { 
                return false;
            }
                return true;
            }
            //suffle between the buttons and numbers
            private void ShuffleBoard()
            {
                Random random = new Random(Environment.TickCount);

                foreach (Control control in Controls)
                {
                    Button Button = control as Button;
                    int rand = random.Next(NumberList.Count);
                    Button.Text = NumberList[rand];
                    NumberList.RemoveAt(rand);
                }
            }
            //checking the positions and numbers if the equals
            private bool CheckFunc()
            {
                if (board[0, 0].Text.Equals("1") &&
               board[0, 1].Text.Equals("2") &&
               board[0, 2].Text.Equals("3") &&
                board[1, 0].Text.Equals("4") &&
                board[1, 1].Text.Equals("5") &&
                board[1, 2].Text.Equals("6") &&
                board[2, 0].Text.Equals("7") &&
                board[2, 1].Text.Equals("8") &&
                board[2, 2].Text.Equals(" ")) {
                return true; 
                }

                else return false;
            }

        private void ShuffelGamePuzzel_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult FinishGame = MessageBox.Show("Are you sure you want to exit?", "Slidding-Puzzle-Game", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (FinishGame == DialogResult.No)
            {
                e.Cancel = true;
            }
        }
    }

}   

