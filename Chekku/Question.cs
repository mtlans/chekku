﻿namespace Chekku
{
    class Question
    {
        private string qcode = "";
        private string question = "";
        private int itemNumber = 0;
        private string answer = "";
        private string ch1 = "";
        private string ch2 = "";
        private string ch3 = "";
        private int hasImg = 0;


        public Question(string code, string q)
        {
            qcode = code;
            question = q;
        }

        public Question(int n, string q, string a, string c1, string c2, string c3, int hI)
        {
            question = q;
            answer = a;
            ch1 = c1;
            ch2 = c2;
            ch3 = c3;
            hasImg = hI;
            itemNumber = n;
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
