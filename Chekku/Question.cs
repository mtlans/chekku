namespace Chekku
{
    class Question
    {
        private string qcode = "";
        private string question = "";
        private string itemNumber = "";

        public Question(string code, string q)
        {
            qcode = code;
            question = q;
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

        public string Number
        {
            get { return itemNumber; }
            set { itemNumber = value; }
        }


    }
}
