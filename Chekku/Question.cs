namespace Chekku
{
    class Question
    {
        private string qcode = "";
        private string question = "";
        private int itemNumber = 0;
        private string answer = "";
        private string base64 = "";
        private string ch1 = "";
        private string ch2 = "";
        private string ch3 = "";
        private int hasImg = 0;
        private int mistakes = 0;
        private int setNum = 1;

        public Question(string code, string q)
        {
            qcode = code;
            question = q;
        }

        public Question(int n, int m)
        {
            itemNumber = n;
            mistakes = m;
        }

        public Question(int s, int n, int m)
        {
            setNum = s;
            itemNumber = n;
            mistakes = m;
        }


        public Question(int n, string q, string a, string c1, string c2, string c3, int hI, string base6)
        {
            question = q;
            answer = a;
            ch1 = c1;
            ch2 = c2;
            ch3 = c3;
            hasImg = hI;
            itemNumber = n;
            base64 = base6;
        }

        

        public string Qcode
        {
            get { return qcode; }
            set { qcode = value; }
        }

        public string Quest
        {
            get { return question; }
            set { question = value; }
        }
        public string base6
        {
            get { return base64; }
            set { question = value; }
        }
        public int SetNum
        {
            get { return setNum; }
            set { setNum = value; }
        }

        public int Mistakes
        {
            get { return mistakes; }
            set { mistakes = value; }
        }

        public int Number
        {
            get { return itemNumber; }
            set { itemNumber = value; }
        }

        public string Answer
        {
            get { return answer; }
            set { answer = value; }
        }
        public string choice1
        {
            get { return ch1; }
            set { ch1 = value; }
        }
        public string choice2
        {
            get { return ch2; }
            set { ch2 = value; }
        }
        public string choice3
        {
            get { return ch3; }
            set { ch3 = value; }
        }

        public int img
        {
            get { return hasImg; }
            set { hasImg = value; }
        }


    }
}
